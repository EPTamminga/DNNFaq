'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2011
' by DotNetNuke Corporation
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.XML
Imports System.Text
Imports System.Collections
Imports System.Web.HttpUtility
Imports Microsoft.VisualBasic
Imports DotNetNuke.Common
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Search


Namespace DotNetNuke.Modules.FAQs

    ''' <summary>
    ''' Main controller class for FAQs
    ''' </summary>
    <DNNtc.BusinessControllerClass()> _
    Public Class FAQsController
        Implements ISearchable, IPortable

#Region "Public FAQ Methods"
        ''' <summary>
        ''' Gets the FAQ.
        ''' </summary>
        ''' <param name="faqId">The FAQ id.</param>
        ''' <param name="moduleId">The module id.</param>
        ''' <returns>FAQInfo object</returns>
        Public Function GetFAQ(ByVal faqId As Integer, ByVal moduleId As Integer) As FAQsInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetFAQ(faqId, moduleId), GetType(FAQsInfo)), FAQsInfo)

        End Function

        ''' <summary>
        ''' Lists the FAQ.
        ''' </summary>
        ''' <param name="ModuleID">The module ID.</param>
        ''' <param name="OrderBy">The order by.</param>
        ''' <returns>Arrarylist of FAQs</returns>
        Public Function ListFAQ(ByVal ModuleID As Integer, ByVal OrderBy As Integer) As ArrayList

            Return SearchFAQList(ModuleID, OrderBy)

        End Function

        ''' <summary>
        ''' Lists the FAQ without order.
        ''' </summary>
        ''' <param name="ModuleID">The module ID.</param>
        ''' <returns>Array list of FAQ unordered</returns>
        Public Function ListFAQWithoutOrder(ByVal ModuleID As Integer) As ArrayList

            Return SearchFAQList(ModuleID, 0)

        End Function

        ''' <summary>
        ''' Adds the FAQ.
        ''' </summary>
        ''' <param name="obj">The FAQInfo obj.</param>
        ''' <returns></returns>
        Public Function AddFAQ(ByVal obj As FAQsInfo) As Integer

            Return CType(DataProvider.Instance().AddFAQ(obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.CreatedDate, obj.DateModified, 0), Integer)

        End Function

        ''' <summary>
        ''' Updates the FAQ.
        ''' </summary>
        ''' <param name="obj">FAQsinfo object</param>
        Public Sub UpdateFAQ(ByVal obj As FAQsInfo)

            DataProvider.Instance().UpdateFAQ(obj.ItemId, obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.DateModified)

        End Sub

        ''' <summary>
        ''' Deletes the FAQ.
        ''' </summary>
        ''' <param name="faqId">The FAQ id.</param>
        ''' <param name="moduleId">The module id.</param>
        Public Sub DeleteFAQ(ByVal faqId As Integer, ByVal moduleId As Integer)

            DataProvider.Instance().DeleteFAQ(faqId, moduleId)

        End Sub

        ''' <summary>
        ''' Increments the view count.
        ''' </summary>
        ''' <param name="faqId">The FAQ id.</param>
        Public Sub IncrementViewCount(ByVal faqId As Integer)
            DataProvider.Instance().IncrementViewCount(faqId)
        End Sub

        ''' <summary>
        ''' Searches the FAQ list.
        ''' </summary>
        ''' <param name="ModuleId">The module id.</param>
        ''' <param name="OrderBy">The order by.</param>
        ''' <returns>FAQList with relevant searched </returns>
        Public Function SearchFAQList(ByVal ModuleId As Integer, ByVal OrderBy As Integer) As ArrayList

            Dim FaqList As ArrayList = CBO.FillCollection(DataProvider.Instance().SearchFAQList(ModuleId, OrderBy), GetType(FAQsInfo))

            For i As Integer = 0 To FaqList.Count - 1
                CType(FaqList(i), FAQsInfo).Index = i + 1
            Next i

            Return FaqList

        End Function

#End Region

#Region "Public Category Methods"
        ''' <summary>
        ''' Gets the category.
        ''' </summary>
        ''' <param name="faqCategoryId">The FAQ category id.</param>
        ''' <param name="moduleId">The module id.</param>
        ''' <returns>Category info object</returns>
        Public Function GetCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer) As CategoryInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetCategory(faqCategoryId, moduleId), GetType(CategoryInfo)), CategoryInfo)

        End Function

        ''' <summary>
        ''' Lists the categories.
        ''' </summary>
        ''' <param name="ModuleId">The module id.</param>
        ''' <returns></returns>
        Public Function ListCategories(ByVal ModuleId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().ListCategory(ModuleId), GetType(CategoryInfo))

        End Function

        ''' <summary>
        ''' Adds the category.
        ''' </summary>
        ''' <param name="objCategory">The obj category.</param>
        ''' <returns></returns>
        Public Function AddCategory(ByVal objCategory As CategoryInfo) As Integer

            Return CType(DataProvider.Instance().AddCategory(objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription), Integer)

        End Function

        ''' <summary>
        ''' Updates the category.
        ''' </summary>
        ''' <param name="objCategory">The obj category.</param>
        Public Sub UpdateCategory(ByVal objCategory As CategoryInfo)

            DataProvider.Instance().UpdateCategory(objCategory.FaqCategoryId, objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription)

        End Sub

        Public Sub DeleteCategory(ByVal faqCategoryId As Integer)

            DataProvider.Instance().DeleteCategory(faqCategoryId)

        End Sub
#End Region

#Region "Optional Interfaces"
        ''' <summary>
        ''' Gets the search items.
        ''' </summary>
        ''' <param name="ModInfo">The mod info.</param>
        ''' <returns></returns>
        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            Dim FAQs As ArrayList = ListFAQWithoutOrder(ModInfo.ModuleID)

            Dim objFaq As Object
            For Each objFaq In FAQs
                Dim SearchItem As SearchItemInfo
                With CType(objFaq, FAQsInfo)
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = HtmlDecode(.Question & " " & .Answer)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(HtmlDecode(.Question), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection
        End Function

        ''' <summary>
        ''' Exports the module.
        ''' </summary>
        ''' <param name="ModuleID">The module ID.</param>
        ''' <returns>XML output</returns>
        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim strXML As String = ""
            Dim arrFAQs As ArrayList = ListFAQWithoutOrder(ModuleID)
            If arrFAQs.Count <> 0 Then
                strXML += "<faqs>"
                Dim objFAQs As FAQsInfo
                For Each objFAQs In arrFAQs
                    strXML += "<faq>"
                    strXML += "<question>" & XmlUtils.XMLEncode(objFAQs.Question) & "</question>"
                    strXML += "<answer>" & XmlUtils.XMLEncode(objFAQs.Answer) & "</answer>"
                    strXML += "<catname>" & XmlUtils.XMLEncode(objFAQs.FaqCategoryName) & "</catname>"
                    strXML += "<catdescription>" & XmlUtils.XMLEncode(objFAQs.FaqCategoryDescription) & "</catdescription>"
                    strXML += "<creationdate>" & XmlUtils.XMLEncode(CStr(objFAQs.CreatedDate)) & "</creationdate>"
                    strXML += "<datemodified>" & XmlUtils.XMLEncode(CStr(objFAQs.DateModified)) & "</datemodified>"
                    strXML += "</faq>"
                Next
                strXML += "</faqs>"
            End If

            Return strXML
        End Function

        ''' <summary>
        ''' Imports the module.
        ''' </summary>
        ''' <param name="ModuleID">The module ID.</param>
        ''' <param name="Content">The content.</param>
        ''' <param name="Version">The version.</param>
        ''' <param name="UserId">The user id.</param>
        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim catNames As New ArrayList
            Dim xmlFAQ As XmlNode
            Dim xmlFAQs As XmlNode = GetContent(Content, "faqs")

            For Each xmlFAQ In xmlFAQs
                If (xmlFAQ.Item("catname").InnerText <> Null.NullString) And (Not catNames.Contains(xmlFAQ.Item("catname").InnerText)) Then
                    catNames.Add(xmlFAQ.Item("catname").InnerText)

                    Dim objCat As New CategoryInfo
                    objCat.ModuleId = ModuleID
                    objCat.FaqCategoryName = xmlFAQ.Item("catname").InnerText
                    objCat.FaqCategoryDescription = xmlFAQ.Item("catdescription").InnerText

                    AddCategory(objCat)
                End If
            Next

            For Each xmlFAQ In xmlFAQs
                Dim objFAQs As New FAQsInfo
                objFAQs.ModuleId = ModuleID
                objFAQs.Question = xmlFAQ.Item("question").InnerText
                objFAQs.Answer = xmlFAQ.Item("answer").InnerText
                objFAQs.FaqCategoryName = xmlFAQ.Item("catname").InnerText
                objFAQs.FaqCategoryDescription = xmlFAQ.Item("catdescription").InnerText
                objFAQs.CreatedDate = CDate(xmlFAQ.Item("creationdate").InnerText)
                objFAQs.DateModified = CDate(xmlFAQ.Item("datemodified").InnerText)

                objFAQs.CreatedByUser = UserId.ToString()

                Dim foundCat As Boolean = False
                For Each objCat As CategoryInfo In ListCategories(ModuleID)
                    If (objFAQs.FaqCategoryName = objCat.FaqCategoryName) Then
                        objFAQs.CategoryId = objCat.FaqCategoryId
                        foundCat = True
                        Exit For
                    End If
                Next

                If Not foundCat Then
                    objFAQs.CategoryId = Null.NullInteger
                End If

                AddFAQ(objFAQs)
            Next

        End Sub

#End Region

#Region "Helper Methods"

        ''' <summary>
        ''' Processes the tokens.
        ''' </summary>
        ''' <param name="FaqItem">The FAQ item.</param>
        ''' <param name="Template">The template.</param>
        ''' <returns>Answers in which alkl tokens are processed</returns>
        Public Function ProcessTokens(ByVal FaqItem As FAQsInfo, ByVal Template As String) As String

            Dim Answer As New StringBuilder(Template)

            ' All replaces are repeated for the old token formats
            Answer.Replace("[FAQ:ANSWER]", FaqItem.Answer)
            Answer.Replace("[ANSWER]", FaqItem.Answer)

            Answer.Replace("[FAQ:CATEGORYNAME]", FaqItem.FaqCategoryName)
            Answer.Replace("[CATEGORYNAME]", FaqItem.FaqCategoryName)

            Answer.Replace("[FAQ:CATEGORYDESC]", FaqItem.FaqCategoryDescription)
            Answer.Replace("[CATEGORYDESC]", FaqItem.FaqCategoryDescription)

            Answer.Replace("[FAQ:USER]", FaqItem.CreatedByUserName)
            Answer.Replace("[USER]", FaqItem.CreatedByUserName)

            Answer.Replace("[FAQ:VIEWCOUNT]", FaqItem.ViewCount.ToString())
            Answer.Replace("[VIEWCOUNT]", FaqItem.ViewCount.ToString())

            Answer.Replace("[FAQ:DATECREATED]", FaqItem.CreatedDate.ToShortDateString)
            Answer.Replace("[DATECREATED]", FaqItem.CreatedDate.ToShortDateString)

            Answer.Replace("[FAQ:DATEMODIFIED]", FaqItem.DateModified.ToShortDateString)
            Answer.Replace("[DATEMODIFIED]", FaqItem.DateModified.ToShortDateString)

            Answer.Replace("[FAQ:QUESTION]", FaqItem.Question)
            Answer.Replace("[QUESTION]", FaqItem.Question)

            Answer.Replace("[FAQ:INDEX]", FaqItem.Index.ToString())
            Answer.Replace("[INDEX]", FaqItem.Index.ToString())

            Return Answer.ToString()

        End Function

#End Region

    End Class

End Namespace
