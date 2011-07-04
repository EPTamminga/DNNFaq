<%@ Control Language="vb" Inherits="DotNetNuke.Modules.FAQs.FAQsCategories" AutoEventWireup="false" CodeBehind="FAQsCategories.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" TagPrefix="dnn" %>
<asp:DataList ID="lstCategory" DataKeyField="FaqCategoryId" runat="server">
    <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" class="Normal">
            <tr>
                <td align="center">
                    <dnn:Label ID="plEdit" ControlName="CategoryEdit" runat="server"></dnn:Label>
                </td>
                <td>
                    <dnn:Label ID="plName" ControlName="CategoryName" runat="server"></dnn:Label>
                </td>
                <td>
                    <dnn:Label ID="plDescription" ControlName="CategoryDescription" runat="server"></dnn:Label>
                </td>
                <td align="center">
                    <dnn:Label ID="plDelete" ControlName="CategoryDelete" runat="server"></dnn:Label>
                </td>
            </tr>
    </HeaderTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    <ItemTemplate>
        <tr>
            <td align="center">
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
            <td align="center">
                <asp:ImageButton ID="btnDeleteCategory" CommandName="Delete" runat="server" ImageUrl="~/images/delete.gif"></asp:ImageButton>
            </td>
        </tr>
    </ItemTemplate>
</asp:DataList></p>
<dnn:CommandButton ID="cmdAddNew" ResourceKey="cmdAddNew" runat="server" ImageUrl="~/images/add.gif" CssClass="CommandButton" CausesValidation="False" Text="Add New" />
&nbsp;&nbsp;
<dnn:CommandButton ID="cmdGoBack" ResourceKey="cmdGoBack" runat="server" ImageUrl="~/images/cancel.gif" CssClass="CommandButton" CausesValidation="False" Text="Cancel" />
<asp:Panel ID="panelAddEdit" runat="server" Visible="False">
    <table class="Normal" id="tblManageCategories" cellspacing="3" cellpadding="3" border="0" width="100%">
        <tr>
            <td style="width: 150px">
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr id="rowFaqCategoryId" runat="server">
            <td valign="top" class="SubHead" style="width: 150px">
                <dnn:Label ID="plCategoryId" runat="server" ControlName="CategoryEdit"></dnn:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top" class="SubHead" style="width: 150px">
                <dnn:Label ID="plCategoryName" runat="server" ControlName="CategoryEdit"></dnn:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCategoryName" runat="server" Width="304px" CssClass="NormalTextBox" MaxLength="100"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqdCategoryName" runat="server" CssClass="NormalRed" ErrorMessage="<b>Name is required </b>" ControlToValidate="txtCategoryName" resourcekey="rqdCategoryName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" class="SubHead">
                <dnn:Label ID="plCategoryDescription" runat="server" ControlName="CategoryEdit"></dnn:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCategoryDescription" runat="server" Width="304px" CssClass="NormalTextBox" TextMode="MultiLine" Height="93px" MaxLength="250"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator ID="rqdCategoryDescription" runat="server" CssClass="NormalRed" ErrorMessage="<b> Description is Required </b>" ControlToValidate="txtCategoryDescription" resourcekey="rqdCategoryDescription"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <dnn:CommandButton CssClass="CommandButton" ID="cmdUpdate" ResourceKey="cmdUpdate" ImageUrl="~/images/save.gif" runat="server" Text="Update" />
                &nbsp;&nbsp;
                <dnn:CommandButton ID="cmdCancel" ResourceKey="cmdCancel" runat="server" ImageUrl="~/images/cancel.gif" CssClass="CommandButton" CausesValidation="False" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Panel>
