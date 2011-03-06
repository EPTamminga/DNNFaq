<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.FAQsCategories" AutoEventWireup="false" CodeBehind="FAQsCategories.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<P><asp:datalist id="lstCategory" DataKeyField="FaqCategoryId" runat="server">
		<HeaderTemplate>
			<table border="0" cellpadding="2" cellspacing="2" Class="Normal">
				<tr>
					<td>
						<dnn:label id="plEdit" suffix=":" controlname="CategoryEdit" runat="server"></dnn:label>
					</td>
					<td>
						<dnn:label id="plName" suffix=":" controlname="CategoryName" runat="server"></dnn:label></td>
					<td>
						<dnn:label id="plDescription" suffix=":" controlname="CategoryDescription" runat="server"></dnn:label></td>
					<td>
						<dnn:label id="plDelete" suffix=":" controlname="CategoryDelete" runat="server"></dnn:label>
					</td>
				</tr>
		</HeaderTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
		<ItemTemplate>
			<TR>
				<TD>
					<asp:ImageButton id="btnEditCategory" runat="server" CommandName="Edit" ImageUrl="~/images/edit.gif"></asp:ImageButton></TD>
				<TD>
					<asp:Label id="lblFaqCategoryName" runat="server">
						<%# DataBinder.Eval(Container.DataItem,"FaqCategoryName") %>
					</asp:Label></TD>
				<TD>
					<asp:Label id="lblFaqCategoryDescription" runat="server">
						<%# DataBinder.Eval(Container.DataItem,"FaqCategoryDescription") %>
					</asp:Label></TD>
				<TD>
					<asp:ImageButton id="btnDeleteCategory" CommandName="Delete" runat="server" ImageUrl="~/images/delete.gif"></asp:ImageButton></TD>
			</TR>
		</ItemTemplate>
	</asp:datalist></P>
<p><asp:linkbutton id="cmdAddNew" runat="server" CssClass="CommandButton" resourcekey="cmdAddNew">Add New</asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdGoBack" runat="server" CssClass="CommandButton" resourcekey="cmdGoBack">Go Back</asp:linkbutton></p>
<P><asp:panel id="panelAddEdit" runat="server" Height="136px" Visible="False">
		<TABLE class="Normal" id="tblManageCategories" cellSpacing="3" cellPadding="3" border="0">
			<TR id="rowFaqCategoryId" runat="server">
				<TD vAlign="top">
					<dnn:label id="plCategoryId" runat="server" controlname="CategoryEdit" suffix=":"></dnn:label></TD>
				<TD>
					<asp:label id="lblId" runat="server"></asp:label></TD>
				<TD></TD>
			</TR>
			<TR>
				<TD vAlign="top">
					<dnn:label id="plCategoryName" runat="server" controlname="CategoryEdit" suffix=":"></dnn:label></TD>
				<TD>
					<asp:textbox id="txtCategoryName" runat="server" Width="304px" CssClass="NormalTextBox" MaxLength="100"></asp:textbox></TD>
				<TD>
					<asp:RequiredFieldValidator id="rqdCategoryName" runat="server" CssClass="NormalRed" ErrorMessage="<b>Name is required </b>"
						ControlToValidate="txtCategoryName" resourcekey="rqdCategoryName"></asp:RequiredFieldValidator></TD>
			</TR>
			<TR>
				<TD vAlign="top" height="53">
					<dnn:label id="plCategoryDescription" runat="server" controlname="CategoryEdit" suffix=":"></dnn:label></TD>
				<TD height="53">
					<asp:textbox id="txtCategoryDescription" runat="server" Width="304px" CssClass="NormalTextBox"
						TextMode="MultiLine" Height="93px" MaxLength="250"></asp:textbox></TD>
				<TD vAlign="top" height="53">
					<asp:RequiredFieldValidator id="rqdCategoryDescription" runat="server" CssClass="NormalRed" ErrorMessage="<b> Description is Required </b>"
						ControlToValidate="txtCategoryDescription" resourcekey="rqdCategoryDescription"></asp:RequiredFieldValidator></TD>
			</TR>
			<TR>
				<TD></TD>
				<TD>
					<asp:linkbutton id="cmdUpdate" runat="server" CssClass="CommandButton" resourcekey="cmdUpdate">Update</asp:linkbutton>&nbsp;&nbsp;
					<asp:linkbutton id="cmdCancel" runat="server" CssClass="CommandButton" resourcekey="cmdCancel">Cancel</asp:linkbutton></TD>
				<TD></TD>
			</TR>
		</TABLE>
	</asp:panel></P>
<P>&nbsp;</P>
