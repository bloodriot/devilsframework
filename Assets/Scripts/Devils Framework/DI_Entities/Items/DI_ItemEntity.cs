// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Core.Events;
using DI.Core.Debug;
using DI.Entities.Core;
using DI.Entities.Properties;

namespace DI.Entities.Items
{
	public class DI_ItemEntity : DI_Entity
	{
		public bool isActivated;

		public virtual void onTouch() {}
		public virtual void onUse() {}
		public virtual void onActivate() {}
		public virtual void onDeactivate() {}

		public bool isItemActive()
		{
			return isActivated;
		}
	}
}