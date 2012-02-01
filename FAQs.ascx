<%@ Control Language="C#" Inherits="DotNetNuke.Modules.FAQs.FAQs" AutoEventWireup="true" CodeBehind="FAQs.ascx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td style="width:1px; vertical-align:top;">
			<asp:Panel ID="pnlShowCategories" runat="server" Visible="false" >
				<asp:MultiView ID="mvShowCategoryType" runat="server" ActiveViewIndex="0">
					<asp:View ID="vShowCategoryTypeList" runat="server">
						<div class="categoryList">
							<dnn:DnnListBox runat="server" ID="listCategories" CssClass="categoryListControl" OnItemDataBound="listCategories_ItemDataBound" >
								<ItemTemplate>
									<asp:CheckBox ID="chkCategory" runat="server" Text='<%# Eval("FaqCategoryName") %>' OnCheckedChanged="chkCategory_CheckedChanged" AutoPostBack="true" />
								</ItemTemplate>
							</dnn:DnnListBox>
						</div>
					</asp:View>
					<asp:View ID="vShowCategoryTypeTree" runat="server">
						<div class="categoryTree" style="margin-right: 20px;">
							<dnn:DNNTreeView ID="treeCategories" runat="server" CssClass="categoryTreeControl" 
								ShowLineImages="False" OnNodeClick="treeCategories_NodeClick" OnNodeDataBound="treeCategories_NodeDataBound">
								<DataBindings>
									<telerik:RadTreeNodeBinding Expanded="true" />
								</DataBindings>
							</dnn:DNNTreeView>
						</div>
					</asp:View>
				</asp:MultiView>
			</asp:Panel>
		</td>
		<td style="vertical-align:top;">
			<asp:Panel ID="pnlSortbox" runat="server" Visible="false">
				<dnn:Label ID="lblSort" runat="server" ControlName="drpSort" CssClass="SubHead" />
				<asp:DropDownList ID="drpSort" runat="server" CssClass="NormalTextBox" AutoPostBack="true" OnSelectedIndexChanged="drpSort_SelectedIndexChanged">
					<asp:ListItem Value="6" resourcekey="OrderByViewOrder">Predefined Order</asp:ListItem>
					<asp:ListItem Value="0" resourcekey="OrderByDateNew">Date New</asp:ListItem>
					<asp:ListItem Value="1" resourcekey="OrderByDateOld">Date Old</asp:ListItem>
					<asp:ListItem Value="2" resourcekey="OrderByPopularityHigh">Popularity High</asp:ListItem>
					<asp:ListItem Value="3" resourcekey="OrderByPopularityLow">Popularity Low</asp:ListItem>
					<asp:ListItem Value="4" resourcekey="OrderByDateCreatedReverse">Creation Date Descending</asp:ListItem>
					<asp:ListItem Value="5" resourcekey="OrderByDateCreatedOriginal">Creation Date Ascending</asp:ListItem>
				</asp:DropDownList>
				<br />
				<br />
			</asp:Panel>
			<asp:Panel ID="pnlShowCategoryTypeDropdown" runat="server" Visible="false">
				<dnn:Label ID="lblSelectCategory" runat="server" ControlName="drpCategories" CssClass="SubHead" />
				<asp:DropDownList ID="drpCategories" runat="server" CssClass="NormalTextBox" AutoPostBack="true" OnSelectedIndexChanged="drpCategories_SelectedIndexChanged"/>	
				<br />
				<br />
			</asp:Panel>
			<asp:DataList ID="lstFAQs" runat="server" CellPadding="0" DataKeyField="ItemId" RepeatLayout="Flow" CssClass="faqsList" OnItemDataBound="lstFAQs_ItemDataBound" OnItemCommand="lstFAQs_ItemCommand" >
				<ItemTemplate>
					<div>
						<asp:HyperLink ID="Hyperlink1" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditUrl("ItemId",DataBinder.Eval(Container.DataItem,"ItemId").ToString()) %>'>
							<asp:Image ID="Hyperlink1Image" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%#IsEditable%>" resourcekey="Edit" />
						</asp:HyperLink>
						<asp:ImageButton ID="lnkUp" CommandArgument='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "ItemId").ToString()) %>' CommandName="Up" runat="server" ImageUrl="~/images/up.gif" Visible="<%#IsMovable%>"/>
						<asp:ImageButton ID="lnkDn" CommandArgument='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "ItemId").ToString()) %>' CommandName="Down" runat="server" ImageUrl="~/images/dn.gif" Visible="<%#IsMovable%>"/>
						<asp:LinkButton ID="lnkQ2" CommandArgument='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "ItemId").ToString()) %>' CommandName="Select" runat="server" CssClass="SubHead"></asp:LinkButton>
						<a href="javascript://" id="Q2" runat="server" class="SubHead"></a>
						<asp:Panel ID="pnl" runat="server" Width="100%"><asp:Label runat="server" ID="A2"></asp:Label></asp:Panel>
					</div>
				</ItemTemplate>
			</asp:DataList>
		</td>
	</tr>
</table>

