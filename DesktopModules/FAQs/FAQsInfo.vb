'
' DotNetNuke� - http://www.dotnetnuke.com
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

    Public Class FAQsInfo

#Region "Private Members"
        Private _itemId As Integer
        Private _moduleId As Integer
        Private _categoryId As Integer
        Private _question As String
        Private _answer As String
        Private _createdByUser As String
        Private _createdByUserName As String
        Private _createdDate As DateTime
        Private _dateModified As DateTime
        Private _viewCount As Integer
        Private _faqCategoryName As String
        Private _faqCategoryDescription As String
        Private _index As Integer
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub

        Public Sub New(ByVal itemId As Integer, ByVal moduleId As Integer, ByVal categoryId As Integer, ByVal questionTitle As String, ByVal question As String, ByVal answer As String, ByVal createdByUser As String, ByVal createdDate As DateTime, ByVal dateModified As DateTime, ByVal viewCount As Integer)
            Me.ItemId = itemId
            Me.ModuleId = moduleId
            Me.CategoryId = categoryId

            Me.Question = question
            Me.Answer = answer
            Me.CreatedByUser = createdByUser
            Me.CreatedDate = createdDate
            Me.DateModified = dateModified
            Me.ViewCount = viewCount
        End Sub
#End Region

#Region "Public Properties"

        Public Property ItemId() As Integer
            Get
                Return _itemId
            End Get
            Set(ByVal Value As Integer)
                _itemId = Value
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

        Public Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal Value As Integer)
                _moduleId = Value
            End Set
        End Property

        Public Property CategoryId() As Integer
            Get
                Return _categoryId
            End Get
            Set(ByVal Value As Integer)
                _categoryId = Value
            End Set
        End Property

        Public Property Question() As String
            Get
                Return _question
            End Get
            Set(ByVal Value As String)
                _question = Value
            End Set
        End Property

        Public Property Answer() As String
            Get
                Return _answer
            End Get
            Set(ByVal Value As String)
                _answer = Value
            End Set
        End Property

        Public Property CreatedByUser() As String
            Get
                Return _createdByUser
            End Get
            Set(ByVal Value As String)
                _createdByUser = Value
            End Set
        End Property

        Public Property CreatedByUserName() As String
            Get
                Return _createdByUserName
            End Get
            Set(ByVal Value As String)
                _createdByUserName = Value
            End Set
        End Property

        Public Property CreatedDate() As DateTime
            Get
                Return _createdDate
            End Get
            Set(ByVal Value As DateTime)
                _createdDate = Value
            End Set
        End Property

        Public Property DateModified() As DateTime
            Get
                Return _dateModified
            End Get
            Set(ByVal Value As DateTime)
                _dateModified = Value
            End Set
        End Property

        Public Property ViewCount() As Integer
            Get
                Return _viewCount
            End Get
            Set(ByVal Value As Integer)
                _viewCount = Value
            End Set
        End Property

        Public Property Index() As Integer
            Get
                Return _index
            End Get
            Set(ByVal Value As Integer)
                _index = Value
            End Set
        End Property

#End Region

    End Class

End Namespace