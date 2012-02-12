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
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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
		public ArrayList ListFAQ(int moduleID, int orderBy, bool showHidden)
		{
			return SearchFAQList(moduleID, orderBy, showHidden);
		}
		
		/// <summary>
		/// Lists the FAQ without order.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <returns>Array list of FAQ unordered</returns>
		public ArrayList ListFAQWithoutOrder(int moduleID)
		{
			return SearchFAQList(moduleID, 0,true);
		}
		
		/// <summary>
		/// Adds the FAQ.
		/// </summary>
		/// <param name="obj">The FAQInfo obj.</param>
		/// <returns></returns>
		public int AddFAQ(FAQsInfo obj)
		{
			return Convert.ToInt32(DataProvider.Instance().AddFAQ(obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.CreatedDate, obj.DateModified, 0, obj.ViewOrder, obj.FaqHide, obj.PublishDate, obj.ExpireDate));
		}
		
		/// <summary>
		/// Updates the FAQ.
		/// </summary>
		/// <param name="obj">FAQsinfo object</param>
		public void UpdateFAQ(FAQsInfo obj)
		{
			DataProvider.Instance().UpdateFAQ(obj.ItemId, obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.DateModified, obj.ViewOrder, obj.FaqHide, obj.PublishDate, obj.ExpireDate);
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
		/// Reorders the FAQ.
		/// </summary>
		public void ReorderFAQ(int faqId1, int faqId2, int moduleId)
		{
			DataProvider.Instance().ReorderFAQ(faqId1, faqId2, moduleId);
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
		public ArrayList SearchFAQList(int moduleId, int orderBy, bool showHidden)
		{
			ArrayList FaqList = CBO.FillCollection(DataProvider.Instance().SearchFAQList(moduleId, orderBy, showHidden), typeof(FAQsInfo));
			
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
		/// <param name="onlyUsedCategories">true if only categories are returned that are used in Faq's</param>
		/// <returns></returns>
		public ArrayList ListCategories(int moduleId, bool onlyUsedCategories)
		{
			return CBO.FillCollection(DataProvider.Instance().ListCategories(moduleId, onlyUsedCategories), typeof(CategoryInfo));
		}

		/// <summary>
		/// Lists the categories hierarchical (additional level info, sorted).
		/// </summary>
		/// <param name="moduleId">The module id.</param>
		/// <param name="onlyUsedCategories">true if only categories are returned that are used in Faq's</param>
		/// <returns></returns>
		public ArrayList ListCategoriesHierarchical(int moduleId, bool onlyUsedCategories)
		{
			return CBO.FillCollection(DataProvider.Instance().ListCategoriesHierarchical(moduleId, onlyUsedCategories), typeof(CategoryInfo));
		}

		/// <summary>
		/// Adds the category.
		/// </summary>
		/// <param name="objCategory">The obj category.</param>
		/// <returns></returns>
		public int AddCategory(CategoryInfo objCategory)
		{
			return System.Convert.ToInt32(DataProvider.Instance().AddCategory(objCategory.ModuleId, objCategory.FaqCategoryParentId,objCategory.FaqCategoryName, objCategory.FaqCategoryDescription, objCategory.ViewOrder));
		}
		
		/// <summary>
		/// Updates the category.
		/// </summary>
		/// <param name="objCategory">The obj category.</param>
		public void UpdateCategory(CategoryInfo objCategory)
		{
			DataProvider.Instance().UpdateCategory(objCategory.FaqCategoryId, objCategory.ModuleId, objCategory.FaqCategoryParentId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription, objCategory.ViewOrder);
		}
		
		public void DeleteCategory(int faqCategoryId)
		{
			DataProvider.Instance().DeleteCategory(faqCategoryId);
		}

		public void ReorderCategory(int faqParentCategoryId, int moduleId)
		{
			DataProvider.Instance().ReorderCategory(faqParentCategoryId, moduleId);
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
			var searchItemCollection = new SearchItemInfoCollection();
			var FAQs = ListFAQWithoutOrder(Convert.ToInt32(modInfo.ModuleID));
			
			foreach (object objFaq in FAQs)
			{
			    var faq = ((FAQsInfo) objFaq);
				if (faq.FaqHide)
					continue;

				int UserId = Null.NullInteger;
				int.TryParse(faq.CreatedByUser, out UserId);
				
				string strContent = System.Web.HttpUtility.HtmlDecode(faq.Question + " " + faq.Answer);
				string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(faq.Question), false), 100, "...");
				string guid = String.Format("faqid={0}", faq.ItemId);
				
				var searchItem = new SearchItemInfo(modInfo.ModuleTitle, strDescription, UserId, 
					faq.CreatedDate, modInfo.ModuleID, faq.ItemId.ToString(), strContent,guid);
				searchItemCollection.Add(searchItem);
			}
			return searchItemCollection;
		}
		
		/// <summary>
		/// Exports the module.
		/// </summary>
		/// <param name="moduleID">The module ID.</param>
		/// <returns>XML output</returns>
		public string ExportModule(int moduleID)
		{
			ArrayList arrCats = ListCategoriesHierarchical(moduleID, false);
			var categorys = new XElement("categories", from CategoryInfo cat in arrCats
													   select new XElement("cat",
														   new XElement("categoryid", cat.FaqCategoryId),
														   new XElement("categoryparentid", cat.FaqCategoryParentId),
														   new XElement("categoryname", new XCData(cat.FaqCategoryName)),
														   new XElement("categorydescription", new XCData(cat.FaqCategoryDescription)),
														   new XElement("vieworder", cat.ViewOrder)));
	
			ArrayList arrFAQs = ListFAQWithoutOrder(moduleID);
			var faqs = new XElement("faqs", from FAQsInfo faq in arrFAQs
											select new XElement("faq",
												new XElement("question", new XCData(faq.Question)),
												new XElement("answer", new XCData(faq.Answer)),
												new XElement("categoryid", faq.CategoryId),
												new XElement("creationdate", faq.CreatedDate),
												new XElement("datemodified", faq.DateModified),
												new XElement("faqhide", faq.FaqHide),
												new XElement("publishdate", faq.PublishDate),
												new XElement("expiredate", faq.ExpireDate),
												new XElement("vieworder", faq.ViewOrder)));



			XElement root = new XElement("Root");
			root.Add(faqs);
			root.Add(categorys);
			return root.ToString();
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
			Version vers = new Version(version);
			if (vers > new Version("5.0.0"))
			{
				XElement xRoot = XElement.Parse(content);
				Dictionary<int, int> idTrans = new Dictionary<int, int>();

				// First we import the categories
				List<CategoryInfo> lstCategories = new List<CategoryInfo>();
				XElement xCategories = xRoot.Element("categories");
				foreach (var xCategory in xCategories.Elements())
				{
					// translate the parentid's to new values
					int oldParentId = Int32.Parse(xCategory.Element("categoryparentid").Value, CultureInfo.InvariantCulture);
					int newParentId = 0;
					if (oldParentId > 0 && idTrans.ContainsKey(oldParentId))
						newParentId = idTrans[oldParentId];
					
					// Fill category properties
					CategoryInfo category = new CategoryInfo();
					category.ModuleId = moduleID;
					category.FaqCategoryParentId = newParentId;
					category.FaqCategoryName = xCategory.Element("categoryname").Value;
					category.FaqCategoryDescription = xCategory.Element("categorydescription").Value;
					category.ViewOrder = Int32.Parse(xCategory.Element("vieworder").Value, CultureInfo.InvariantCulture);

					// add category and save old and new id to translation dictionary
					int oldCategoryId = Int32.Parse(xCategory.Element("categoryid").Value, CultureInfo.InvariantCulture);
					int newCategoryId = AddCategory(category);
					idTrans.Add(oldCategoryId,newCategoryId);
				}

				// Next import the faqs
				List<FAQsInfo> lstFaqs = new List<FAQsInfo>();
				XElement xFaqs = xRoot.Element("faqs");
				foreach (var xFaq in xFaqs.Elements())
				{
					// translate id with help of translation dictionary build before
					int oldCategoryId = Int32.Parse(xFaq.Element("categoryid").Value, CultureInfo.InvariantCulture);
					int newCategoryId = -1;
					if (idTrans.ContainsKey(oldCategoryId))
						newCategoryId = idTrans[oldCategoryId];
					
					// Fill FAQs properties
					FAQsInfo faq = new FAQsInfo();
					faq.ModuleId = moduleID;
					faq.Question = xFaq.Element("question").Value;
					faq.Answer = xFaq.Element("answer").Value;
					faq.CategoryId = newCategoryId;
					faq.CreatedDate = DateTime.Parse(xFaq.Element("creationdate").Value);
					faq.DateModified = DateTime.Now;
					faq.FaqHide = Boolean.Parse(xFaq.Element("faqhide").Value);
					faq.PublishDate = DateTime.Parse(xFaq.Element("publishdate").Value);
					faq.ExpireDate = DateTime.Parse(xFaq.Element("expiredate").Value);
					
					// Add Faq to database
					AddFAQ(faq);
				}
			}
			else
			{
				ArrayList catNames = new ArrayList();
				ArrayList Question = new ArrayList();
				XmlNode xmlFaq;
				XmlNode xmlFaqs = Globals.GetContent(content, "faqs");

				//' check if category exists. if not create category
				foreach (XmlNode tempLoopVar_xmlFAQ in xmlFaqs)
				{
					xmlFaq = tempLoopVar_xmlFAQ;
					if ((xmlFaq["catname"].InnerText != Null.NullString) && (!catNames.Contains(xmlFaq["catname"].InnerText)))
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
				int loop = 0;
				foreach (XmlNode tempLoopVar_xmlFAQ in xmlFaqs)
				{
					loop++;
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

						if (xmlFaq["vieworder"] != null)
						{
							objFAQs.ViewOrder = int.Parse(xmlFaq["vieworder"].InnerText);
						}
						else
						{
							objFAQs.ViewOrder = loop;
						}
						objFAQs.CreatedByUser = userId.ToString();

						bool foundCat = false;
						foreach (CategoryInfo objCat in ListCategories(moduleID, false))
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
			// For compability issues we need to convert old tokens to new tokens (sigh...)
			StringBuilder compatibleTemplate = new StringBuilder(template);
			compatibleTemplate.Replace("[ANSWER]", "[FAQ:ANSWER]");
			compatibleTemplate.Replace("[CATEGORYNAME]", "[FAQ:CATEGORYNAME]");
			compatibleTemplate.Replace("[CATEGORYDESC]", "[FAQ:CATEGORYDESC]");
			compatibleTemplate.Replace("[USER]", "[FAQ:USER]");
			compatibleTemplate.Replace("[VIEWCOUNT]", "[FAQ:VIEWCOUNT]");
			compatibleTemplate.Replace("[DATECREATED]", "[FAQ:DATECREATED]");
			compatibleTemplate.Replace("[DATEMODIFIED]", "[FAQ:DATEMODIFIED]");
			compatibleTemplate.Replace("[QUESTION]", "[FAQ:QUESTION]");
			compatibleTemplate.Replace("[INDEX]", "[FAQ:INDEX]");

			// Now we can call TokenReplace
			FAQsTokenReplace tokenReplace = new FAQsTokenReplace(faqItem);
			return tokenReplace.ReplaceFAQsTokens(template);
		}
		
		#endregion
	}
	
}

