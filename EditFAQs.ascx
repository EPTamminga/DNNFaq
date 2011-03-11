<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.EditFAQs" AutoEventWireup="false" CodeBehind="EditFAQs.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" TagPrefix="dnn" %>
<table class="Normal" id="tblAddFaq" cellspacing="3" cellpadding="3" border="0" width="100%">
    <tr>
        <td valign="top" class="SubHead" width="128">
            <dnn:label id="plCategoryField" runat="server" controlname="Category"></dnn:label>
        </td>
        <td>
            <asp:DropDownList ID="drpCategory" runat="server" CssClass="Normal">
                <asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr valign="top">
        <td valign="top" class="SubHead">
            <dnn:label id="plQuestionField" runat="server" controlname="QuestionField"></dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtQuestionField" CssClass="NormalTextBox" runat="server" MaxLength="200" Width="400px" Text="Put your question here" TextMode="SingleLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valRequiredTitle" runat="server" CssClass="NormalRed" resourcekey="valRequiredTitle" ControlToValidate="txtQuestionField" ErrorMessage="Question is required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" class="SubHead">
            <dnn:label id="plAnswerField" runat="server" controlname="AnswerField"></dnn:label>
        </td>
        <td>
            <dnn:texteditor id="teAnswerField" runat="server" controlid="teAnswerField" height="300" width="600" htmlencode="True" choosemode="False"></dnn:texteditor>
        </td>
    </tr>
</table>
<p>
    <dnn:commandbutton cssclass="CommandButton" id="cmdUpdate" imageurl="~/images/save.gif" runat="server" text="Update" />
    &nbsp;
    <dnn:commandbutton id="cmdCancel" runat="server" imageurl="~/images/cancel.gif" cssclass="CommandButton" causesvalidation="False" text="Cancel" />
    &nbsp;
    <dnn:commandbutton id="cmdDelete" runat="server" imageurl="~/images/delete.gif" cssclass="CommandButton" causesvalidation="False" text="Delete" />
</p>
<Portal:Audit ID="ctlAudit" runat="server"></Portal:Audit>
