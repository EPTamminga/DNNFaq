<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.Settings" AutoEventWireup="false" CodeBehind="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<TABLE class="Normal" id="Table2" cellSpacing="3" cellPadding="3" border="0">
	<TR>
		<TD><dnn:label id="lblDefaultSorting" ControlName="lblDefaultSorting" Suffix=":" runat="server"></dnn:label></TD>
		<TD><asp:dropdownlist id="drpDefaultSorting" runat="server" Width="150px" CssClass="Normal">
				<asp:ListItem Value="0" resourcekey="OrderByDateNew">Date New</asp:ListItem>
				<asp:ListItem Value="1" resourcekey="OrderByDateOld">Date Old</asp:ListItem>
				<asp:ListItem Value="2" resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
				<asp:ListItem Value="3" resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD vAlign="top" width="107"><dnn:label id="lblUseAjax" ControlName="chkUseAjax" Suffix=":" runat="server"></dnn:label></TD>
		<TD><asp:checkbox id="chkUseAjax" runat="server" CssClass="Normal"></asp:checkbox></TD>
	</TR>
</TABLE>
<dnn:sectionhead id="dshHTMLTemplate" runat="server" resourcekey="lblSectionTemplate" cssclass="Head"
	includerule="True" section="tblHTMLTemplates" text="Item Template"></dnn:sectionhead>
<TABLE class="Normal" id="tblHTMLTemplates" cellSpacing="3" cellPadding="3" border="0"
	runat="server">
	<TR>
		<TD vAlign="top" width="107">
			<P><dnn:label id="lblQuestionTemplate" ControlName="lblQuestionTemplate" Suffix=":" runat="server"></dnn:label></P>
		</TD>
		<TD><asp:textbox id="txtQuestionTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px"
				TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD vAlign="top" width="107"><dnn:label id="lblAnswerTemplate" ControlName="lblAnswerTemplate" Suffix=":" runat="server"></dnn:label></TD>
		<TD><asp:textbox id="txtAnswerTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px"
				TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD vAlign="top" width="107"><dnn:label id="lblLoadingTemplate" ControlName="lblLoadingTemplate" Suffix=":" runat="server"></dnn:label></TD>
		<TD><asp:textbox id="txtLoadingTemplate" runat="server" Width="350px" CssClass="Normal" Height="104px"
				TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD vAlign="top" width="107"><dnn:label id="lblAvailableTokens" ControlName="lblAvailableTokens" Suffix=":" runat="server"></dnn:label></TD>
		<TD>
			<asp:ListBox id="lstAvailableTokens" runat="server" Width="136px" Height="169px" CssClass="Normal">
				<asp:ListItem Value="[QUESTION]">[QUESTION]</asp:ListItem>
				<asp:ListItem Value="[ANSWER]">[ANSWER]</asp:ListItem>
				<asp:ListItem Value="[USER]">[USER]</asp:ListItem>
				<asp:ListItem Value="[VIEWCOUNT]">[VIEWCOUNT]</asp:ListItem>
				<asp:ListItem Value="[CATEGORYNAME]">[CATEGORYNAME]</asp:ListItem>
				<asp:ListItem Value="[CATEGORYDESC]">[CATEGORYDESC]</asp:ListItem>
				<asp:ListItem Value="[DATECREATED]">[DATECREATED]</asp:ListItem>
				<asp:ListItem Value="[DATEMODIFIED]">[DATEMODIFIED]</asp:ListItem>
				<asp:ListItem Value="[INDEX]">[INDEX]</asp:ListItem>
			</asp:ListBox></TD>
	</TR>
</TABLE>
