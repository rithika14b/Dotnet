using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FoodOrderManagement
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["FoodDB"].ConnectionString;

        int menuId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Request.QueryString["MenuId"] != null)
            {
                menuId = Convert.ToInt32(
                    Request.QueryString["MenuId"]);

                if (!IsPostBack)
                {
                    LoadData();
                }
            }
        }

        void LoadData()
        {
            using (SqlConnection con =new SqlConnection(cs))
            {
                SqlCommand cmd =new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id",con);

                cmd.Parameters.AddWithValue("@id", menuId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtItemName.Text =dr["ItemName"].ToString();
                    txtCategory.Text =dr["Category"].ToString();
                    ddlFoodType.SelectedValue =dr["FoodType"].ToString();
                    txtPrice.Text =dr["Price"].ToString();
                    txtQty.Text =dr["AvailableQuantity"].ToString();
                    chkAvailable.Checked =Convert.ToBoolean(dr["IsAvailable"]);
                }
            }
        }

        protected void btnSave_Click(
            object sender, EventArgs e)
        {
            using (SqlConnection con =new SqlConnection(cs))
            {
                SqlCommand cmd;

                if (Request.QueryString["MenuId"] != null)
                {
                    cmd = new SqlCommand(
                    @"UPDATE MenuItems SET
                    ItemName=@ItemName,
                    Category=@Category,
                    FoodType=@FoodType,
                    Price=@Price,
                    AvailableQuantity=@Qty,
                    IsAvailable=@Available
                    WHERE MenuId=@id", con);

                    cmd.Parameters.AddWithValue("@id", menuId);
                }
                else
                {
                    cmd = new SqlCommand(
                    @"INSERT INTO MenuItems
                    (ItemName,Category,FoodType,
                    Price,AvailableQuantity,
                    IsAvailable)
                    VALUES
                    (@ItemName,@Category,@FoodType,
                    @Price,@Qty,@Available)", con);
                }
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@FoodType",ddlFoodType.SelectedValue);
                cmd.Parameters.AddWithValue("@Price",Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Qty",Convert.ToInt32(txtQty.Text));
                cmd.Parameters.AddWithValue("@Available",chkAvailable.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
}