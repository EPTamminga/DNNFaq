<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.FAQsCategories" AutoEventWireup="false" CodeBehind="FAQsCategories.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<p>
    <asp:DataList ID="lstCategory" DataKeyField="FaqCategoryId" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="2" cellspacing="2" class="Normal">
                <tr>
                    <td>
                        <dnn:label id="plEdit" suffix=":" controlname="CategoryEdit" runat="server">
                        </dnn:label>
                    </td>
                    <td>
                        <dnn:label id="plName" suffix=":" controlname="CategoryName" runat="server">
                        </dnn:label>
                    </td>
                    <td>
                        <dnn:label id="plDescription" suffix=":" controlname="CategoryDescription" runat="server">
                        </dnn:label>
                    </td>
                    <td>
                        <dnn:label id="plDelete" suffix=":" controlname="CategoryDelete" runat="server">
                        </dnn:label>
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:ImageButton ID="btnEditCategory" runat="server" CommandName="Edit" ImageUrl="~/images/edit.gif"></asp:ImageButton>
                </td>
                <td>
                    <asp:Label ID="lblFaqCategoryName" runat="server">
						<%# DataBinder.Eval(Container.DataItem,"FaqCategoryName") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFaqCategoryDescription" runat="server">
						<%# DataBinder.Eval(Container.DataItem,"FaqCategoryDescription") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btnDeleteCategory" CommandName="Delete" runat="server" ImageUrl="~/images/delete.gif"></asp:ImageButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:DataList></p>
<p>
    <asp:LinkButton ID="cmdAddNew" runat="server" CssClass="CommandButton" resourcekey="cmdAddNew">Add New</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="cmdGoBack" runat="server" CssClass="CommandButton" resourcekey="cmdGoBack">Go Back</asp:LinkButton></p>
<p>
    <asp:Panel ID="panelAddEdit" runat="server" Height="136px" Visible="False">
        <table class="Normal" id="tblManageCategories" cellspacing="3" cellpadding="3" border="0">
            <tr id="rowFaqCategoryId" runat="server">
                <td valign="top">
                    <dnn:label id="plCategoryId" runat="server" controlname="CategoryEdit" suffix=":">
                    </dnn:label>
                </td>
                <td>
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <dnn:label id="plCategoryName" runat="server" controlname="CategoryEdit" suffix=":">
                    </dnn:label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server" Width="304px" CssClass="NormalTextBox" MaxLength="100"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rqdCategoryName" runat="server" CssClass="NormalRed" ErrorMessage="<b>Name is required </b>" ControlToValidate="txtCategoryName" resourcekey="rqdCategoryName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" height="53">
                    <dnn:label id="plCategoryDescription" runat="server" controlname="CategoryEdit" suffix=":">
                    </dnn:label>
                </td>
                <td height="53">
                    <asp:TextBox ID="txtCategoryDescription" runat="server" Width="304px" CssClass="NormalTextBox" TextMode="MultiLine" Height="93px" MaxLength="250"></asp:TextBox>
                </td>
                <td valign="top" height="53">
                    <asp:RequiredFieldValidator ID="rqdCategoryDescription" runat="server" CssClass="NormalRed" ErrorMessage="<b> Description is Required </b>" ControlToValidate="txtCategoryDescription" resourcekey="rqdCategoryDescription"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:LinkButton ID="cmdUpdate" runat="server" CssClass="CommandButton" resourcekey="cmdUpdate">Update</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="cmdCancel" runat="server" CssClass="CommandButton" resourcekey="cmdCancel">Cancel</asp:LinkButton>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
</p>
<p>
    &nbsp;</p>
