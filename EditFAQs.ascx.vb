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
Imports System.Web.UI.WebControls
Imports DotNetNuke.Common
Imports DotNetNuke.UI.UserControls
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Security

Namespace DotNetNuke.Modules.FAQs

    <DNNtc.ModuleControlProperties("Edit", "Edit FAQs", DNNtc.ControlType.Edit, "http://www.dotnetnuke.com/default.aspx?tabid=892", False)> _
    Public Class EditFAQs
        Inherits PortalModuleBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Members"

        Protected txtQuestionField As TextBox
        Protected teAnswerField As TextEditor
        Protected ctlAudit As ModuleAuditControl
#End Region

#Region "Properties"
        Public ReadOnly Property FaqId() As Integer
            Get
                If Not Null.IsNull(Request.QueryString("ItemId")) Then
                    Try
                        Return CInt(Request.QueryString("ItemId"))
                    Catch exc As Exception 'Module failed to load
                        ProcessModuleLoadException(Me, exc)
                    End Try
                Else
                    Return Null.NullInteger
                End If

            End Get
        End Property
#End Region

#Region "Private Methods"

        ''' <summary>
        ''' Populates the categories drop down.
        ''' </summary>
        Private Sub PopulateCategoriesDropDown()
            Dim FAQsController As New FAQsController

            For Each category As CategoryInfo In FAQsController.ListCategories(ModuleId)
                drpCategory.Items.Add(New ListItem(category.FaqCategoryName, category.FaqCategoryId.ToString()))
            Next
        End Sub

#End Region

#Region "Event Handlers"

        ''' <summary>
        ''' Handles the Load event of the Page control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Page.IsPostBack = False Then

                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")

                Dim FAQsController As New FAQsController

                PopulateCategoriesDropDown()

                If Not Null.IsNull(FaqId) Then

                    Dim FaqItem As FAQsInfo = FAQsController.GetFAQ(FaqId, ModuleId)

                    If Not FaqItem Is Nothing Then

                        If Not Null.IsNull(FaqItem.CategoryId) Then
                            drpCategory.SelectedValue = FaqItem.CategoryId.ToString()
                        End If

                        teAnswerField.Text = FaqItem.Answer
                        txtQuestionField.Text = FaqItem.Question

                        ctlAudit.CreatedByUser = FaqItem.CreatedByUserName
                        If FaqItem.DateModified = Null.NullDate Then
                            ctlAudit.CreatedDate = FaqItem.CreatedDate.ToString()
                        Else
                            ctlAudit.CreatedDate = FaqItem.DateModified.ToString()
                        End If
                    Else
                        Response.Redirect(NavigateURL(), True)
                    End If

                Else
                    cmdDelete.Visible = False
                    ctlAudit.Visible = False
                End If

            End If

        End Sub

        ''' <summary>
        ''' Handles the Click event of the cmdUpdate control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

            Try
                Dim FAQsController As New FAQsController
                Dim objSecurity As New PortalSecurity

                Dim FAQsInfo As New FAQsInfo

                With FAQsInfo
                    .ItemId = FaqId
                    .CategoryId = CInt(drpCategory.SelectedValue.ToString())

                    ' We do not allow for script or markup in the question
                    .Question = objSecurity.InputFilter(txtQuestionField.Text, PortalSecurity.FilterFlag.NoScripting Or PortalSecurity.FilterFlag.NoMarkup)
                    .Answer = objSecurity.InputFilter(teAnswerField.Text, PortalSecurity.FilterFlag.NoScripting Or PortalSecurity.FilterFlag.NoMarkup)

                    .CreatedByUser = UserId.ToString()
                    .ViewCount = 0
                    .CreatedDate = DateTime.Now
                    .DateModified = DateTime.Now
                    .ModuleId = ModuleId
                End With

                ' Do we add of update? The Id will tell us
                If FaqId <> -1 Then
                    FAQsController.UpdateFAQ(FAQsInfo)
                Else
                    FAQsController.AddFAQ(FAQsInfo)
                End If

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        ''' <summary>
        ''' Handles the Click event of the cmdCancel control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' <summary>
        ''' Handles the Click event of the cmdDelete control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                Dim FAQsController As New FAQsController
                FAQsController.DeleteFAQ(FaqId, ModuleId)
                Response.Redirect(DotNetNuke.Common.NavigateURL())
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class

End Namespace