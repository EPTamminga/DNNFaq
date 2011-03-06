<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.Settings" AutoEventWireup="false" CodeBehind="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table class="Normal" id="Table2" cellspacing="3" cellpadding="3" border="0">
    <tr>
        <td>
            <dnn:label id="lblDefaultSorting" ControlName="lblDefaultSorting" Suffix=":" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:DropDownList ID="drpDefaultSorting" runat="server" Width="150px" CssClass="Normal">
                <asp:ListItem Value="0" resourcekey="OrderByDateNew">Date New</asp:ListItem>
                <asp:ListItem Value="1" resourcekey="OrderByDateOld">Date Old</asp:ListItem>
                <asp:ListItem Value="2" resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
                <asp:ListItem Value="3" resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td valign="top" width="107">
            <dnn:label id="lblUseAjax" ControlName="chkUseAjax" Suffix=":" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:CheckBox ID="chkUseAjax" runat="server" CssClass="Normal"></asp:CheckBox>
        </td>
    </tr>
</table>
<dnn:sectionhead id="dshHTMLTemplate" runat="server" resourcekey="lblSectionTemplate" cssclass="Head" includerule="True" section="tblHTMLTemplates" text="Item Template">
</dnn:sectionhead>
<table class="Normal" id="tblHTMLTemplates" cellspacing="3" cellpadding="3" border="0" runat="server">
    <tr>
        <td valign="top" width="107">
            <p>
                <dnn:label id="lblQuestionTemplate" ControlName="lblQuestionTemplate" Suffix=":" runat="server">
                </dnn:label></p>
        </td>
        <td>
            <asp:TextBox ID="txtQuestionTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" width="107">
            <dnn:label id="lblAnswerTemplate" ControlName="lblAnswerTemplate" Suffix=":" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtAnswerTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" width="107">
            <dnn:label id="lblLoadingTemplate" ControlName="lblLoadingTemplate" Suffix=":" runat="server">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtLoadingTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" width="107">
            <dnn:label id="lblAvailableTokens" ControlName="lblAvailableTokens" Suffix=":" runat="server">
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
