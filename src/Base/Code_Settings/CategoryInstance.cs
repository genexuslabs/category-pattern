using System;
using System.Collections.Generic;
using System.Text;

namespace Artech.Patterns.Category
{
    public partial class CategoryInstance
    {
        #region Category Settings

        public CategorySettings Settings
        {
            get { return CategorySettings.Get(this.Model); }
        }

        #endregion

    }
}
