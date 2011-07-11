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
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace DotNetNuke.Modules.FAQs
{
	
	/// <summary>
	/// Main controller class for FAQs
	/// </summary>
	[DNNtc.BusinessControllerClass()]
	public class FAQsController : ISearchable, IPortable
	{
		#region Public FAQ Methods
		
		/// <summary>
		/// Gets the FAQ.
		/// </summary>
		/// <param name="faqId">The FAQ id.</param>
		/// <param name="moduleId">The module id.</param>
		/// <returns>FAQInfo object</returns>
		public FAQsInfo GetFAQ(int faqId, int moduleId)
		{
			return ((FAQsInfo) (CBO.FillObject(DataProvider.Instance().GetFAQ(faqId, moduleId), typeof(FAQsInfo))));
		}
		
		/// <summary>
		/// Lists the FAQ.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <param name="orderBy">The order by.</param>
		/// <returns>Arrarylist of FAQs</returns>
		public ArrayList ListFAQ(int moduleID, int orderBy)
		{
			return SearchFAQList(moduleID, orderBy);
		}
		
		/// <summary>
		/// Lists the FAQ without order.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <returns>Array list of FAQ unordered</returns>
		public ArrayList ListFAQWithoutOrder(int moduleID)
		{
			return SearchFAQList(moduleID, 0);
		}
		
		/// <summary>
		/// Adds the FAQ.
		/// </summary>
		/// <param name="obj">The FAQInfo obj.</param>
		/// <returns></returns>
		public int AddFAQ(FAQsInfo obj)
		{
			return Convert.ToInt32(DataProvider.Instance().AddFAQ(obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.CreatedDate, obj.DateModified, 0));
		}
		
		/// <summary>
		/// Updates the FAQ.
		/// </summary>
		/// <param name="obj">FAQsinfo object</param>
		public void UpdateFAQ(FAQsInfo obj)
		{
			DataProvider.Instance().UpdateFAQ(obj.ItemId, obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.DateModified);
		}
		
		/// <summary>
		/// Deletes the FAQ.
		/// </summary>
		/// <param name="faqId">The FAQ id.</param>
		/// <param name="moduleId">The module id.</param>
		public void DeleteFAQ(int faqId, int moduleId)
		{
			DataProvider.Instance().DeleteFAQ(faqId, moduleId);
		}
		
		/// <summary>
		/// Increments the view count.
		/// </summary>
		/// <param name="faqId">The FAQ id.</param>
		public void IncrementViewCount(int faqId)
		{
			DataProvider.Instance().IncrementViewCount(faqId);
		}
		
		/// <summary>
		/// Searches the FAQ list.
		/// </summary>
		/// <param name="moduleId">The module id.</param>
		/// <param name="orderBy">The order by.</param>
		/// <returns>FAQList with relevant searched </returns>
		public ArrayList SearchFAQList(int moduleId, int orderBy)
		{
			ArrayList FaqList = CBO.FillCollection(DataProvider.Instance().SearchFAQList(moduleId, orderBy), typeof(FAQsInfo));
			
			for (int i = 0; i <= FaqList.Count - 1; i++)
			{
				((FAQsInfo) (FaqList[i])).Index = i + 1;
			}
			return FaqList;
		}
		
		#endregion
		
		#region Public Category Methods

		/// <summary>
		/// Gets the category.
		/// </summary>
		/// <param name="faqCategoryId">The FAQ category id.</param>
		/// <param name="moduleId">The module id.</param>
		/// <returns>Category info object</returns>
		public CategoryInfo GetCategory(int faqCategoryId, int moduleId)
		{
			return ((CategoryInfo) (CBO.FillObject(DataProvider.Instance().GetCategory(faqCategoryId, moduleId), typeof(CategoryInfo))));
		}
		
		/// <summary>
		/// Lists the categories.
		/// </summary>
		/// <param name="moduleId">The module id.</param>
		/// <returns></returns>
		public ArrayList ListCategories(int moduleId)
		{
			return CBO.FillCollection(DataProvider.Instance().ListCategory(moduleId), typeof(CategoryInfo));
		}
		
		/// <summary>
		/// Adds the category.
		/// </summary>
		/// <param name="objCategory">The obj category.</param>
		/// <returns></returns>
		public int AddCategory(CategoryInfo objCategory)
		{
			return System.Convert.ToInt32(DataProvider.Instance().AddCategory(objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription));
		}
		
		/// <summary>
		/// Updates the category.
		/// </summary>
		/// <param name="objCategory">The obj category.</param>
		public void UpdateCategory(CategoryInfo objCategory)
		{
			DataProvider.Instance().UpdateCategory(objCategory.FaqCategoryId, objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription);
		}
		
		public void DeleteCategory(int faqCategoryId)
		{
			DataProvider.Instance().DeleteCategory(faqCategoryId);
		}
		#endregion
		
		#region Optional Interfaces

		/// <summary>
		/// Gets the search items.
		/// </summary>
		/// <param name="modInfo">The mod info.</param>
		/// <returns>Collection of SearchItems</returns>
		public SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
		{
			SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
			ArrayList FAQs = ListFAQWithoutOrder(Convert.ToInt32(modInfo.ModuleID));
			
			foreach (object objFaq in FAQs)
			{
				SearchItemInfo SearchItem;
				FAQsInfo faq = ((FAQsInfo) objFaq);
				int UserId = Null.NullInteger;
				int.TryParse(faq.CreatedByUser, out UserId);
				
				string strContent = System.Web.HttpUtility.HtmlDecode(faq.Question + " " + faq.Answer);
				string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(faq.Question), false), 100, "...");
				
				SearchItem = new SearchItemInfo(modInfo.ModuleTitle, strDescription, UserId, faq.CreatedDate, modInfo.ModuleID, faq.ItemId.ToString(), strContent);
				SearchItemCollection.Add(SearchItem);
			}
			return SearchItemCollection;
		}
		
		/// <summary>
		/// Exports the module.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <returns>XML output</returns>
		public string ExportModule(int moduleID)
		{
			string strXML = "";
			ArrayList arrFAQs = ListFAQWithoutOrder(moduleID);
			ArrayList arrCats = ListCategories(moduleID);
			
			strXML += "<faqs>";
			if (arrCats.Count != 0)
			{
				foreach (CategoryInfo objCats in arrCats)
				{
					strXML += "<faq>";
					strXML += "<question></question>";
					strXML += "<answer></answer>";
					strXML += "<catname>" + XmlUtils.XMLEncode(objCats.FaqCategoryName) + "</catname>";
					strXML += "<catdescription>" + XmlUtils.XMLEncode(objCats.FaqCategoryDescription) + "</catdescription>";
					strXML += "<creationdate></creationdate>";
					strXML += "<datemodified></datemodified>";
					strXML += "</faq>";
				}
			}
			
			if (arrFAQs.Count != 0)
			{
				
				foreach (FAQsInfo objFAQs in arrFAQs)
				{
					strXML += "<faq>";
					strXML += "<question>" + XmlUtils.XMLEncode(objFAQs.Question) + "</question>";
					strXML += "<answer>" + XmlUtils.XMLEncode(objFAQs.Answer) + "</answer>";
					strXML += "<catname>" + XmlUtils.XMLEncode(objFAQs.FaqCategoryName) + "</catname>";
					strXML += "<catdescription>" + XmlUtils.XMLEncode(objFAQs.FaqCategoryDescription) + "</catdescription>";
					strXML += "<creationdate>" + XmlUtils.XMLEncode(objFAQs.CreatedDate.ToString()) + "</creationdate>";
					strXML += "<datemodified>" + XmlUtils.XMLEncode(objFAQs.DateModified.ToString()) + "</datemodified>";
					strXML += "</faq>";
				}
			}
			strXML += "</faqs>";
			strXML = FormatXml(strXML);
			
			return strXML;
		}
		private string FormatXml(string sUnformattedXml)
		{
			//load unformatted xml into a dom
			XmlDocument xd = new XmlDocument();
			xd.LoadXml(sUnformattedXml);
			
			//will hold formatted xml
			StringBuilder sb = new StringBuilder();
			
			//pumps the formatted xml into the StringBuilder above
			StringWriter sw = new StringWriter(sb);
			
			//does the formatting
			XmlTextWriter xtw = null;
			
			try
			{
				//point the xtw at the StringWriter
				xtw = new XmlTextWriter(sw);
				
				//we want the output formatted
				xtw.Formatting = Formatting.Indented;
				
				//get the dom to dump its contents into the xtw
				xd.WriteTo(xtw);
			}
			finally
			{
				//clean up even if error
				if (xtw != null)
					xtw.Close();
			}
			
			//return the formatted xml
			return sb.ToString();
		}
		
		/// <summary>
		/// Imports the module.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <param name="content">The content.</param>
		/// <param name="version">The version.</param>
		/// <param name="userId">The user id.</param>
		public void ImportModule(int moduleID, string content, string version, int userId)
		{
			ArrayList catNames = new ArrayList();
			ArrayList Question = new ArrayList();
			XmlNode xmlFaq;
			XmlNode xmlFaqs = Globals.GetContent(content, "faqs");
			
			//' check if category exists. if not create category
			foreach (XmlNode tempLoopVar_xmlFAQ in xmlFaqs)
			{
				xmlFaq = tempLoopVar_xmlFAQ;
				if ((xmlFaq["catname"].InnerText != Null.NullString) && (! catNames.Contains(xmlFaq["catname"].InnerText)))
				{
					catNames.Add(xmlFaq["catname"].InnerText);
					
					CategoryInfo objCat = new CategoryInfo();
					objCat.ModuleId = moduleID;
					objCat.FaqCategoryName = xmlFaq["catname"].InnerText;
					objCat.FaqCategoryDescription = xmlFaq["catdescription"].InnerText;
					
					AddCategory(objCat);
				}
			}
			// check is question is empty. if empty is category.
			foreach (XmlNode tempLoopVar_xmlFAQ in xmlFaqs)
			{
				xmlFaq = tempLoopVar_xmlFAQ;
				
				if (xmlFaq["question"].InnerText != Null.NullString && xmlFaq["question"].InnerText != string.Empty)
				{
					FAQsInfo objFAQs = new FAQsInfo();
					objFAQs.ModuleId = moduleID;
					objFAQs.Question = xmlFaq["question"].InnerText;
					objFAQs.Answer = xmlFaq["answer"].InnerText;
					objFAQs.FaqCategoryName = xmlFaq["catname"].InnerText;
					objFAQs.FaqCategoryDescription = xmlFaq["catdescription"].InnerText;
					
					// Check if creationdate exists in export, if nothing set current date. else import
					if (xmlFaq["creationdate"] == null)
					{
						objFAQs.CreatedDate = DateTime.Now;
						objFAQs.DateModified = DateTime.Now;
					}
					else
					{
						objFAQs.CreatedDate = DateTime.Parse(xmlFaq["creationdate"].InnerText);
						objFAQs.DateModified = DateTime.Parse(xmlFaq["datemodified"].InnerText);
					}
					objFAQs.CreatedByUser = userId.ToString();
					
					bool foundCat = false;
					foreach (CategoryInfo objCat in ListCategories(moduleID))
					{
						if (objFAQs.FaqCategoryName == objCat.FaqCategoryName)
						{
							objFAQs.CategoryId = objCat.FaqCategoryId;
							foundCat = true;
							break;
						}
					}
					
					if (!foundCat)
					{
						objFAQs.CategoryId = Null.NullInteger;
					}
					
					AddFAQ(objFAQs);
				}
			}
			
		}
		
		#endregion
		
		#region Helper Methods
		
		/// <summary>
		/// Processes the tokens.
		/// </summary>
		/// <param name="faqItem">The FAQ item.</param>
		/// <param name="template">The template.</param>
		/// <returns>Answers in which all tokens are processed</returns>
		public string ProcessTokens(FAQsInfo faqItem, string template)
		{
			StringBuilder answer = new StringBuilder(template);
			
			// All replaces are repeated for the old token formats
			answer.Replace("[FAQ:ANSWER]", faqItem.Answer);
			answer.Replace("[ANSWER]", faqItem.Answer);
			
			answer.Replace("[FAQ:CATEGORYNAME]", faqItem.FaqCategoryName);
			answer.Replace("[CATEGORYNAME]", faqItem.FaqCategoryName);
			
			answer.Replace("[FAQ:CATEGORYDESC]", faqItem.FaqCategoryDescription);
			answer.Replace("[CATEGORYDESC]", faqItem.FaqCategoryDescription);
			
			answer.Replace("[FAQ:USER]", faqItem.CreatedByUserName);
			answer.Replace("[USER]", faqItem.CreatedByUserName);
			
			answer.Replace("[FAQ:VIEWCOUNT]", faqItem.ViewCount.ToString());
			answer.Replace("[VIEWCOUNT]", faqItem.ViewCount.ToString());
			
			answer.Replace("[FAQ:DATECREATED]", faqItem.CreatedDate.ToShortDateString());
			answer.Replace("[DATECREATED]", faqItem.CreatedDate.ToShortDateString());
			
			answer.Replace("[FAQ:DATEMODIFIED]", faqItem.DateModified.ToShortDateString());
			answer.Replace("[DATEMODIFIED]", faqItem.DateModified.ToShortDateString());
			
			answer.Replace("[FAQ:QUESTION]", faqItem.Question);
			answer.Replace("[QUESTION]", faqItem.Question);
			
			answer.Replace("[FAQ:INDEX]", faqItem.Index.ToString());
			answer.Replace("[INDEX]", faqItem.Index.ToString());
			
			return answer.ToString();
		}
		
		#endregion
	}
	
}

