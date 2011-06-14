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

Namespace DotNetNuke.Modules.FAQs

    ''' <summary>
    ''' Main info class for the supporting categories
    ''' </summary>
    <Serializable()>
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

        ''' <summary>
        ''' Initializes a new instance of the <see cref="CategoryInfo" /> class.
        ''' </summary>
        ''' <param name="faqCategoryId">The FAQ category id.</param>
        ''' <param name="moduleId">The module id.</param>
        ''' <param name="faqCategoryName">Name of the FAQ category.</param>
        ''' <param name="faqCategoryDescription">The FAQ category description.</param>
        Public Sub New(ByVal faqCategoryId As Integer, ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String)
            Me.FaqCategoryId = faqCategoryId
            Me.ModuleId = moduleId
            Me.FaqCategoryName = faqCategoryName
            Me.FaqCategoryDescription = faqCategoryDescription
        End Sub
#End Region

#Region "Public Properties"
        ''' <summary>
        ''' Gets or sets the FAQ category id.
        ''' </summary>
        ''' <value>The FAQ category id.</value>
        Public Property FaqCategoryId() As Integer
            Get
                Return _faqCategoryId
            End Get
            Set(ByVal Value As Integer)
                _faqCategoryId = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the module id.
        ''' </summary>
        ''' <value>The module id.</value>
        Public Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal Value As Integer)
                _moduleId = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the name of the FAQ category.
        ''' </summary>
        ''' <value>The name of the FAQ category.</value>
        Public Property FaqCategoryName() As String
            Get
                Return _faqCategoryName
            End Get
            Set(ByVal Value As String)
                _faqCategoryName = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the FAQ category description.
        ''' </summary>
        ''' <value>The FAQ category description.</value>
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
