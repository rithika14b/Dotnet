<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="FoodOrderManagement.OrderStats" %>


<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Order Statistics</h2>

<asp:Label ID="lblVisitors"
runat="server"
Font-Bold="true">
</asp:Label>

<br /><br />

<asp:Label ID="lblUsers"
runat="server"
Font-Bold="true">
</asp:Label>

<br /><br />

<h3>Food Category Statistics</h3>

<asp:GridView ID="gvStats"
runat="server"
AutoGenerateColumns="true">
</asp:GridView>
</asp:Content>
