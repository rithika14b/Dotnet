<%@ Page Title="" Language="C#"MasterPageFile="~/Site.Master"AutoEventWireup="true"CodeBehind="AddEditMenu.aspx.cs"Inherits="FoodOrderManagement.AddEditMenu" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Add / Edit Menu</h2>

Item Name:

<asp:TextBox ID="txtItemName"
runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvItem"
runat="server"
ControlToValidate="txtItemName"
ErrorMessage="Item Name Required"
ForeColor="Red">
</asp:RequiredFieldValidator>

<br /><br />

Category:

<asp:TextBox ID="txtCategory"
runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvCategory"
runat="server"
ControlToValidate="txtCategory"
ErrorMessage="Category Required"
ForeColor="Red">
</asp:RequiredFieldValidator>

<br /><br />

Food Type:

<asp:DropDownList ID="ddlFoodType"
runat="server">

<asp:ListItem>Veg</asp:ListItem>
<asp:ListItem>Non-Veg</asp:ListItem>

</asp:DropDownList>

<br /><br />

Price:

<asp:TextBox ID="txtPrice"
runat="server"></asp:TextBox>

<asp:RangeValidator
ID="rvPrice"
runat="server"
ControlToValidate="txtPrice"
MinimumValue="1"
MaximumValue="10000"
Type="Double"
ErrorMessage="Invalid Price"
ForeColor="Red">
</asp:RangeValidator>

<br /><br />

Quantity:

<asp:TextBox ID="txtQty"
runat="server"></asp:TextBox>

<asp:CompareValidator
ID="cvQty"
runat="server"
ControlToValidate="txtQty"
Operator="DataTypeCheck"
Type="Integer"
ErrorMessage="Enter Valid Quantity"
ForeColor="Red">
</asp:CompareValidator>

<br /><br />

<asp:RegularExpressionValidator
ID="revName"
runat="server"
ControlToValidate="txtItemName"
ValidationExpression="^[a-zA-Z ]+$"
ErrorMessage="Only alphabets allowed"
ForeColor="Red">
</asp:RegularExpressionValidator>

<br /><br />

Available:

<asp:CheckBox ID="chkAvailable"
runat="server" />

<br /><br />

<asp:Button ID="btnSave"
runat="server"
Text="Save"
OnClick="btnSave_Click" />

<br /><br />

<asp:ValidationSummary
ID="vs1"
runat="server"
ForeColor="Red">
</asp:ValidationSummary>

</asp:Content>