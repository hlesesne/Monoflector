using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class EventNode : MemberNode {

		public EventNode(EventDefinition evnt) : base(evnt) {

			this.Text = evnt.Name;
			this.ImageIndex = Resources.Bitmaps.Event.Default;

			if (evnt.AddMethod != null) {
				MethodNode node = new MethodNode(evnt.AddMethod);
				this.Nodes.Add(node);
			}

			if (evnt.InvokeMethod != null) {
				MethodNode node = new MethodNode(evnt.InvokeMethod);
				this.Nodes.Add(node);
			}

			if (evnt.RemoveMethod != null) {
				MethodNode node = new MethodNode(evnt.RemoveMethod);
				this.Nodes.Add(node);
			}

			if (evnt.HasOtherMethods) {
				foreach (var method in evnt.OtherMethods.OrderBy(o => o.Name)) {
					MethodNode node = new MethodNode(method);
					this.Nodes.Add(node);
				}
			}

			// TODO - loop through methods

		}
	}
}
