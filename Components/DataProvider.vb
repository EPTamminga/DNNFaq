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
Imports System.Data

Namespace DotNetNuke.Modules.FAQs

    Public MustInherit Class DataProvider

#Region "Shared/Static Methods"

        ' singleton reference to the instantiated object 
        Private Shared objProvider As DataProvider = Nothing

        ' constructor
        Shared Sub New()
            CreateProvider()
        End Sub

        ' dynamically create provider
        Private Shared Sub CreateProvider()
            objProvider = CType(Framework.Reflection.CreateObject("data", "DotNetNuke.Modules.FAQs", ""), DataProvider)
        End Sub

        ' return the provider
        Public Shared Shadows Function Instance() As DataProvider
            Return objProvider
        End Function

#End Region

#Region "FAQ Methods"
        Public MustOverride Function GetFAQ(ByVal faqId As Integer, ByVal moduleId As Integer) As IDataReader
        Public MustOverride Function ListFAQ(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function AddFAQ(ByVal moduleId As Integer, ByVal categoryId As Integer, ByVal question As String, ByVal answer As String, ByVal createdByUser As String, ByVal dateAdded As DateTime, ByVal dateModified As DateTime, ByVal viewCount As Integer) As Integer
        Public MustOverride Sub UpdateFAQ(ByVal faqId As Integer, ByVal moduleId As Integer, ByVal categoryId As Integer, ByVal question As String, ByVal answer As String, ByVal createdByUser As String, ByVal dateModified As DateTime)
        Public MustOverride Sub DeleteFAQ(ByVal faqId As Integer, ByVal moduleId As Integer)
        Public MustOverride Sub IncrementViewCount(ByVal faqId As Integer)
        Public MustOverride Function SearchFAQList(ByVal ModuleId As Integer, ByVal OrderBy As Integer) As IDataReader
#End Region

#Region "Category Methods"
        Public MustOverride Function GetCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer) As IDataReader
        Public MustOverride Function ListCategory(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function AddCategory(ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String) As Integer
        Public MustOverride Sub UpdateCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String)
        Public MustOverride Sub DeleteCategory(ByVal faqCategoryId As Integer)
#End Region

    End Class

End Namespace