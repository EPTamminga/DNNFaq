<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.EditFAQs" AutoEventWireup="false" CodeBehind="EditFAQs.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<table class="Normal" id="tblAddFaq" cellspacing="3" cellpadding="3" border="0">
    <tr>
        <td valign="top">
            <dnn:label id="plCategoryField" runat="server" controlname="Category" suffix=":">
            </dnn:label>
        </td>
        <td>
            <asp:DropDownList ID="drpCategory" runat="server" Width="200px" CssClass="Normal">
                <asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <dnn:label id="plQuestionField" runat="server" controlname="QuestionField" suffix=":">
            </dnn:label>
        </td>
        <td>
            <dnn:texteditor id="teQuestionField" runat="server" ControlID="teQuestionField" height="200" width="500">
            </dnn:texteditor>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <dnn:label id="plAnswerField" runat="server" controlname="AnswerField" suffix=":">
            </dnn:label>
        </td>
        <td>
            <dnn:texteditor id="teAnswerField" runat="server" ControlID="teAnswerField" height="200" width="500">
            </dnn:texteditor>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
<p>
    <asp:LinkButton ID="cmdUpdate" runat="server" BorderStyle="none" Text="Update" CssClass="CommandButton" resourcekey="cmdUpdate"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="cmdCancel" runat="server" BorderStyle="none" Text="Cancel" CssClass="CommandButton" resourcekey="cmdCancel" CausesValidation="False"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="cmdDelete" runat="server" BorderStyle="none" Text="Delete" CssClass="CommandButton" resourcekey="cmdDelete" CausesValidation="False"></asp:LinkButton></p>
<Portal:audit id="ctlAudit" runat="server">
</Portal:audit>
<p>
</p>
