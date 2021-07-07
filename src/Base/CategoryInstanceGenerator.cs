using System;
using System.Collections.Generic;
using System.Diagnostics;

using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Packages;
using Artech.Common.Collections;
using Artech.Common.Helpers.Language;
using Artech.Common.Properties;
using Artech.Genexus.Common;
using Artech.Genexus.Common.Objects;
using Gx = Artech.Genexus.Common.Objects;
using Artech.Genexus.Common.Parts;
using Artech.Genexus.Common.Parts.Structure;
using Artech.Packages.Patterns;
using Artech.Packages.Patterns.Custom;
using Artech.Packages.Patterns.Objects;
using Artech.Patterns.Category.Resources;

namespace Artech.Patterns.Category
{
	internal class CategoryInstanceGenerator : DefaultInstanceGenerator
	{
		public override void Generate(KBObject baseObject, PatternInstance instance)
		{
			if ((baseObject as Transaction) == null)
				throw new PatternException(Messages.ParentMustBeTransaction);

			Transaction transaction = (Transaction)baseObject;
			CategoryInstance catInstance = new CategoryInstance(baseObject.Model);
			CategorySettings.Get(baseObject.Model);

			Generate(transaction, catInstance);
			catInstance.SaveTo(instance);
			//catInstance.ParentObject.Structure.Root.PrimaryKey.Count 
		}

		public override bool GetDependencies(IList<KBObjectDescriptor> dependencies)
		{
			dependencies.Add(PackageManager.Manager.GetKBObjectDescriptor(ObjClass.Transaction));
			dependencies.Add(PackageManager.Manager.GetKBObjectDescriptor(ObjClass.Table));
			dependencies.Add(PackageManager.Manager.GetKBObjectDescriptor(ObjClass.Attribute));
			return true;
		}

		#region Instance / Level Generation

		private void Generate(Transaction transaction, CategoryInstance instance)
		{
            AddTransaction(transaction, instance);

            AddAttributesNames(transaction, instance);

            AddTransactionsName(transaction, instance);

            AddTransactionAttributes(transaction, instance);

		}

        
        private void AddTransaction(Transaction transaction, CategoryInstance categoryInstance)
        {
            categoryInstance.ShowLeafItemsInTreeView = true;
        }
        
        private void AddAttributesNames(Transaction transaction, CategoryInstance categoryInstance)
        {
            categoryInstance.AttributesName = new AttributesNameElement();
            CategorySettings settings = categoryInstance.Settings;
            categoryInstance.AttributesName.CategoryId = FormatString(settings.AttributesName.CategoryId, transaction.Name);
            categoryInstance.AttributesName.CategoryName = FormatString(settings.AttributesName.CategoryName, transaction.Name);
            categoryInstance.AttributesName.CategoryParentId = FormatString(settings.AttributesName.CategoryParentId, transaction.Name);
            categoryInstance.AttributesName.CategoryParentName = FormatString(settings.AttributesName.CategoryParentName, transaction.Name); 
        }
        

        private void AddTransactionsName(Transaction transaction, CategoryInstance categoryInstance)
        {
            categoryInstance.TransactionsName = new TransactionsNameElement();
            CategorySettings settings = categoryInstance.Settings;
            categoryInstance.TransactionsName.Category = FormatString(settings.TransactionsName.Category, transaction.Name);
            categoryInstance.TransactionsName.CategoryItem = FormatString(settings.TransactionsName.CategoryItem, transaction.Name); ;
        }

        private void AddTransactionAttributes(Transaction transaction, CategoryInstance categoryInstance)
        {
            foreach (TransactionAttribute att in transaction.Structure.Root.Attributes)
            {
                AttributeElement elem = new AttributeElement();
                elem.Attribute = att.Attribute ;
                
                elem.Description = att.Attribute.Description;
                if(att.IsDescriptionAttribute || att.IsKey )
                {
                    elem.Link = true;
                }
                else
                {
                    elem.Link = false;
                }
                elem.Visible = true;
                categoryInstance.ViewItemAttributes.Add(elem);
            }
        }


        private string FormatString(string formatStr, string obj)
        {
            return formatStr.Replace("<Object>", obj);
			
        }



       
		#endregion
	}
}
