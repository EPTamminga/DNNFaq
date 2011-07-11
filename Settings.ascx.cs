using System;
using System.Web.UI.HtmlControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
//using DotNetNuke.Services.Exceptions.Exceptions;

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
	[DNNtc.ModuleControlProperties("Settings", "FAQ Settings", DNNtc.ControlType.Admin, "http://www.dotnetnuke.com/default.aspx?tabid=892", true)]
	public partial class Settings : ModuleSettingsBase
	{
		
		#region Members
		
		protected HtmlTable tblHTMLTemplates;
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Loads the settings.
		/// </summary>
		public override void LoadSettings()
		{
			
			try
			{
				
				if (! Null.IsNull(Settings["ShowCategories"]))
				{
					chkShowCatagories.Checked = Convert.ToBoolean(Settings["ShowCategories"]);
				}
				else
				{
					chkShowCatagories.Checked = false;
				}
				
				if (! Null.IsNull(Settings["FaqQuestionTemplate"]))
				{
					txtQuestionTemplate.Text = Convert.ToString(Settings["FaqQuestionTemplate"]);
				}
				else
				{
					txtQuestionTemplate.Text = Localization.GetString("DefaultQuestionTemplate", this.LocalResourceFile);
				}
				
				if (! Null.IsNull(Settings["FaqAnswerTemplate"]))
				{
					txtAnswerTemplate.Text = Convert.ToString(Settings["FaqAnswerTemplate"]);
				}
				else
				{
					txtAnswerTemplate.Text = Localization.GetString("DefaultAnswerTemplate", this.LocalResourceFile);
				}
				
				if (! Null.IsNull(Settings["FaqLoadingTemplate"]))
				{
					txtLoadingTemplate.Text = Convert.ToString(Settings["FaqLoadingTemplate"]);
				}
				else
				{
					txtLoadingTemplate.Text = Localization.GetString("DefaultLoadingTemplate", this.LocalResourceFile);
				}
				
				if (! Null.IsNull(Settings["FaqDefaultSorting"]))
				{
					drpDefaultSorting.SelectedValue = Convert.ToString(Settings["FaqDefaultSorting"]);
				}
				
			}
			catch (Exception exc) //Module failed to load
			{
				DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
			}
			
		}
		
		/// <summary>
		/// Updates the settings.
		/// </summary>
		public override void UpdateSettings()
		{
			
			try
			{
				
				ModuleController modController = new ModuleController();
				
				modController.UpdateModuleSetting(ModuleId, "ShowCategories", chkShowCatagories.Checked.ToString());
				modController.UpdateModuleSetting(ModuleId, "FaqQuestionTemplate", txtQuestionTemplate.Text);
				modController.UpdateModuleSetting(ModuleId, "FaqAnswerTemplate", txtAnswerTemplate.Text);
				modController.UpdateModuleSetting(ModuleId, "FaqLoadingTemplate", txtLoadingTemplate.Text);
				modController.UpdateModuleSetting(ModuleId, "FaqDefaultSorting", drpDefaultSorting.SelectedValue.ToString());
				
			}
			catch (Exception exc) //Module failed to load
			{
				DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
			}
			
		}
		
		#endregion
		
	}
	
}