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
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports DotNetNuke.Common
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace DotNetNuke.Modules.FAQs

    <DNNtc.ModuleControlProperties("Categories", "Edit Categories", DNNtc.ControlType.Edit, "http://www.dotnetnuke.com/default.aspx?tabid=892", False)> _
    Partial Class FAQsCategories
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


#End Region

#Region "Private Methods"

        Private Sub BindData()
            Dim FAQsController As New FAQsController
            lstCategory.DataSource = FAQsController.ListCategories(ModuleId)
            lstCategory.DataBind()
        End Sub

#End Region

#Region "Event Handlers"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If Page.IsPostBack = False Then
                    BindData()
                    rowFaqCategoryId.Visible = False
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub lstCategory_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles lstCategory.ItemCreated

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                CType(e.Item.FindControl("btnDeleteCategory"), ImageButton).Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If

        End Sub

        Private Sub lstCategory_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstCategory.ItemCommand

            Dim FaqCategoryId As Integer = CType(lstCategory.DataKeys(e.Item.ItemIndex), Integer)
            Dim FAQsController As New FAQsController

            Select Case e.CommandName.ToLower()

                Case "edit"
                    panelAddEdit.Visible = True
                    rowFaqCategoryId.Visible = True
                    Dim CategoryItem As CategoryInfo = FAQsController.GetCategory(FaqCategoryId, ModuleId)
                    txtCategoryName.Text = CategoryItem.FaqCategoryName
                    txtCategoryDescription.Text = CategoryItem.FaqCategoryDescription
                    lblId.Text = CategoryItem.FaqCategoryId.ToString()

                Case "delete"
                    FAQsController.DeleteCategory(FaqCategoryId)
                    Response.Redirect(Request.RawUrl)

            End Select

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            panelAddEdit.Visible = False
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

            Dim FAQsController As New FAQsController
            Dim CategoryItem As New CategoryInfo

            CategoryItem.FaqCategoryName = txtCategoryName.Text
            CategoryItem.FaqCategoryDescription = txtCategoryDescription.Text
            CategoryItem.ModuleId = ModuleId

            Try

                If Not Null.IsNull(lblId.Text) Then
                    CategoryItem.FaqCategoryId = Integer.Parse(lblId.Text)
                    FAQsController.UpdateCategory(CategoryItem)
                Else
                    FAQsController.AddCategory(CategoryItem)
                End If

                Response.Redirect(Request.RawUrl)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try


        End Sub

        Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click

            panelAddEdit.Visible = True
            lblId.Text = ""
            rowFaqCategoryId.Visible = False
            txtCategoryDescription.Text = ""
            txtCategoryName.Text = ""

        End Sub

        Private Sub cmdGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGoBack.Click
            Response.Redirect(NavigateURL())
        End Sub

#End Region

    End Class

End Namespace