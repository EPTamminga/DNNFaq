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
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;

namespace DotNetNuke.Modules.FAQs
{
	
	/// <summary>
	/// Main info class for the supporting categories
	/// </summary>
	[Serializable()]
	public class CategoryInfo:IHydratable
	{
		#region Private Members

		private int _faqCategoryId;
		private int _faqCategoryParentId;
		private int _moduleId;
		private string _faqCategoryName;
		private string _faqCategoryDescription;
		private int _level;
		private int _viewOrder;
		
		#endregion
		
		#region Constructors

		public CategoryInfo()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryInfo" /> class.
		/// </summary>
		/// <param name="faqCategoryId">The FAQ category id.</param>
		/// <param name="moduleId">The module id.</param>
		/// <param name="faqCategoryParentId">The FAQ parent category id.</param>
		/// <param name="faqCategoryName">Name of the FAQ category.</param>
		/// <param name="faqCategoryDescription">The FAQ category description.</param>
		public CategoryInfo(int faqCategoryId, int moduleId, int faqCategoryParentId, string faqCategoryName, string faqCategoryDescription)
		{
			this.FaqCategoryId = faqCategoryId;
			this.ModuleId = moduleId;
			this.FaqCategoryParentId = faqCategoryParentId;
			this.FaqCategoryName = faqCategoryName;
			this.FaqCategoryDescription = faqCategoryDescription;
			this.Level = 0;
			this.ViewOrder = 999;
		}
		#endregion
		
		#region Public Properties
		/// <summary>
		/// Gets or sets the FAQ category parent id.
		/// </summary>
		/// <value>The FAQ category parent id.</value>
		public int FaqCategoryParentId
		{
			get
			{
				return _faqCategoryParentId;
			}
			set
			{
				_faqCategoryParentId = value;
			}
		}
		
		
		/// <summary>
		/// Gets or sets the FAQ category id.
		/// </summary>
		/// <value>The FAQ category id.</value>
		public int FaqCategoryId
		{
			get
			{
				return _faqCategoryId;
			}
			set
			{
				_faqCategoryId = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the module id.
		/// </summary>
		/// <value>The module id.</value>
		public int ModuleId
		{
			get
			{
				return _moduleId;
			}
			set
			{
				_moduleId = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the name of the FAQ category.
		/// </summary>
		/// <value>The name of the FAQ category.</value>
		public string FaqCategoryName
		{
			get
			{
				return _faqCategoryName;
			}
			set
			{
				_faqCategoryName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the FAQ category description.
		/// </summary>
		/// <value>The FAQ category description.</value>
		public string FaqCategoryDescription
		{
			get
			{
				return _faqCategoryDescription;
			}
			set
			{
				_faqCategoryDescription = value;
			}
		}

		/// <summary>
		/// Gets or sets the module hierarchical level.
		/// </summary>
		/// <value>The module hierarchical level.</value>
		public int Level
		{
			get
			{
				return _level;
			}
			set
			{
				_level = value;
			}
		}

		/// <summary>
		/// Gets or sets the view order between childs of one node.
		/// </summary>
		/// <value>The view order.</value>
		public int ViewOrder
		{
			get
			{
				return _viewOrder;
			}
			set
			{
				_viewOrder = value;
			}
		}

		#endregion

		#region Implementation of IHydratable

		public void Fill(IDataReader dr)
		{
			_faqCategoryParentId = Null.SetNullInteger(dr["FaqCategoryParentId"]);
			_faqCategoryId = Null.SetNullInteger(dr["FaqCategoryId"]);
			_moduleId = Null.SetNullInteger(dr["ModuleId"]);
			_faqCategoryName = Null.SetNullString(dr["FaqCategoryName"]);
			_faqCategoryDescription = Null.SetNullString(dr["FaqCategoryDescription"]);
			_level = Null.SetNullInteger(dr["Level"]);
			_viewOrder = Null.SetNullInteger(dr["ViewOrder"]);
		}

		public int KeyID
		{
			get { return _faqCategoryId; }
			set { _faqCategoryId = value; }
		}

		#endregion
	}
}

