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
Imports System.Web.UI.HtmlControls
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Services.Exceptions.Exceptions


Namespace DotNetNuke.Modules.FAQs
    <DNNtc.ModuleControlProperties("Settings", "FAQ Settings", DNNtc.ControlType.Admin, "http://www.dotnetnuke.com/default.aspx?tabid=892", True)> _
    Partial Class Settings
        Inherits ModuleSettingsBase

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

        Protected WithEvents tblHTMLTemplates As HtmlTable

#End Region

#Region "Public Methods"

        ''' <summary>
        ''' Loads the settings.
        ''' </summary>
        Public Overrides Sub LoadSettings()

            Try

                If Not Null.IsNull(Settings("FaqQuestionTemplate")) Then
                    txtQuestionTemplate.Text = Convert.ToString(Settings("FaqQuestionTemplate"))
                Else
                    txtQuestionTemplate.Text = Localization.GetString("DefaultQuestionTemplate", Me.LocalResourceFile)
                End If

                If Not Null.IsNull(Settings("FaqAnswerTemplate")) Then
                    txtAnswerTemplate.Text = Convert.ToString(Settings("FaqAnswerTemplate"))
                Else
                    txtAnswerTemplate.Text = Localization.GetString("DefaultAnswerTemplate", Me.LocalResourceFile)
                End If

                If Not Null.IsNull(Settings("FaqLoadingTemplate")) Then
                    txtLoadingTemplate.Text = Convert.ToString(Settings("FaqLoadingTemplate"))
                Else
                    txtLoadingTemplate.Text = Localization.GetString("DefaultLoadingTemplate", Me.LocalResourceFile)
                End If

                If Not Null.IsNull(Settings("FaqDefaultSorting")) Then _
                drpDefaultSorting.SelectedValue = Convert.ToString(Settings("FaqDefaultSorting"))

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        ''' <summary>
        ''' Updates the settings.
        ''' </summary>
        Public Overrides Sub UpdateSettings()

            Try

                Dim modController As New DotNetNuke.Entities.Modules.ModuleController
                modController.UpdateModuleSetting(ModuleId, "FaqQuestionTemplate", txtQuestionTemplate.Text)
                modController.UpdateModuleSetting(ModuleId, "FaqAnswerTemplate", txtAnswerTemplate.Text)
                modController.UpdateModuleSetting(ModuleId, "FaqLoadingTemplate", txtLoadingTemplate.Text)
                modController.UpdateModuleSetting(ModuleId, "FaqDefaultSorting", drpDefaultSorting.SelectedValue.ToString())

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

#End Region

    End Class

End Namespace