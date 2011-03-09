<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.Settings" AutoEventWireup="false" CodeBehind="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="Table2" cellspacing="0" cellpadding="3" border="0" width="100%">
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="lblDefaultSorting" ControlName="lblDefaultSorting" runat="server">
            </dnn:label>
        </td>
        <td valign="top" >
            <asp:DropDownList ID="drpDefaultSorting" runat="server" CssClass="Normal">
                <asp:ListItem Value="0" resourcekey="OrderByDateNew">Date New</asp:ListItem>
                <asp:ListItem Value="1" resourcekey="OrderByDateOld">Date Old</asp:ListItem>
                <asp:ListItem Value="2" resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
                <asp:ListItem Value="3" resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
                <dnn:label id="lblQuestionTemplate" ControlName="lblQuestionTemplate" runat="server">
                </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtQuestionTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="lblAnswerTemplate" ControlName="lblAnswerTemplate" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtAnswerTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="lblLoadingTemplate" ControlName="lblLoadingTemplate" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtLoadingTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="lblAvailableTokens" ControlName="lblAvailableTokens" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:ListBox ID="lstAvailableTokens" runat="server" Width="136px" Height="169px" CssClass="Normal">
                <asp:ListItem Value="[QUESTION]">[QUESTION]</asp:ListItem>
                <asp:ListItem Value="[ANSWER]">[ANSWER]</asp:ListItem>
                <asp:ListItem Value="[USER]">[USER]</asp:ListItem>
                <asp:ListItem Value="[VIEWCOUNT]">[VIEWCOUNT]</asp:ListItem>
                <asp:ListItem Value="[CATEGORYNAME]">[CATEGORYNAME]</asp:ListItem>
                <asp:ListItem Value="[CATEGORYDESC]">[CATEGORYDESC]</asp:ListItem>
                <asp:ListItem Value="[DATECREATED]">[DATECREATED]</asp:ListItem>
                <asp:ListItem Value="[DATEMODIFIED]">[DATEMODIFIED]</asp:ListItem>
                <asp:ListItem Value="[INDEX]">[INDEX]</asp:ListItem>
            </asp:ListBox>
        </td>
    </tr>
</table>
