<%@ Control Language="C#" Inherits="DotNetNuke.Modules.FAQs.Settings" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<dnn:SectionHead ID="shCategories" resourcekey="shCategories.Text" runat="server" section="pnlCategories" IsExpanded="true" CssClass="Head"/>
<div id="pnlCategories" runat="server">
<table id="tbl1" cellspacing="0" cellpadding="3" border="0" width="100%" >
    <tr valign="top"> 
        <td class="SubHead" width="200px">
            <dnn:Label ID="lblShowCatagories" ControlName="chkShowCatagories" runat="server"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkShowCatagories" runat="server" AutoPostBack="True" 
				oncheckedchanged="chkShowCatagories_CheckedChanged" />
        </td>
	</tr>
	<asp:Panel ID="pnlShowCategoryType" runat="server" >
		<tr valign="top">
			<td class="SubHead">
				<dnn:Label ID="lblShowToolTips" ControlName="chkShowToolTips" runat="server"></dnn:Label>
			</td>
			<td>
				<asp:CheckBox ID="chkShowToolTips" runat="server" />
			</td>
		</tr>
		<tr valign="top">
			<td class="SubHead">
				<dnn:Label ID="lblShowCategoryType" ControlName="rblShowCategoryType" runat="server"></dnn:Label>
			</td>
			<td>
				<asp:RadioButtonList ID="rblShowCategoryType" runat="server" CssClass="Normal">
					<asp:ListItem Value="0" meta:resourcekey="ShowCategoryTypeList">List with checkboxes</asp:ListItem>
					<asp:ListItem Value="1" meta:resourcekey="ShowCategoryTypeTree">Treeview</asp:ListItem>
					<asp:ListItem Value="2" meta:resourcekey="ShowCategoryTypeDropDown">Dropdown</asp:ListItem>
				</asp:RadioButtonList>
			</td>
		</tr>
	</asp:Panel>
</table>
</div>
<br />
<dnn:SectionHead ID="shFaqs" resourcekey="shFaqs.Text" runat="server" section="pnlFaqs" IsExpanded="true" CssClass="Head"/>
<div id="pnlFaqs" runat="server">
<table id="tbl2" cellspacing="0" cellpadding="3" border="0" width="100%" >
    <tr valign="top">
        <td class="SubHead" width="200px">
            <dnn:Label ID="lblDefaultSorting" ControlName="lblDefaultSorting" runat="server"></dnn:Label>
        </td>
        <td valign="top">
            <asp:DropDownList ID="drpDefaultSorting" runat="server" CssClass="Normal">
                <asp:ListItem Value="6" meta:resourcekey="OrderByViewOrder">Predefined Order</asp:ListItem>
				<asp:ListItem Value="0" meta:resourcekey="OrderByDateNew">Date New</asp:ListItem>
                <asp:ListItem Value="1" meta:resourcekey="OrderByDateOld">Date Old</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
                <asp:ListItem Value="3" meta:resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
                <asp:ListItem Value="4" meta:resourcekey="OrderByDateCreatedReverse">Creation Date Descending</asp:ListItem>
                <asp:ListItem Value="5" meta:resourcekey="OrderByDateCreatedOriginal">Creation Date Ascending</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
	 <tr valign="top">
        <td class="SubHead">
            <dnn:Label ID="lblUserSort" ControlName="chkUserSort" runat="server"></dnn:Label>
        </td>
        <td valign="top">
            <asp:Checkbox ID="chkUserSort" runat="server" />
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
</div>
