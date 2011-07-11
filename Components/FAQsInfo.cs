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
	/// Info class for FAQs
	/// </summary>
	[Serializable()]
	public class FAQsInfo:IHydratable
	{
		#region Private Members

		private int _itemId;
		private int _moduleId;
		private int _categoryId;
		private string _question;
		private string _answer;
		private string _createdByUser;
		private string _createdByUserName;
		private DateTime _createdDate;
		private DateTime _dateModified;
		private int _viewCount;
		private string _faqCategoryName;
		private string _faqCategoryDescription;
		private int _index;
		
		#endregion
		
		#region Constructors
		
		public FAQsInfo()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="FAQsInfo" /> class.
		/// </summary>
		/// <param name="itemId">The item id.</param>
		/// <param name="moduleId">The module id.</param>
		/// <param name="categoryId">The category id.</param>
		/// <param name="question">The question.</param>
		/// <param name="answer">The answer.</param>
		/// <param name="createdByUser">The created by user.</param>
		/// <param name="createdDate">The created date.</param>
		/// <param name="dateModified">The date modified.</param>
		/// <param name="viewCount">The view count.</param>
		public FAQsInfo(int itemId, int moduleId, int categoryId, string question, string answer, string createdByUser, DateTime createdDate, DateTime dateModified, int viewCount)
		{
			_itemId = itemId;
			_moduleId = moduleId;
			_categoryId = categoryId;
			_question = question;
			_answer = answer;
			_createdByUser = createdByUser;
			_createdDate = createdDate;
			_dateModified = dateModified;
			_viewCount = viewCount;
			_createdByUserName = "";
			_faqCategoryDescription = "";
			_faqCategoryName = "";
			_index = 0;
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// Gets or sets the item id.
		/// </summary>
		/// <value>The item id.</value>
		public int ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
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
		/// Gets or sets the category id.
		/// </summary>
		/// <value>The category id.</value>
		public int CategoryId
		{
			get
			{
				return _categoryId;
			}
			set
			{
				_categoryId = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the question.
		/// </summary>
		/// <value>The question.</value>
		public string Question
		{
			get
			{
				return _question;
			}
			set
			{
				_question = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the answer.
		/// </summary>
		/// <value>The answer.</value>
		public string Answer
		{
			get
			{
				return _answer;
			}
			set
			{
				_answer = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the created by user.
		/// </summary>
		/// <value>The created by user.</value>
		public string CreatedByUser
		{
			get
			{
				return _createdByUser;
			}
			set
			{
				_createdByUser = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the name of the created by user.
		/// </summary>
		/// <value>The name of the created by user.</value>
		public string CreatedByUserName
		{
			get
			{
				return _createdByUserName;
			}
			set
			{
				_createdByUserName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the created date.
		/// </summary>
		/// <value>The created date.</value>
		public DateTime CreatedDate
		{
			get
			{
				return _createdDate;
			}
			set
			{
				_createdDate = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the date modified.
		/// </summary>
		/// <value>The date modified.</value>
		public DateTime DateModified
		{
			get
			{
				return _dateModified;
			}
			set
			{
				_dateModified = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the view count.
		/// </summary>
		/// <value>The view count.</value>
		public int ViewCount
		{
			get
			{
				return _viewCount;
			}
			set
			{
				_viewCount = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the index.
		/// </summary>
		/// <value>The index.</value>
		public int Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
			}
		}
		
		#endregion

		#region Implementation of IHydratable

		public void Fill(IDataReader dr)
		{
			_itemId = Null.SetNullInteger(dr["ItemId"]);
			_moduleId = Null.SetNullInteger(dr["ModuleId"]);
			_categoryId = Null.SetNullInteger(dr["CategoryId"]);
			_question = Null.SetNullString(dr["Question"]);
			_answer = Null.SetNullString(dr["Answer"]);
			_createdByUserName = Null.SetNullString(dr["CreatedByUserName"]);
			_createdDate = Null.SetNullDateTime(dr["CreatedDate"]);
			_dateModified = Null.SetNullDateTime(dr["DateModified"]);
			_viewCount = Null.SetNullInteger(dr["ViewCount"]);
			_faqCategoryName = Null.SetNullString(dr["FaqCategoryName"]);
			_faqCategoryDescription = Null.SetNullString(dr["FaqCategoryDescription"]);
		}

		public int KeyID
		{
			get { return _itemId; }
			set { _itemId = value; }
		}

		#endregion
	}
	
}

