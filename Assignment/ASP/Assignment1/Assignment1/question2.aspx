<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="question2.aspx.cs" Inherits="Assignment1.question2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Store</title>

    <style>
        body {
            font-family: Arial;
            margin: 30px;
        }

        .container {
            width: 400px;
        }

        img {
            border: 1px solid gray;
            }

        .price {
            color: green;
            font-size: 20px;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form id="form2" runat="server">

        <div class="container">

            <h2>Select a Product</h2>

            
            <asp:DropDownList
                ID="ddlProducts"
                runat="server"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>

            <br /><br />

          
            <asp:Image
                ID="imgProduct"
                runat="server"
                Width="300px"
                Height="300px" />

            <br /><br />

            
            <asp:Button
                ID="btnPrice"
                runat="server"
                Text="Get Price"
                OnClick="btnPrice_Click" />

            <br /><br />

      
            <asp:Label
                ID="lblPrice"
                runat="server"
                CssClass="price">
            </asp:Label>

        </div>

    </form>
</body>
</html>
