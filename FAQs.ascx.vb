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
Imports DotNetNuke.UI.Utilities
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Services.Exceptions.Exceptions

Namespace DotNetNuke.Modules.FAQs
    <DNNtc.ModuleDependencies(DNNtc.ModuleDependency.CoreVersion, "05.06.01")> _
    <DNNtc.ModuleControlProperties("", "FAQ", DNNtc.ControlType.View, "http://www.dotnetnuke.com/default.aspx?tabid=892", False)> _
    Partial Class FAQs
        Inherits PortalModuleBase
        Implements IActionable, IClientAPICallbackEventHandler

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

        Private SupportsClientAPI As Boolean = False

#End Region

#Region "Properties"

        Public ReadOnly Property DefaultSorting() As Integer
            Get
                If Not Null.IsNull(Settings("FaqDefaultSorting")) Then
                    Try
                        Return CInt(Settings("FaqDefaultSorting"))
                    Catch exc As Exception
                        ProcessModuleLoadException(Me, exc)
                    End Try
                Else
                    Return 0
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets the local resource file from the settings.
        ''' </summary>
        ''' <value>The local resource file for settings.ascx</value>
        Public ReadOnly Property LocalResourceFileSettings As String
            Get
                Return Me.TemplateSourceDirectory & "/" & DotNetNuke.Services.Localization.Localization.LocalResourceDirectory & "/Settings"
            End Get
        End Property

        ''' <summary>
        ''' Gets the answer template.
        ''' </summary>
        ''' <value>The answer template.</value>
        Public ReadOnly Property AnswerTemplate() As String
            Get
                If Not Null.IsNull(Settings("FaqAnswerTemplate")) Then
                    Return Settings("FaqAnswerTemplate").ToString()
                Else
                    ' Get the resource fromt he settings resources if not set yet
                    Return Localization.GetString("DefaultAnswerTemplate", Me.LocalResourceFileSettings)
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets the question template.
        ''' </summary>
        ''' <value>The question template.</value>
        Public ReadOnly Property QuestionTemplate() As String
            Get
                If Not Null.IsNull(Settings("FaqQuestionTemplate")) Then
                    Return Settings("FaqQuestionTemplate").ToString()
                Else
                    ' Get the resource fromt he settings resources if not set yet
                    Return Localization.GetString("DefaultQuestionTemplate", Me.LocalResourceFileSettings)
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets the loading template.
        ''' </summary>
        ''' <value>The loading template.</value>
        Public ReadOnly Property LoadingTemplate() As String
            Get
                If Not Null.IsNull(Settings("FaqLoadingTemplate")) Then
                    Return Settings("FaqLoadingTemplate").ToString()
                Else
                    ' Get the resource fromt he settings resources if not set yet
                    Return Localization.GetString("DefaultLoadingTemplate", Me.LocalResourceFileSettings)
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets the module actions.
        ''' </summary>
        ''' <value>The module actions.</value>
        Public ReadOnly Property ModuleActions() As ModuleActionCollection Implements IActionable.ModuleActions
            Get
                Dim actions As New DotNetNuke.Entities.Modules.Actions.ModuleActionCollection
                actions.Add(GetNextActionID, Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), False, Security.SecurityAccessLevel.Edit, True, False)
                actions.Add(GetNextActionID, Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditCategories"), False, Security.SecurityAccessLevel.Edit, True, False)

                Return actions

            End Get
        End Property

#End Region

#Region "Private Methods"

        ''' <summary>
        ''' Binds the data.
        ''' </summary>
        Private Sub BindData()
            Dim FAQsController As New FAQsController
            lstFAQs.DataSource = FAQsController.ListFAQ(ModuleId, DefaultSorting)
            lstFAQs.DataBind()
        End Sub

        ''' <summary>
        ''' Increments the view count.
        ''' </summary>
        ''' <param name="FaqId">The FAQ id.</param>
        Private Sub IncrementViewCount(ByVal FaqId As Integer)
            Dim objFAQs As New FAQsController
            objFAQs.IncrementViewCount(FaqId)
            
        End Sub

#End Region

#Region "Public Methods"

        ''' <summary>
        ''' HTMLs the decode.
        ''' </summary>
        ''' <param name="strValue">The STR value.</param>
        ''' <returns></returns>
        Public Function HtmlDecode(ByVal strValue As String) As String
            Try
                Return Server.HtmlDecode(strValue)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

            Return ""

        End Function

        ''' <summary>
        ''' Raises the client API callback event.
        ''' </summary>
        ''' <param name="eventArgument">The event argument.</param>
        ''' <returns></returns>
        Public Function RaiseClientAPICallbackEvent(ByVal eventArgument As String) As String Implements UI.Utilities.IClientAPICallbackEventHandler.RaiseClientAPICallbackEvent

            Try
                Dim FaqId As Integer = CInt(eventArgument)
                Dim objFAQs As New FAQsController

                IncrementViewCount(FaqId)

                Dim FaqItem As FAQsInfo = objFAQs.GetFAQ(FaqId, ModuleId)

                Return HtmlDecode(objFAQs.ProcessTokens(FaqItem, Me.AnswerTemplate))

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try

            Return ""

        End Function

#End Region

#Region "Event Handlers"

        ''' <summary>
        ''' Handles the Load event of the Page control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If ClientAPI.BrowserSupportsFunctionality(ClientAPI.ClientFunctionality.XMLHTTP) _
                 AndAlso ClientAPI.BrowserSupportsFunctionality(ClientAPI.ClientFunctionality.XML) Then
                    SupportsClientAPI = True
                    ClientAPI.RegisterClientReference(Me.Page, ClientAPI.ClientNamespaceReferences.dnn_xml)
                    ClientAPI.RegisterClientReference(Me.Page, ClientAPI.ClientNamespaceReferences.dnn_xmlhttp)

                    If Me.Page.ClientScript.IsClientScriptBlockRegistered("AjaxFaq.js") = False Then
                        Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "AjaxFaq.js", "<script language=javascript src=""" & Me.ControlPath & "scripts\AjaxFaq.js""></script>")
                    End If
                End If

                If Not IsPostBack Then
                    BindData()
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        ''' <summary>
        ''' Handles the ItemDataBound event of the lstFAQs control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs" /> instance containing the event data.</param>
        Private Sub lstFAQs_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles lstFAQs.ItemDataBound

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

                If SupportsClientAPI Then   '// AJAX Mode

                    Try

                        Dim linkQuestion As HtmlAnchor = CType(e.Item.FindControl("Q2"), HtmlAnchor)
                        Dim lblAnswer As Label = CType(e.Item.FindControl("A2"), Label)

                        Dim FaqItem As FAQsInfo = CType(e.Item.DataItem, FAQsInfo)
                        linkQuestion.InnerHtml = HtmlDecode(New FAQsController().ProcessTokens(FaqItem, Me.QuestionTemplate))

                        CType(e.Item.FindControl("lnkQ2"), LinkButton).Visible = False

                        '// Utilize the ClientAPI to create ajax request
                        Dim ClientCallBackRef As String = ClientAPI.GetCallbackEventReference(Me, _
                                                          System.Web.UI.DataBinder.Eval(e.Item.DataItem, "ItemId").ToString(), _
                                                          "GetFaqAnswerSuccess", "'" & _
                                                          lblAnswer.ClientID & "'", "GetFaqAnswerError")

                        Dim AjaxJavaScript As String = _
                        "javascript: var label = document.getElementById('" & lblAnswer.ClientID.ToString() & "');" & _
                        "if (label.innerHTML == '') { label.innerHTML = '" & HtmlDecode(Me.LoadingTemplate) & "'; " & ClientCallBackRef & " } " & _
                        "else { label.innerHTML = ''; }"

                        linkQuestion.Attributes.Add("onClick", AjaxJavaScript)


                    Catch exc As Exception 'Module failed to load
                        ProcessModuleLoadException(Me, exc)
                    End Try
                Else    '// Postback Mode
                    Try

                        Dim FaqItem As FAQsInfo = CType(e.Item.DataItem, FAQsInfo)
                        Dim linkQuestion As LinkButton = CType(e.Item.FindControl("lnkQ2"), LinkButton)
                        linkQuestion.Text = HtmlDecode(New FAQsController().ProcessTokens(FaqItem, Me.QuestionTemplate))
                        CType(e.Item.FindControl("Q2"), HtmlAnchor).Visible = False

                    Catch exc As Exception 'Module failed to load
                        ProcessModuleLoadException(Me, exc)
                    End Try
                End If

            End If
        End Sub

        ''' <summary>
        ''' Handles the Select event of the lstFAQs control.
        ''' </summary>
        ''' <param name="source">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Web.UI.WebControls.DataListCommandEventArgs" /> instance containing the event data.</param>
        Private Sub lstFAQs_Select(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstFAQs.ItemCommand
            If Not SupportsClientAPI Then
                Try

                    Dim controller As New FAQsController
                    Dim lblAnswer As Label = CType(lstFAQs.Items(e.Item.ItemIndex).FindControl("A2"), Label)
                    Dim FaqItem As FAQsInfo = controller.GetFAQ(CInt(e.CommandArgument), ModuleId)

                    If (lblAnswer.Text = "") Then
                        IncrementViewCount(FaqItem.ItemId)
                        lblAnswer.Text = HtmlDecode(controller.ProcessTokens(FaqItem, Me.AnswerTemplate))
                    Else
                        lblAnswer.Text = ""
                    End If

                Catch exc As Exception 'Module failed to load
                    ProcessModuleLoadException(Me, exc)
                End Try
            End If
        End Sub


#End Region

    End Class

End Namespace