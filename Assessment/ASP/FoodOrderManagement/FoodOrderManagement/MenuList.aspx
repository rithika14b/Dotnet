
<%@ Page Title="" Language="C#"MasterPageFile="~/Site.Master"AutoEventWireup="true"CodeBehind="MenuList.aspx.cs"Inherits="FoodOrderManagement.MenuList" %>



<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Food Menu List</h2>

<asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>

<br /><br />

<asp:GridView ID="gvMenu"
runat="server"
AutoGenerateColumns="False"
DataKeyNames="MenuId"
OnRowDeleting="gvMenu_RowDeleting">

<Columns>

<asp:BoundField DataField="MenuId" HeaderText="ID" />

<asp:BoundField DataField="ItemName" HeaderText="Item Name" />

<asp:BoundField DataField="Category" HeaderText="Category" />

<asp:BoundField DataField="Price" HeaderText="Price" />

<asp:BoundField DataField="AvailableQuantity" HeaderText="Quantity" />

<asp:HyperLinkField Text="View"
DataNavigateUrlFields="MenuId"
DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

<asp:HyperLinkField Text="Edit"
DataNavigateUrlFields="MenuId"
DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

<asp:TemplateField HeaderText="Order">
    <ItemTemplate>
        <asp:Button ID="btnOrder"
            runat="server"
            Text="Order"
            CommandArgument='<%# Eval("MenuId") %>'
            OnClick="btnOrder_Click" />
    </ItemTemplate>
</asp:TemplateField>

<asp:CommandField ShowDeleteButton="True" />

</Columns>

</asp:GridView>

</asp:Content>