<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.EditFAQs" AutoEventWireup="false" CodeBehind="EditFAQs.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" TagPrefix="dnn" %>
<table class="Normal" id="tblAddFaq" cellspacing="3" cellpadding="3" border="0" width="100%">
    <tr>
        <td valign="top"   class="SubHead" width="128">
            <dnn:Label ID="plCategoryField" runat="server" ControlName="Category" ></dnn:Label>
        </td>
        <td>
            <asp:DropDownList ID="drpCategory" runat="server" CssClass="Normal">
                <asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td valign="top"  class="SubHead">
            <dnn:Label ID="plQuestionField" runat="server" ControlName="QuestionField" ></dnn:Label>
        </td>
        <td>
            <dnn:TextEditor ID="teQuestionField" runat="server" ControlID="teQuestionField" Height="200" Width="600" HtmlEncode="True"></dnn:TextEditor>
        </td>
    </tr>
    <tr>
        <td valign="top"  class="SubHead">
            <dnn:Label ID="plAnswerField" runat="server" ControlName="AnswerField"></dnn:Label>
        </td>
        <td>
            <dnn:TextEditor ID="teAnswerField" runat="server" ControlID="teAnswerField" Height="300" Width="600" HtmlEncode="True"></dnn:TextEditor>
        </td>
    </tr>
</table>
<p>
    <dnn:CommandButton CssClass="CommandButton" ID="cmdUpdate" ImageUrl="~/images/save.gif" runat="server" Text="Update" />
    &nbsp;
    <dnn:CommandButton ID="cmdCancel" runat="server" ImageUrl="~/images/cancel.gif" CssClass="CommandButton" CausesValidation="False" Text="Cancel" />
    &nbsp;
    <dnn:CommandButton ID="cmdDelete" runat="server" ImageUrl="~/images/delete.gif" CssClass="CommandButton" CausesValidation="False" Text="Delete" />
  </p>
<Portal:Audit ID="ctlAudit" runat="server"></Portal:Audit>
