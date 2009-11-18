<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.EditFAQs" AutoEventWireup="false" CodeBehind="EditFAQs.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<TABLE class="Normal" id="tblAddFaq" cellSpacing="3" cellPadding="3" border="0">
	<TR>
		<TD vAlign="top"><dnn:label id="plCategoryField" runat="server" controlname="Category" suffix=":"></dnn:label></TD>
		<TD><asp:dropdownlist id="drpCategory" runat="server" Width="200px" CssClass="Normal">
				<asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD vAlign="top"><dnn:label id="plQuestionField" runat="server" controlname="QuestionField" suffix=":"></dnn:label></TD>
		<TD><dnn:texteditor id="teQuestionField" runat="server" ControlID="teQuestionField" height="200" width="500"></dnn:texteditor></TD>
	</TR>
	<TR>
		<TD vAlign="top"><dnn:label id="plAnswerField" runat="server" controlname="AnswerField" suffix=":"></dnn:label></TD>
		<TD><dnn:texteditor id="teAnswerField" runat="server" ControlID="teAnswerField" height="200" width="500"></dnn:texteditor></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD></TD>
	</TR>
</TABLE>
<p><asp:linkbutton id="cmdUpdate" runat="server" borderstyle="none" text="Update" cssclass="CommandButton"
		resourcekey="cmdUpdate"></asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdCancel" runat="server" borderstyle="none" text="Cancel" cssclass="CommandButton"
		resourcekey="cmdCancel" causesvalidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdDelete" runat="server" borderstyle="none" text="Delete" cssclass="CommandButton"
		resourcekey="cmdDelete" causesvalidation="False"></asp:linkbutton></p>
<portal:audit id="ctlAudit" runat="server"></portal:audit>
<P></P>
