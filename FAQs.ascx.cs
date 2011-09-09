using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
//using DotNetNuke.Services.Exceptions.Exceptions;
using Telerik.Web.UI;

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


namespace DotNetNuke.Modules.FAQs
{
	[DNNtc.ModuleDependencies(DNNtc.ModuleDependency.CoreVersion, "05.06.01")]
	[DNNtc.ModuleControlProperties("", "FAQ", DNNtc.ControlType.View, "http://www.dotnetnuke.com/default.aspx?tabid=892", true)]
	public partial class FAQs : PortalModuleBase, IActionable, IClientAPICallbackEventHandler
	{
		
		#region Members
		
		private bool SupportsClientAPI = false;
		private bool _isFiltered = false;
	
		#endregion
		
		#region Properties
		
		public int DefaultSorting
		{
			get
			{
				int retVal = 6;
				if (! Null.IsNull(Settings["FaqDefaultSorting"]) && !IsEditable)
				{
					try
					{
						retVal = System.Convert.ToInt32(Settings["FaqDefaultSorting"]);
					}
					catch (Exception exc)
					{
						DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				return retVal;
			}
		}

		public int UserSorting
		{
			get
			{
				if (ViewState["UserSorting"] == null)
					return DefaultSorting;
				else
					return (int) ViewState["UserSorting"];
			}

			set { ViewState["UserSorting"] = value; }
		}

		public int ShowCategoryType
		{
			get
			{
				if (!Null.IsNull(Settings["ShowCategoryType"]))
				{
					try
					{
						return System.Convert.ToInt32(Settings["ShowCategoryType"]);
					}
					catch (Exception exc)
					{
						DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				else
				{
					return 0;
				}
				return 0;
			}
		}

		public bool ShowToolTips
		{
			get
			{
				if (!Null.IsNull(Settings["ShowToolTips"]))
				{
					try
					{
						return Convert.ToBoolean(Settings["ShowToolTips"]);
					}
					catch (Exception exc)
					{
						DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				else
				{
					return false;
				}
				return false;
			}
		}

		public bool IsMovable
		{
			get { return IsEditable && UserSorting == 6 && FaqData.Count > 1 && !_isFiltered; }
		}
		
		/// <summary>
		/// Gets the local resource file from the settings.
		/// </summary>
		/// <value>The local resource file for settings.ascx</value>
		public string LocalResourceFileSettings
		{
			get
			{
				return this.TemplateSourceDirectory + "/" + DotNetNuke.Services.Localization.Localization.LocalResourceDirectory + "/Settings";
			}
		}
		
		/// <summary>
		/// Gets the answer template.
		/// </summary>
		/// <value>The answer template.</value>
		public string AnswerTemplate
		{
			get
			{
				if (! Null.IsNull(Settings["FaqAnswerTemplate"]))
				{
					return Settings["FaqAnswerTemplate"].ToString();
				}
				else
				{
					// Get the resource fromt he settings resources if not set yet
					return Localization.GetString("DefaultAnswerTemplate", this.LocalResourceFileSettings);
				}
			}
		}
		
		/// <summary>
		/// Gets the question template.
		/// </summary>
		/// <value>The question template.</value>
		public string QuestionTemplate
		{
			get
			{
				if (! Null.IsNull(Settings["FaqQuestionTemplate"]))
				{
					return Settings["FaqQuestionTemplate"].ToString();
				}
				else
				{
					// Get the resource fromt he settings resources if not set yet
					return Localization.GetString("DefaultQuestionTemplate", this.LocalResourceFileSettings);
				}
			}
		}
		
		/// <summary>
		/// Gets the loading template.
		/// </summary>
		/// <value>The loading template.</value>
		public string LoadingTemplate
		{
			get
			{
				if (! Null.IsNull(Settings["FaqLoadingTemplate"]))
				{
					return Settings["FaqLoadingTemplate"].ToString();
				}
				else
				{
					// Get the resource fromt he settings resources if not set yet
					return Localization.GetString("DefaultLoadingTemplate", this.LocalResourceFileSettings);
				}
			}
		}
		
		/// <summary>
		/// Gets the module actions.
		/// </summary>
		/// <value>The module actions.</value>
		public ModuleActionCollection ModuleActions
		{
			get
			{
				DotNetNuke.Entities.Modules.Actions.ModuleActionCollection actions = new DotNetNuke.Entities.Modules.Actions.ModuleActionCollection();
				actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, Security.SecurityAccessLevel.Edit, true, false);
				actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditCategories"), false, Security.SecurityAccessLevel.Edit, true, false);
				
				return actions;
				
			}
		}
		
		private ArrayList FaqData
		{
			get
			{
				if (ViewState["FaqData"] == null)
				{
					FAQsController FAQsController = new FAQsController();
					ArrayList fData = FAQsController.ListFAQ(ModuleId, UserSorting);
					ViewState["FaqData"] = fData;
					return fData;
				}
				else
				{
					return ((ArrayList) (ViewState["FaqData"]));
				}
			}
			set
			{
				ViewState["FaqData"] = value;
			}
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Binds the (filtered) faq data.
		/// </summary>
		private void BindData()
		{
			
			//Get the complete array of FAQ items
			ArrayList filterData = new ArrayList();

			if (Convert.ToBoolean(Settings["ShowCategories"]))
			{
				//Filter
				foreach (FAQsInfo item in FaqData)
				{
					if (MatchElement(item))
					{
						filterData.Add(item);
					}
				}
			}
			else
			{
				filterData = FaqData;
			}

			_isFiltered = (filterData.Count != FaqData.Count);
			//Bind Data
			lstFAQs.DataSource = filterData;
			lstFAQs.DataBind();
			
		}
		
		/// <summary>
		/// Binds the categories.
		/// </summary>
		private void BindCategories()
		{
			//Show the categories ?
			if (Convert.ToBoolean(Settings["ShowCategories"]))
			{
				// Do we have unassigned categories ?
				bool noCat = false;
				foreach (FAQsInfo faq in FaqData)
				{
					if (faq.CategoryId == -1)
					{
						noCat = true;
						break;
					}
				}
				pnlShowCategories.Visible = true;

				//Build the Catagories List.
				FAQsController FAQsController = new FAQsController();
				ArrayList categories = new ArrayList();

				//Empty Category
				CategoryInfo emptyCategory = new CategoryInfo();
				emptyCategory.FaqCategoryId = -1;
				emptyCategory.FaqCategoryName = Localization.GetString("EmptyCategory", LocalResourceFile);

				//All Categories
				CategoryInfo allCategories = new CategoryInfo();
				allCategories.FaqCategoryId = -2;
				allCategories.FaqCategoryName = Localization.GetString("AllCategory", LocalResourceFile);
				

				switch (ShowCategoryType)
				{
					case 0:
						if (noCat)
							categories.Add(emptyCategory);
						categories.AddRange(FAQsController.ListCategories(ModuleId,true));
						listCategories.DataSource = categories;
						listCategories.DataBind();
						mvShowCategoryType.SetActiveView(vShowCategoryTypeList);
						pnlShowCategoryTypeDropdown.Visible = false;
						break;

					case 1:
						categories.Add(allCategories);
						if (noCat)
							categories.Add(emptyCategory);
						categories.AddRange(FAQsController.ListCategories(ModuleId,true));
						List<CategoryInfo> lst = new List<CategoryInfo>();
						foreach (CategoryInfo cat in categories)
						{
							lst.Add(cat);
						}
						treeCategories.DataTextField = "FaqCategoryName";
						treeCategories.DataFieldID = "FaqCategoryId";
						treeCategories.DataFieldParentID = "FaqCategoryParentId";
						treeCategories.DataSource = lst;
						treeCategories.DataBind();
						if (!IsPostBack)
							treeCategories.Nodes[0].Selected = true;
						mvShowCategoryType.SetActiveView(vShowCategoryTypeTree);
						pnlShowCategoryTypeDropdown.Visible = false;
						break;
					case 2:
						categories.Add(allCategories);
						if (noCat)
							categories.Add(emptyCategory);
						categories.AddRange(FAQsController.ListCategories(ModuleId, true));
						foreach (CategoryInfo cat in categories)
						{
							drpCategories.Items.Add(new ListItem(cat.FaqCategoryName,cat.FaqCategoryId.ToString()));
						}
						if (!IsPostBack)
							drpCategories.SelectedIndex = 0;
						pnlShowCategoryTypeDropdown.Visible = true;
						pnlShowCategories.Visible = false;
						pnlSortbox.Style.Add("float", "right");
						pnlSortbox.Style.Add("text-align", "right");
						break;
				}
			}
			else
			{
				pnlShowCategories.Visible = false;
			}
		}
		
		/// <summary>
		/// Determines if the element matches the filter input.
		/// </summary>
		private bool MatchElement(FAQsInfo fData)
		{
			
			bool match = false;
			bool noneChecked = true;

			switch (ShowCategoryType)
			{
				case 0:
					//Filter on the checked items
					foreach (RadListBoxItem item in listCategories.Items)
					{

						//Get the checkbox in the Control
						CheckBox chkCategory = (CheckBox) (item.FindControl("chkCategory"));

						//If checked the faq module is being filtered on one or more category's
						if (chkCategory.Checked)
						{

							//Set Checked Flag
							noneChecked = false;

							//Get the filtered catagory
							string category = chkCategory.Text;

							//Get the elements that match the catagory
							if ((fData.FaqCategoryName == category) ||
							    (fData.CategoryId < 0 && category == Localization.GetString("EmptyCategory", LocalResourceFile)))
							{
								match = true;
							}
						}
					}
					break;
				case 1:
					if (treeCategories.SelectedNode != null)
					{
						noneChecked = (treeCategories.SelectedNode.Text == Localization.GetString("AllCategory", LocalResourceFile));
						if (treeCategories.SelectedNode.Text == fData.FaqCategoryName ||
								(fData.CategoryId < 0 && treeCategories.SelectedNode.Text == Localization.GetString("EmptyCategory", LocalResourceFile)))
						{
							match = true;
							break;
						}
					}
					break;
				case 2:
					if (drpCategories.SelectedValue != null)
					{
						noneChecked = (drpCategories.SelectedItem.Text == Localization.GetString("AllCategory", LocalResourceFile));
						if (drpCategories.SelectedItem.Text == fData.FaqCategoryName ||
								(fData.CategoryId < 0 && drpCategories.SelectedItem.Text == Localization.GetString("EmptyCategory", LocalResourceFile)))
						{
							match = true;
							break;
						}
					}
					break;
			}
			
			if (noneChecked)
			{
				return true;
			}
			
			return match;
			
		}
		
		/// <summary>
		/// Increments the view count.
		/// </summary>
		/// <param name="FaqId">The FAQ id.</param>
		private void IncrementViewCount(int FaqId)
		{
			FAQsController objFAQs = new FAQsController();
			objFAQs.IncrementViewCount(FaqId);
			
		}
		
		#endregion	
		
		#region Public Methods
		
		/// <summary>
		/// HTMLs the decode.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <returns></returns>
		public string HtmlDecode(string strValue)
		{
			try
			{
				return Server.HtmlDecode(strValue);
			}
			catch (Exception exc) //Module failed to load
			{
				DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
			}
			
			return "";
			
		}
		
		/// <summary>
		/// Raises the client API callback event.
		/// </summary>
		/// <param name="eventArgument">The event argument.</param>
		/// <returns></returns>
		public string RaiseClientAPICallbackEvent(string eventArgument)
		{
			
			try
			{
				int FaqId = int.Parse(eventArgument);
				FAQsController objFAQs = new FAQsController();
				
				IncrementViewCount(FaqId);
				
				FAQsInfo FaqItem = objFAQs.GetFAQ(FaqId, ModuleId);
				
				return HtmlDecode(objFAQs.ProcessTokens(FaqItem, this.AnswerTemplate));
				
			}
			catch (Exception exc)
			{
				DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
			}
			
			return "";
			
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
			
			try
			{
				if (ClientAPI.BrowserSupportsFunctionality(ClientAPI.ClientFunctionality.XMLHTTP) && ClientAPI.BrowserSupportsFunctionality(ClientAPI.ClientFunctionality.XML))
				{
					SupportsClientAPI = true;
					ClientAPI.RegisterClientReference(this.Page, ClientAPI.ClientNamespaceReferences.dnn_xml);
					ClientAPI.RegisterClientReference(this.Page, ClientAPI.ClientNamespaceReferences.dnn_xmlhttp);
					
					if (this.Page.ClientScript.IsClientScriptBlockRegistered("AjaxFaq.js") == false)
					{
						this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AjaxFaq.js", "<script language=javascript src=\"" + this.ControlPath + "scripts\\AjaxFaq.js\"></script>");
					}
				}

				if (! IsPostBack)
				{
					//Fill the categories panel
					BindCategories();
					
					//Bind the FAQ data
					BindData();

					//Is the user allowed to sort the questions ?
					if (Settings["UserSort"] != null && Convert.ToBoolean(Settings["UserSort"]))
					{
						//Set default sort order
						pnlSortbox.Visible = true;
						drpSort.SelectedValue = DefaultSorting.ToString();
					}
					else
					{
						pnlSortbox.Visible = false;
					}
				}
				
			}
			catch (Exception exc) //Module failed to load
			{
				DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
			}
			
		}
		
		/// <summary>
		/// Handles the ItemDataBound event of the lstFAQs control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs" /> instance containing the event data.</param>
		protected void lstFAQs_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if (SupportsClientAPI) //// AJAX Mode
				{
					try
					{
						
						HtmlAnchor linkQuestion = (HtmlAnchor) (e.Item.FindControl("Q2"));
						Label lblAnswer = (Label) (e.Item.FindControl("A2"));
						
						FAQsInfo FaqItem = (FAQsInfo) e.Item.DataItem;
						linkQuestion.InnerHtml = HtmlDecode(new FAQsController().ProcessTokens(FaqItem, this.QuestionTemplate));
						
						((LinkButton) (e.Item.FindControl("lnkQ2"))).Visible = false;
						
						//// Utilize the ClientAPI to create ajax request
						string ClientCallBackRef = ClientAPI.GetCallbackEventReference(this, (string) (System.Web.UI.DataBinder.Eval(e.Item.DataItem, "ItemId").ToString()), "GetFaqAnswerSuccess", "\'" + lblAnswer.ClientID + "\'", "GetFaqAnswerError");
						
						string AjaxJavaScript = "javascript: var label = document.getElementById(\'" + lblAnswer.ClientID.ToString() + "\');" + "if (label.innerHTML == \'\') { label.innerHTML = \'" + HtmlDecode(this.LoadingTemplate) + "\'; " + ClientCallBackRef + " } " + "else { label.innerHTML = \'\'; }";
						
						linkQuestion.Attributes.Add("onClick", AjaxJavaScript);
						
						
					}
					catch (Exception exc) //Module failed to load
					{
						DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				else //// Postback Mode
				{
					try
					{
						
						FAQsInfo FaqItem = (FAQsInfo) e.Item.DataItem;
						LinkButton linkQuestion = (LinkButton) (e.Item.FindControl("lnkQ2"));
						linkQuestion.Text = HtmlDecode(new FAQsController().ProcessTokens(FaqItem, this.QuestionTemplate));
						((HtmlAnchor) (e.Item.FindControl("Q2"))).Visible = false;
						
					}
					catch (Exception exc) //Module failed to load
					{
						DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
					}
				}
				
			}
		}
		
		/// <summary>
		/// Handles the Select event of the lstFAQs control.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.DataListCommandEventArgs" /> instance containing the event data.</param>
		protected void lstFAQs_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			FAQsController controller = new FAQsController();
			int itemId = System.Convert.ToInt32(e.CommandArgument);
			int index = e.Item.ItemIndex;
			int itemCount = FaqData.Count;

			switch (e.CommandName.ToLower())
			{
				case "select":
					if (!SupportsClientAPI)
					{
						try
						{
							Label lblAnswer = (Label) (lstFAQs.Items[index].FindControl("A2"));
							FAQsInfo FaqItem = controller.GetFAQ(itemId, ModuleId);

							if (lblAnswer.Text == "")
							{
								IncrementViewCount(FaqItem.ItemId);
								lblAnswer.Text = HtmlDecode(controller.ProcessTokens(FaqItem, this.AnswerTemplate));
							}
							else
							{
								lblAnswer.Text = "";
							}

						}
						catch (Exception exc) //Module failed to load
						{
							DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
						}
					}
					break;
				case "up":
					if (index == 0)
						controller.ReorderFAQ(itemId, ((FAQsInfo)FaqData[itemCount-1]).ItemId, ModuleId);
					else
						controller.ReorderFAQ(itemId, ((FAQsInfo)FaqData[index - 1]).ItemId, ModuleId);
					FaqData = null;
					BindData();
					break;
				case "down":
					if (index == itemCount -1)
						controller.ReorderFAQ(itemId, ((FAQsInfo)FaqData[0]).ItemId, ModuleId);
					else
						controller.ReorderFAQ(itemId, ((FAQsInfo)FaqData[index + 1]).ItemId, ModuleId);
					//Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
					FaqData = null;
					BindData();
					break;
			}
		}
		
		/// <summary>
		/// Handles the CheckedChanged event of the Category controls.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected void chkCategory_CheckedChanged(object sender, EventArgs e)
		{
			//Rebind Data
			BindData();
		}

		/// <summary>
		/// Handles the ItemDataBound event of the listCategories control (adds Tooltip)
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">instance containing the event data.</param>
		protected void listCategories_ItemDataBound(object sender, RadListBoxItemEventArgs e)
		{
			if (ShowToolTips)
				e.Item.ToolTip = (string)DataBinder.Eval(e.Item.DataItem, "FaqCategoryDescription");
		}

		/// <summary>
		/// Handles the NodeClick event of the treeCategories control (rebinds data)
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">instance containing the event data.</param>
		protected void treeCategories_NodeClick(object sender, EventArgs e)
		{
			//Rebind Data
			BindData();
		}

		/// <summary>
		/// Handles the NodeDataBound event of the treeCategories control (adds Tooltip)
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">instance containing the event data.</param>
		protected void treeCategories_NodeDataBound(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
		{
			if (ShowToolTips)
				e.Node.ToolTip =  (string)DataBinder.Eval(e.Node.DataItem, "FaqCategoryDescription") ;
		}

		protected void drpCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Rebind Data
			BindData();
		}

		protected void drpSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Rebind Data
			UserSorting = Convert.ToInt32(drpSort.SelectedValue);
			FaqData = null;
			BindData();
		}

		#endregion
		
	}
	
}

