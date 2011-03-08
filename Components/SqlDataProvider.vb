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
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data
Imports DotNetNuke.Framework.Providers

Namespace DotNetNuke.Modules.FAQs

    Public Class SqlDataProvider
        Inherits DataProvider


#Region "Private Members"

        Private Const ProviderType As String = "data"

        Private _providerConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType)
        Private _connectionString As String
        Private _providerPath As String
        Private _objectQualifier As String
        Private _databaseOwner As String

#End Region

#Region "Constructors"

        Public Sub New()

            ' Read the configuration specific information for this provider
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)

            ' This code handles getting the connection string from either the connectionString / appsetting section and uses the connectionstring section by default if it exists.  
            ' Get Connection string from web.config
            _connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString()

            ' If above funtion does not return anything then connectionString must be set in the dataprovider section.
            If _connectionString = "" Then
                ' Use connection string specified in provider
                _connectionString = objProvider.Attributes("connectionString")
            End If

            _providerPath = objProvider.Attributes("providerPath")

            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
                _databaseOwner += "."
            End If

        End Sub

#End Region

#Region "Properties"

        Public ReadOnly Property ConnectionString() As String
            Get
                Return _connectionString
            End Get
        End Property

        Public ReadOnly Property ProviderPath() As String
            Get
                Return _providerPath
            End Get
        End Property

        Public ReadOnly Property ObjectQualifier() As String
            Get
                Return _objectQualifier
            End Get
        End Property

        Public ReadOnly Property DatabaseOwner() As String
            Get
                Return _databaseOwner
            End Get
        End Property

#End Region

#Region "FAQ Methods"
        Public Overrides Function GetFAQ(ByVal faqId As Integer, ByVal moduleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQGet", faqId, moduleId), IDataReader)
        End Function

        Public Overrides Function ListFAQ(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQList", ModuleId), IDataReader)
        End Function

        Public Overrides Function AddFAQ(ByVal moduleId As Integer, ByVal categoryId As Integer, ByVal question As String, ByVal answer As String, ByVal createdByUser As String, ByVal dateAdded As DateTime, ByVal dateModified As DateTime, ByVal viewCount As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQAdd", moduleId, categoryId, question, answer, createdByUser, dateAdded, dateModified, viewCount), Integer)
        End Function

        Public Overrides Sub UpdateFAQ(ByVal faqId As Integer, ByVal moduleId As Integer, ByVal categoryId As Integer, ByVal question As String, ByVal answer As String, ByVal createdByUser As String, ByVal dateModified As DateTime)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQUpdate", faqId, moduleId, categoryId, question, answer, createdByUser, dateModified)
        End Sub

        Public Overrides Sub DeleteFAQ(ByVal faqId As Integer, ByVal moduleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQDelete", faqId, moduleId)
        End Sub

        Public Overrides Function SearchFAQList(ByVal ModuleId As Integer, ByVal OrderBy As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQSearch", ModuleId, OrderBy), IDataReader)
        End Function

#End Region

#Region "Category Methods"
        Public Overrides Function GetCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQCategoryGet", faqCategoryId, moduleId), IDataReader)
        End Function

        Public Overrides Function ListCategory(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQCategoryList", ModuleId), IDataReader)
        End Function

        Public Overrides Function AddCategory(ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQCategoryAdd", moduleId, faqCategoryName, faqCategoryDescription), Integer)
        End Function

        Public Overrides Sub UpdateCategory(ByVal faqCategoryId As Integer, ByVal moduleId As Integer, ByVal faqCategoryName As String, ByVal faqCategoryDescription As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQCategoryUpdate", faqCategoryId, moduleId, faqCategoryName, faqCategoryDescription)
        End Sub

        Public Overrides Sub DeleteCategory(ByVal faqCategoryId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQCategoryDelete", faqCategoryId)
        End Sub


        Public Overrides Sub IncrementViewCount(ByVal faqId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "FAQIncrementViewCount", faqId)
        End Sub


#End Region

    End Class

End Namespace