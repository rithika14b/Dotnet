using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class MenuList : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadMenu();
            }
        }

        void LoadMenu()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMenu.DataSource = dt;
                gvMenu.DataBind();
            }
        }

        // ORDER FUNCTION
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int menuId = Convert.ToInt32(btn.CommandArgument);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // check stock
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT AvailableQuantity FROM MenuItems WHERE MenuId=@id", con);

                checkCmd.Parameters.AddWithValue("@id", menuId);

                int qty = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (qty <= 0)
                {
                    lblMsg.Text = "Out of stock!";
                    return;
                }

                // reduce stock
                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE MenuItems SET AvailableQuantity = AvailableQuantity - 1 WHERE MenuId=@id", con);

                updateCmd.Parameters.AddWithValue("@id", menuId);
                updateCmd.ExecuteNonQuery();

                // insert order
                SqlCommand orderCmd = new SqlCommand(
                    "INSERT INTO Orders(MenuId, Quantity) VALUES(@id, 1)", con);

                orderCmd.Parameters.AddWithValue("@id", menuId);
                orderCmd.ExecuteNonQuery();
            }

            lblMsg.Text = "Order placed successfully!";
            LoadMenu();
        }

        // DELETE
        protected void gvMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvMenu.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MenuItems WHERE MenuId=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMenu();
        }
    }
}