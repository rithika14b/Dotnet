using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class OrderStats : System.Web.UI.Page
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
                LoadStats();
            }
        }

        void LoadStats()
        {
            // Visitors
            lblVisitors.Text = "Total Visitors: " + Application["TotalVisitors"];
            lblUsers.Text = "Active Users: " + Application["ActiveUsers"];

            LoadCategoryStats();
        }

        void LoadCategoryStats()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT Category, COUNT(*) AS TotalItems
                      FROM MenuItems
                      GROUP BY Category", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvStats.DataSource = dt;
                gvStats.DataBind();
            }
        }
    }
}