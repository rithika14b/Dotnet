using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class question2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("Laptop");
                ddlProducts.Items.Add("Phone");
                ddlProducts.Items.Add("Headphones");

                ShowImage();
            }

        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowImage();
            lblPrice.Text = "";

        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedItem.Text)
            {
                case "Laptop":
                    lblPrice.Text = "Price:12000";
                    break;

                case "Phone":
                    lblPrice.Text = "Price:8000";
                    break;

                case "Headphones":
                    lblPrice.Text = "Price:1500";
                    break;
            }
        }
        private void ShowImage()
        {
            switch (ddlProducts.SelectedItem.Text)
            {
                case "Laptop":
                    imgProduct.ImageUrl = "\"C:\\Rithi\\Dotnet\\Assignment\\ASP\\Assignment1\\image\\laptop.jpg\"";
                    break;

                case "Phone":
                    imgProduct.ImageUrl = "\"C:\\Rithi\\Dotnet\\Assignment\\ASP\\Assignment1\\image\\phone.png\"";
                    break;

                case "Headphones":
                    imgProduct.ImageUrl = "\"C:\\Rithi\\Dotnet\\Assignment\\ASP\\Assignment1\\image\\headset.png\"";
                    break;
            }
        }
    }
}