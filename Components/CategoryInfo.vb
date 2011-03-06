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

Namespace DotNetNuke.Modules.FAQs

    Public Class CategoryInfo

#Region "Private Members"
        Private _faqCategoryId As Integer
        Private _moduleId As Integer
        Private _faqCategoryName As String
        Private _faqCategoryDescription As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub

        Public Sub New(ByVal faqCategoryId As Integer, ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String)
            Me.FaqCategoryId = faqCategoryId
            Me.ModuleId = moduleId
            Me.FaqCategoryName = faqCategoryName
            Me.FaqCategoryDescription = faqCategoryDescription
        End Sub
#End Region

#Region "Public Properties"
        Public Property FaqCategoryId() As Integer
            Get
                Return _faqCategoryId
            End Get
            Set(ByVal Value As Integer)
                _faqCategoryId = Value
            End Set
        End Property

        Public Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal Value As Integer)
                _moduleId = Value
            End Set
        End Property

        Public Property FaqCategoryName() As String
            Get
                Return _faqCategoryName
            End Get
            Set(ByVal Value As String)
                _faqCategoryName = Value
            End Set
        End Property

        Public Property FaqCategoryDescription() As String
            Get
                Return _faqCategoryDescription
            End Get
            Set(ByVal Value As String)
                _faqCategoryDescription = Value
            End Set
        End Property
#End Region

    End Class

End Namespace
