using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector.Controls {
	public class CustomSplitContainer : ContainerControl {

		public CustomSplitContainer() : base() {
			this.Panels = 2;
		}

		[Description("Sets the number of Panels to display."), Category("Values"), DefaultValue(2), Browsable(true)]
		public int Panels { get; set; }

	}
}
