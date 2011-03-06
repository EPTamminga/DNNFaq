<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.FAQs" AutoEventWireup="false"
    Codebehind="FAQs.ascx.vb" %>
<asp:DataList ID="lstFAQs" runat="server" CellPadding="0" DataKeyField="ItemId" RepeatLayout="Flow">
    <ItemTemplate>
        <div>
            <asp:HyperLink ID="Hyperlink1" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemId",DataBinder.Eval(Container.DataItem,"ItemId")) %>'>
                <asp:Image ID="Hyperlink1Image" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit"
                    Visible="<%#IsEditable%>" resourcekey="Edit" />
            </asp:HyperLink>
            <asp:LinkButton ID="lnkQ2" CommandArgument='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "ItemId")) %>'
                CommandName="Select" runat="server" CssClass="SubHead"></asp:LinkButton>
            <a href="javascript://" id="Q2" runat="server" class="SubHead"></a>
            <asp:Panel ID="pnl" runat="server" Width="100%">
                <asp:Label runat="server" ID="A2"></asp:Label></asp:Panel>
        </div>
    </ItemTemplate>
</asp:DataList>
