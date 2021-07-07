using System;
using System.Diagnostics;

using Artech.Common;
using Artech.Common.Collections;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common;
using Artech.Genexus.Common.CustomTypes;
using Artech.Genexus.Common.Objects;
using Artech.Packages.Patterns.Custom;
using Artech.Packages.Patterns.Definition;
using Artech.Packages.Patterns.Engine;
using Artech.Packages.Patterns.Objects;
using System.Collections.Generic;

namespace Artech.Patterns.Category
{
	internal class CategoryBuildProcess : PatternBuildProcess
	{
		
		#region Update generated objects

		public override void BeforeSaveObjects(PatternInstance instance, InstanceObjects instanceObjects)
		{
			base.BeforeSaveObjects(instance, instanceObjects);

			// Set main for relation WP.
			SetObjectsMainProperty(instanceObjects.GeneratedObjects );

		}

		private void SetObjectsMainProperty(IEnumerable<KBObject> group)
		{
			if (group != null )
			{
				foreach (KBObject kbObject in group)
				{
					WebPanel webPanel = kbObject as WebPanel;
					if (webPanel!= null && webPanel.IsPropertyDefault(Properties.WBP.MainProgram))
						webPanel.SetPropertyValue(Properties.WBP.MainProgram , true);
				}
			}
		}
		

		#endregion
	}
}
