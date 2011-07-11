<%@ Control Language="C#" Inherits="DotNetNuke.Modules.FAQs.FAQs" AutoEventWireup="true" CodeBehind="FAQs.ascx.cs" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width:1px; vertical-align:top;">
            <asp:Panel ID="pnlShowCategories" runat="server" Visible="false">
                <div class="categoryList">
                    <dnn:DnnListBox runat="server" ID="dnnListBoxCats" CssClass="categoryListControl"  >
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCategory" runat="server" Text='<%# Eval("FaqCategoryName") %>' OnCheckedChanged="chkCategory_CheckedChanged" AutoPostBack="true" />
                        </ItemTemplate>
                    </dnn:DnnListBox>
                </div>
            </asp:Panel>
        </td>
        <td style="vertical-align:top;">
            <asp:DataList ID="lstFAQs" runat="server" CellPadding="0" DataKeyField="ItemId" RepeatLayout="Flow" OnItemDataBound="lstFAQs_ItemDataBound" OnItemCommand="lstFAQs_Select">
                <ItemTemplate>
                    <div>
                        <asp:HyperLink ID="Hyperlink1" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditUrl("ItemId",DataBinder.Eval(Container.DataItem,"ItemId").ToString()) %>'>
                            <asp:Image ID="Hyperlink1Image" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%#IsEditable%>" resourcekey="Edit" />
                        </asp:HyperLink>
                        <asp:LinkButton ID="lnkQ2" CommandArgument='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "ItemId").ToString()) %>' CommandName="Select" runat="server" CssClass="SubHead"></asp:LinkButton>
                        <a href="javascript://" id="Q2" runat="server" class="SubHead"></a>
                        <asp:Panel ID="pnl" runat="server" Width="100%">
                            <asp:Label runat="server" ID="A2"></asp:Label></asp:Panel>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>

