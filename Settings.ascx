<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.Settings" AutoEventWireup="false" CodeBehind="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="Table2" cellspacing="0" cellpadding="3" border="0" width="100%">
    <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblDefaultSorting" ControlName="lblDefaultSorting" runat="server"></dnn:Label>
        </td>
        <td valign="top">
            <asp:DropDownList ID="drpDefaultSorting" runat="server" CssClass="Normal">
                <asp:ListItem Value="0" resourcekey="OrderByDateNew">Date New</asp:ListItem>
                <asp:ListItem Value="1" resourcekey="OrderByDateOld">Date Old</asp:ListItem>
                <asp:ListItem Value="2" resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
                <asp:ListItem Value="3" resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
                <asp:ListItem Value="4" resourcekey="OrderByDateCreatedReverse">Creation Date Descending</asp:ListItem>
                <asp:ListItem Value="5" resourcekey="OrderByDateCreatedOriginal">Creation Date Ascending</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblQuestionTemplate" ControlName="lblQuestionTemplate" runat="server"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtQuestionTemplate" runat="server" Width="400px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblAnswerTemplate" ControlName="lblAnswerTemplate" runat="server"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAnswerTemplate" runat="server" Width="400px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblLoadingTemplate" ControlName="lblLoadingTemplate" runat="server"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLoadingTemplate" runat="server" Width="400px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblAvailableTokens" ControlName="lblAvailableTokens" runat="server"></dnn:Label>
        </td>
        <td>
            <asp:ListBox ID="lstAvailableTokens" runat="server" Height="169px" CssClass="Normal">
                <asp:ListItem Value="[FAQ:QUESTION]">[FAQ:QUESTION]</asp:ListItem>
                <asp:ListItem Value="[FAQ:ANSWER]">[FAQ:ANSWER]</asp:ListItem>
                <asp:ListItem Value="[FAQ:USER]">[FAQ:USER]</asp:ListItem>
                <asp:ListItem Value="[FAQ:VIEWCOUNT]">[FAQ:VIEWCOUNT]</asp:ListItem>
                <asp:ListItem Value="[FAQ:CATEGORYNAME]">[FAQ:CATEGORYNAME]</asp:ListItem>
                <asp:ListItem Value="[FAQ:CATEGORYDESC]">[FAQ:CATEGORYDESC]</asp:ListItem>
                <asp:ListItem Value="[FAQ:DATECREATED]">[FAQ:DATECREATED]</asp:ListItem>
                <asp:ListItem Value="[FAQ:DATEMODIFIED]">[FAQ:DATEMODIFIED]</asp:ListItem>
                <asp:ListItem Value="[FAQ:INDEX]">[FAQ:INDEX]</asp:ListItem>
            </asp:ListBox>
        </td>
    </tr>
</table>
