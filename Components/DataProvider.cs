//
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2011
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Data;

namespace DotNetNuke.Modules.FAQs
{
	
	public abstract class DataProvider
	{
		
		#region "Shared/Static Methods"

        /// <summary>
        /// singleton reference to the instantiated object 
        /// </summary>
        private static DataProvider objProvider = null;

        /// <summary>
        /// constructor
        /// </summary>
        static DataProvider()
        {
            CreateProvider();
        }

        /// <summary>
        /// dynamically create provider 
        /// </summary>
        private static void CreateProvider()
        {
            objProvider = (DataProvider)DotNetNuke.Framework.Reflection.CreateObject("data", "DotNetNuke.Modules.FAQs", "");
		}

		/// <summary>
		/// return the provider 
		/// </summary>
		/// <returns></returns>
		public static DataProvider Instance()
		{
			return objProvider;
		}
		
		#endregion
		
		#region FAQ Methods
		public abstract IDataReader GetFAQ(int faqId, int moduleId);
		public abstract int AddFAQ(int moduleId, int categoryId, string question, string answer, string createdByUser, DateTime dateAdded, DateTime dateModified, int viewCount, int viewOrder, bool faqHide, DateTime publishDate, DateTime expireDate);
		public abstract void UpdateFAQ(int faqId, int moduleId, int categoryId, string question, string answer, string createdByUser, DateTime dateModified, int viewOrder, bool faqHide, DateTime publishDate, DateTime expireDate);
		public abstract void DeleteFAQ(int faqId, int moduleId);
		public abstract void ReorderFAQ(int faqId1, int faqId2, int moduleId);
		public abstract IDataReader SearchFAQList(int moduleId, int orderBy, bool showHidden);
		public abstract void IncrementViewCount(int faqId);
		#endregion
		
#		region Category Methods
		public abstract IDataReader GetCategory(int faqCategoryId, int moduleId);
		public abstract IDataReader ListCategories(int moduleId, bool onlyUsedCategories);
		public abstract IDataReader ListCategoriesHierarchical(int moduleId, bool onlyUsedCategories);
		public abstract int AddCategory(int moduleId, int faqCategoryParentId, string faqCategoryName, string faqCategoryDescription, int ViewOrder);
		public abstract void UpdateCategory(int faqCategoryId, int moduleId, int faqCategoryParentId, string faqCategoryName, string faqCategoryDescription, int ViewOrder);
		public abstract void DeleteCategory(int faqCategoryId);
		public abstract void ReorderCategory(int faqParentCategoryId, int moduleId);
		#endregion

	}
	
}
