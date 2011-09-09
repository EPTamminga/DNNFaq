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
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;

namespace DotNetNuke.Modules.FAQs
{
	
	[DNNtc.ModuleControlProperties("Edit", "Edit FAQs", DNNtc.ControlType.Edit, "http://www.dotnetnuke.com/default.aspx?tabid=892", false)]
	public partial class EditFAQs : PortalModuleBase
	{
			
		#region Members
		
		protected TextBox txtQuestionField;
		protected TextEditor teAnswerField;
		protected ModuleAuditControl ctlAudit;
		
		#endregion
		
		#region Properties
		
		public int FaqId
		{
			get
			{
				if (! Null.IsNull(Request.QueryString["ItemId"]))
				{
					try
					{
						return System.Convert.ToInt32(Request.QueryString["ItemId"]);
					}
					catch (Exception exc) //Module failed to load
					{
						Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				else
				{
					return Null.NullInteger;
				}
				
				return 0;
			}
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Populates the categories drop down.
		/// </summary>
		private void PopulateCategoriesDropDown()
		{
			FAQsController FAQsController = new FAQsController();
			
			foreach (CategoryInfo category in FAQsController.ListCategories(ModuleId,false))
			{
				drpCategory.Items.Add(new ListItem(category.FaqCategoryName, category.FaqCategoryId.ToString()));
			}
		}
		
		#endregion
		
		#region Event Handlers
		
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void Page_Load(System.Object sender, System.EventArgs e)
		{
			
			if (Page.IsPostBack == false)
			{
				
				cmdDelete.Attributes.Add("onClick", "javascript:return confirm(\'" + Localization.GetString("DeleteItem") + "\');");
				
				FAQsController FAQsController = new FAQsController();
				
				PopulateCategoriesDropDown();
				
				if (! Null.IsNull(FaqId))
				{
					
					FAQsInfo FaqItem = FAQsController.GetFAQ(FaqId, ModuleId);
					
					if (FaqItem != null)
					{
						
						if (! Null.IsNull(FaqItem.CategoryId))
						{
							drpCategory.SelectedValue = FaqItem.CategoryId.ToString();
						}
						
						teAnswerField.Text = FaqItem.Answer;
						txtQuestionField.Text = FaqItem.Question;
						
						ctlAudit.CreatedByUser = FaqItem.CreatedByUserName;
						if (FaqItem.DateModified == Null.NullDate)
						{
							ctlAudit.CreatedDate = FaqItem.CreatedDate.ToString();
						}
						else
						{
							ctlAudit.CreatedDate = FaqItem.DateModified.ToString();
						}
					}
					else
					{
						Response.Redirect(Globals.NavigateURL(), true);
					}
					
				}
				else
				{
					cmdDelete.Visible = false;
					ctlAudit.Visible = false;
				}
				
			}
			
		}
		
		/// <summary>
		/// Handles the Click event of the cmdUpdate control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdUpdate_Click(System.Object sender, System.EventArgs e)
		{
			
			try
			{
				FAQsController FAQsController = new FAQsController();
				PortalSecurity objSecurity = new PortalSecurity();
				
				FAQsInfo FAQsInfo = new FAQsInfo();
				
				FAQsInfo.ItemId = FaqId;
				FAQsInfo.CategoryId = int.Parse(drpCategory.SelectedValue.ToString());
				
				// We do not allow for script or markup in the question
				FAQsInfo.Question = objSecurity.InputFilter(txtQuestionField.Text, PortalSecurity.FilterFlag.NoScripting | PortalSecurity.FilterFlag.NoMarkup);
				FAQsInfo.Answer = objSecurity.InputFilter(teAnswerField.Text, PortalSecurity.FilterFlag.NoScripting);
				
				FAQsInfo.CreatedByUser = UserId.ToString();
				FAQsInfo.ViewCount = 0;
				FAQsInfo.CreatedDate = DateTime.Now;
				FAQsInfo.DateModified = DateTime.Now;
				FAQsInfo.ModuleId = ModuleId;
				
				// Do we add of update? The Id will tell us
				if (FaqId != -1)
				{
					FAQsController.UpdateFAQ(FAQsInfo);
				}
				else
				{
					FAQsController.AddFAQ(FAQsInfo);
				}
				
				Response.Redirect(Globals.NavigateURL(), true);
				
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
			
		}
		
		/// <summary>
		/// Handles the Click event of the cmdCancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdCancel_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				Response.Redirect(Globals.NavigateURL(), true);
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}
		
		/// <summary>
		/// Handles the Click event of the cmdDelete control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdDelete_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				FAQsController FAQsController = new FAQsController();
				FAQsController.DeleteFAQ(FaqId, ModuleId);
				Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}
		
		#endregion
		
	}
	
}
