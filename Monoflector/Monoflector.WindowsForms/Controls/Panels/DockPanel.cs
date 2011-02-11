using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Monoflector.Controls.Panels {

	public class DockPanel : UserControl {

		protected Panel _Content;

		private Bitmap _backBuffer;
		private const int _padding = 6;
		private Boolean _closeActive = false;
		private Rectangle _buttonRect = Rectangle.Empty;

		public event EventHandler BeforeVisibleChanged;

		public DockPanel() {
			// Set the value of the double-buffering style bits to true.
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			this.UpdateStyles();
			this.Left = 0;
			this.Margin = new Padding(0);

			using (Graphics g = Graphics.FromHwnd(IntPtr.Zero)) {
				SizeF size = g.MeasureString("X", this.Font);
				this.Padding = new Padding(0, (int)size.Height + (_padding * 2), 0, 0);
			}

			this.SuspendLayout();

			_Content = new Panel() {
				BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
				Top = this.Padding.Top,
				Dock = DockStyle.Fill,
				Padding = new Padding(0),
				Margin = new Padding(0)
			};

			this.Controls.Add(_Content);
			
			this.ResumeLayout();
		}

		private new ControlCollection Controls {
			get { return base.Controls; }
		}

		/// <summary>
		/// The content area of the DockPanel. Any child controls should be added to this control.
		/// </summary>
		public Panel Content {
			get { return _Content; }
		}

		[Description("Sets the Text"), Category("Values"), DefaultValue("Section"), Browsable(true)]
		public override string Text {
			get {
				return base.Text;
			}
			set {
				base.Text = value;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e) {

			if (_buttonRect.Contains(e.Location)) {
				if (!_closeActive) {
					this.Cursor = Cursors.Hand;
					_closeActive = true;
					this.Invalidate(_buttonRect);
				}
			}
			else {
				if (_closeActive) {
					this.Cursor = Cursors.Default;
					_closeActive = false;
					this.Invalidate(_buttonRect);
				}
			}

			base.OnMouseMove(e);
		}

		protected override void OnInvalidated(InvalidateEventArgs e) {
			ClearBuffer();
			base.OnInvalidated(e);
		}

		protected override void OnSizeChanged(EventArgs e) {
			ClearBuffer();
			Invalidate();
			base.OnSizeChanged(e);
		}

		protected override void OnClick(EventArgs e) {
			Point p = this.PointToClient(MousePosition);
			if (_buttonRect.Contains(p)) {
				this.Hide();
			}
			base.OnClick(e);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent) {
			//Don't allow the background to paint
		}

		protected override void OnPaint(PaintEventArgs e) {

			if (_backBuffer == null) {
				_backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

				using (Graphics g = Graphics.FromImage(_backBuffer)) {

					Rectangle rect = new Rectangle(0, 0, this.Width, this.Padding.Top);

					using (Brush brush = new SolidBrush(this.BackColor)) {
						g.FillRectangle(brush, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
					}

					FillHeader(g, rect);
					DrawHeader(g, rect);

				}
			}

			e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
		}

		public new Boolean Visible {
			get { return base.Visible; }
			set {
				if (BeforeVisibleChanged != null && this.Visible != value) {
					BeforeVisibleChanged(this, new EventArgs());
				}
				base.Visible = value;
			}
		}

		public void Toggle() {
			this.Visible = !this.Visible;
		}

		private void ClearBuffer() {
			if (_backBuffer != null) {
				_backBuffer.Dispose();
				_backBuffer = null;
				_buttonRect = Rectangle.Empty;
			}
		}

		public virtual void FillHeader(Graphics g, Rectangle rect) {

			bool drawNative = true;

			if (Application.RenderWithVisualStyles) {

				VisualStyleElement element = VisualStyleElement.Header.Item.Normal;

				if (VisualStyleRenderer.IsElementDefined(element)) {
					VisualStyleRenderer renderer = new VisualStyleRenderer(element);
					renderer.DrawBackground(g, rect);
					drawNative = false;
				}
			}

			if (drawNative) {
				Color backColor = SystemColors.Control;

				using (Brush brush = new SolidBrush(backColor)) {
					g.FillRectangle(brush, rect);
				}

				using (Pen pen = new Pen(SystemColors.ControlDark)) {
					g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
				}
			}
		}

		public virtual void DrawHeader(Graphics g, Rectangle rect) {

			g.DrawString(this.Text, this.Font, SystemBrushes.ControlText, new PointF(_padding, _padding));

			ColorMatrix cm = new ColorMatrix(new float[][]{   new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0,0,0,1,0,0},
                                  new float[]{0,0,0,0,1,0},
                                  new float[]{0,0,0,0,0,1}});

			using (Bitmap button = Resources.Png.close) {

				if (_buttonRect == Rectangle.Empty) {
					int x = rect.Width - _padding - button.Width;
					int y = (rect.Height - button.Height) / 2;

					_buttonRect = new Rectangle(x, y, button.Width, button.Height);
				}

				if (!_closeActive) {
					ImageAttributes ia = new ImageAttributes();
					ia.SetColorMatrix(cm);
					g.DrawImage(button, _buttonRect, 0, 0, button.Width, button.Height, GraphicsUnit.Pixel, ia);
				}
				else {
					g.DrawImage(button, _buttonRect, 0, 0, button.Width, button.Height, GraphicsUnit.Pixel);
				}
			}

		}
	}
}
