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
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;

namespace DotNetNuke.Modules.FAQs
{
	[DNNtc.ModuleControlProperties("EditCategories", "Edit FAQ Categories", DNNtc.ControlType.Edit, "http://www.dotnetnuke.com/default.aspx?tabid=892", false)]
	partial class FAQsCategories : PortalModuleBase
	{
		#region Event Handlers

		///// <summary>
		///// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
		///// </summary>
		///// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		//protected override void OnInit(EventArgs e)
		//{
		//    base.OnInit(e);
		//    this.Load += this.Page_Load;
		//    this.cmdAddNew.Click += this.cmdAddNew_Click;
		//    this.cmdUpdate.Click += this.cmdUpdate_Click;
		//    this.cmdGoBack.Click += this.cmdGoBack_Click;
		//    this.cmdCancel.Click += this.cmdCancel_Click;
		//}

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsPostBack == false)
				{
					BindData();
					rowFaqCategoryId.Visible = false;
				}
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		/// <summary>
		/// Handles the ItemCreated event of the lstCategory control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs" /> instance containing the event data.</param>
		protected void lstCategory_ItemCreated(object sender, DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				((ImageButton)(e.Item.FindControl("btnDeleteCategory"))).Attributes.Add("onClick", "javascript:return confirm(\'" + Localization.GetString("DeleteItem") + "\');");
			}
		}

		/// <summary>
		/// Handles the ItemCommand event of the lstCategory control.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.DataListCommandEventArgs" /> instance containing the event data.</param>
		protected void lstCategory_ItemCommand(object source, DataListCommandEventArgs e)
		{

			int faqCategoryId = System.Convert.ToInt32(lstCategory.DataKeys[e.Item.ItemIndex]);
			FAQsController faqsController = new FAQsController();

			switch (e.CommandName.ToLower())
			{

				case "edit":
					panelAddEdit.Visible = true;
					rowFaqCategoryId.Visible = true;
					PopulateCategoriesDropDown(faqCategoryId);
					CategoryInfo categoryItem = faqsController.GetCategory(faqCategoryId, ModuleId);
					int parentCategoryId = categoryItem.FaqCategoryParentId;
					if (parentCategoryId == 0)
						parentCategoryId = -1;
					drpParentCategory.SelectedValue = parentCategoryId.ToString();
					txtCategoryName.Text = categoryItem.FaqCategoryName;
					txtCategoryDescription.Text = categoryItem.FaqCategoryDescription;
					lblId.Text = categoryItem.FaqCategoryId.ToString();
					break;

				case "delete":
					faqsController.DeleteCategory(faqCategoryId);
					Response.Redirect(Request.RawUrl);
					break;
			}
		}


		/// <summary>
		/// Handles the Click event of the cmdCancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdCancel_Click(System.Object sender, System.EventArgs e)
		{
			panelAddEdit.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the cmdUpdate control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdUpdate_Click(Object sender, EventArgs e)
		{

			FAQsController faqsController = new FAQsController();
			CategoryInfo categoryItem = new CategoryInfo();
			PortalSecurity objSecurity = new PortalSecurity();

			int parentCategoryId = Convert.ToInt32(drpParentCategory.SelectedValue);
			if (parentCategoryId < 0) 
				parentCategoryId = 0;

			// We do not allow for script or markup
			categoryItem.FaqCategoryParentId = parentCategoryId;
			categoryItem.FaqCategoryName = objSecurity.InputFilter(txtCategoryName.Text, PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);
			categoryItem.FaqCategoryDescription = objSecurity.InputFilter(txtCategoryDescription.Text, PortalSecurity.FilterFlag.NoScripting | PortalSecurity.FilterFlag.NoMarkup);
			categoryItem.ModuleId = ModuleId;

			try
			{
				if (!Null.IsNull(lblId.Text))
				{
					categoryItem.FaqCategoryId = int.Parse(lblId.Text);
					faqsController.UpdateCategory(categoryItem);
				}
				else
				{
					faqsController.AddCategory(categoryItem);
				}

				Response.Redirect(Request.RawUrl);
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		/// <summary>
		/// Handles the Click event of the cmdAddNew control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdAddNew_Click(Object sender, EventArgs e)
		{
			panelAddEdit.Visible = true;
			lblId.Text = "";
			rowFaqCategoryId.Visible = false;
			txtCategoryDescription.Text = "";
			txtCategoryName.Text = "";
			PopulateCategoriesDropDown(-1);
		}

		/// <summary>
		/// Handles the Click event of the cmdGoBack control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void cmdGoBack_Click(Object sender, EventArgs e)
		{
			Response.Redirect(Globals.NavigateURL());
		}

		#endregion

		#region Private Methods

		private void BindData()
		{
			FAQsController FAQsController = new FAQsController();
			lstCategory.DataSource = FAQsController.ListCategories(ModuleId,false);
			lstCategory.DataBind();
		}

		/// <summary>
		/// Populates the (Parent-)categories drop down.
		/// </summary>
		private void PopulateCategoriesDropDown(int faqCategoryId)
		{
			drpParentCategory.Items.Clear();
			drpParentCategory.Items.Add(new ListItem(Localization.GetString("SelectParentCategory.Text",this.LocalResourceFile), "-1"));
			FAQsController FAQsController = new FAQsController();
			foreach (CategoryInfo category in FAQsController.ListCategories(ModuleId, false))
			{
				if (faqCategoryId != category.FaqCategoryId)
					drpParentCategory.Items.Add(new ListItem(category.FaqCategoryName, category.FaqCategoryId.ToString()));
			}
		}
		#endregion
	}
}
