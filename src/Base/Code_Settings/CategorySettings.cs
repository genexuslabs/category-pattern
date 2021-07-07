using System;
using System.Collections.Generic;
using System.Text;
using Artech.Patterns.Category.Resources;
using Artech.Architecture.Common.Objects;
using Artech.Packages.Patterns.Objects;
using Artech.Packages.Patterns;

namespace Artech.Patterns.Category
{
    public partial class CategorySettings
    {
		private const string k_ModelProperty = "Category:Settings";
	
        public static CategorySettings Get(KBModel model)
        {
			PatternSettings current = PatternSettings.Get(model, CategoryPattern.Definition);
			CategorySettings cached = model.GetPropertyValue<CategorySettings>(k_ModelProperty);

			if (cached == null || cached.VersionId != current.VersionId)
			{
				cached = new CategorySettings(current);
				cached.VersionId = current.VersionId;
				model.SilentSetPropertyValue(k_ModelProperty, cached);
			}
			return cached;
        }

       
		internal static void ResetCache(KBModel model)
		{
			model.ResetProperty(k_ModelProperty);
		}

		private int m_VersionId = 0;

		internal int VersionId
		{
			get { return m_VersionId; }
			private set { m_VersionId = value; }
		}
        		

    }
}
