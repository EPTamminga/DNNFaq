<%@ Control Language="C#" Inherits="DotNetNuke.Modules.FAQs.EditFAQs" AutoEventWireup="true" CodeBehind="EditFAQs.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" TagPrefix="dnn" %>
<table class="Normal" id="tblAddFaq" cellspacing="3" cellpadding="3" border="0" width="100%">
    <tr>
        <td valign="top" class="SubHead" width="128">
            <dnn:Label id="plCategoryField" runat="server" controlname="Category"></dnn:Label>
        </td>
        <td>
            <asp:DropDownList ID="drpCategory" runat="server" CssClass="Normal">
                <asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr valign="top">
        <td valign="top" class="SubHead">
            <dnn:Label id="plQuestionField" runat="server" controlname="QuestionField"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtQuestionField" CssClass="NormalTextBox" runat="server" MaxLength="400" Width="400px" TextMode="SingleLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valRequiredTitle" runat="server" CssClass="NormalRed" resourcekey="valRequiredTitle" ControlToValidate="txtQuestionField" ErrorMessage="Question is required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" class="SubHead">
            <dnn:Label id="plAnswerField" runat="server" controlname="AnswerField"></dnn:Label>
        </td>
        <td>
            <dnn:Texteditor id="teAnswerField" runat="server" controlid="teAnswerField" height="300" width="600" choosemode="False"></dnn:Texteditor>
        </td>
    </tr>
</table>
<p>
    <dnn:CommandButton ID="cmdUpdate" ResourceKey="cmdUpdate" runat="server" ImageUrl="~/images/save.gif" CssClass="CommandButton" text="Update" OnCommand="cmdUpdate_Click"/>
    &nbsp;
    <dnn:CommandButton ID="cmdCancel" ResourceKey="cmdCancel" runat="server" ImageUrl="~/images/cancel.gif" CssClass="CommandButton" CausesValidation="False" Text="Cancel" OnCommand="cmdCancel_Click" />
    &nbsp;
    <dnn:CommandButton ID="cmdDelete" ResourceKey="cmdDelete" runat="server" ImageUrl="~/images/delete.gif" CssClass="CommandButton" CausesValidation="False" Text="Delete" OnCommand="cmdDelete_Click"/>
</p>
<Portal:Audit ID="ctlAudit" runat="server"></Portal:Audit>

