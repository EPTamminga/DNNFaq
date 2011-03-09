'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2006
' by Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
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

    <DNNtc.BusinessControllerClass()> _
    Public Class FAQsController
        Implements ISearchable, IPortable

#Region "Public FAQ Methods"
        Public Function GetFAQ(ByVal faqId As Integer, ByVal moduleId As Integer) As FAQsInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetFAQ(faqId, moduleId), GetType(FAQsInfo)), FAQsInfo)

        End Function

        Public Function ListFAQ(ByVal ModuleID As Integer, ByVal OrderBy As Integer) As ArrayList

            Return SearchFAQList(ModuleID, OrderBy)

        End Function

        Public Function ListFAQWithoutOrder(ByVal ModuleID As Integer) As ArrayList

            Return SearchFAQList(ModuleID, 0)

        End Function

        Public Function AddFAQ(ByVal obj As FAQsInfo) As Integer

            Return CType(DataProvider.Instance().AddFAQ(obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.CreatedDate, obj.DateModified, 0), Integer)

        End Function

        Public Sub UpdateFAQ(ByVal obj As FAQsInfo)

            DataProvider.Instance().UpdateFAQ(obj.ItemId, obj.ModuleId, obj.CategoryId, obj.Question, obj.Answer, obj.CreatedByUser, obj.DateModified)

        End Sub

        Public Sub DeleteFAQ(ByVal faqId As Integer, ByVal moduleId As Integer)

            DataProvider.Instance().DeleteFAQ(faqId, moduleId)

        End Sub

        Public Sub IncrementViewCount(ByVal faqId As Integer)
            DataProvider.Instance().IncrementViewCount(faqId)
        End Sub

        Public Function SearchFAQList(ByVal ModuleId As Integer, ByVal OrderBy As Integer) As ArrayList

            Dim FaqList As ArrayList = CBO.FillCollection(DataProvider.Instance().SearchFAQList(ModuleId, OrderBy), GetType(FAQsInfo))

            For i As Integer = 0 To FaqList.Count - 1
                CType(FaqList(i), FAQsInfo).Index = i + 1
            Next i

            Return FaqList

        End Function

#End Region

#Region "Public Category Methods"
        Public Function GetCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer) As CategoryInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetCategory(faqCategoryId, moduleId), GetType(CategoryInfo)), CategoryInfo)

        End Function

        Public Function ListCategories(ByVal ModuleId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().ListCategory(ModuleId), GetType(CategoryInfo))

        End Function

        Public Function AddCategory(ByVal objCategory As CategoryInfo) As Integer

            Return CType(DataProvider.Instance().AddCategory(objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription), Integer)

        End Function

        Public Sub UpdateCategory(ByVal objCategory As CategoryInfo)

            DataProvider.Instance().UpdateCategory(objCategory.FaqCategoryId, objCategory.ModuleId, objCategory.FaqCategoryName, objCategory.FaqCategoryDescription)

        End Sub

        Public Sub DeleteCategory(ByVal faqCategoryId As Integer)

            DataProvider.Instance().DeleteCategory(faqCategoryId)

        End Sub
#End Region

#Region "Optional Interfaces"
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
                    strXML += "</faq>"
                Next
                strXML += "</faqs>"
            End If

            Return strXML
        End Function

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

                objFAQs.CreatedByUser = UserId.ToString()
                objFAQs.CreatedDate = DateTime.Now
                objFAQs.DateModified = DateTime.Now

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

        Public Function ProcessTokens(ByVal FaqItem As FAQsInfo, ByVal Template As String) As String

            Dim Answer As New StringBuilder(Template)
            Answer.Replace("[ANSWER]", FaqItem.Answer)
            Answer.Replace("[CATEGORYNAME]", FaqItem.FaqCategoryName)
            Answer.Replace("[CATEGORYDESC]", FaqItem.FaqCategoryDescription)
            Answer.Replace("[USER]", FaqItem.CreatedByUserName)
            Answer.Replace("[VIEWCOUNT]", FaqItem.ViewCount.ToString())
            Answer.Replace("[DATECREATED]", FaqItem.CreatedDate.ToShortDateString)
            If Not FaqItem.DateModified = Null.NullDate Then
                Answer.Replace("[DATEMODIFIED]", FaqItem.DateModified.ToShortDateString)
            Else
                Answer.Replace("[DATEMODIFIED]", String.Empty)
            End If
            Answer.Replace("[QUESTION]", FaqItem.Question)
            Answer.Replace("[INDEX]", FaqItem.Index.ToString())
            Return Answer.ToString()

        End Function

#End Region

    End Class

End Namespace
