using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector.Controls {
	public static class Extensions {

		public static Control Next(this Control control){

			Control next = null;
			Control.ControlCollection controls = control.Parent.Controls;
			int nextIndex = controls.IndexOf(control) + 1;

			if (nextIndex < controls.Count) {
				next = controls[nextIndex];
			}

			return next;

		}

		public static Control Previous(this Control control) {

			Control previous = null;
			Control.ControlCollection controls = control.Parent.Controls;
			int previousIndex = controls.IndexOf(control) - 1;

			if (previousIndex > 0) {
				previous = controls[previousIndex];
			}

			return previous;

		}

	}
}
