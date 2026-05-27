using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["FoodDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                using (SqlConnection con =new SqlConnection(cs))
                {
                    SqlDataAdapter da =new SqlDataAdapter("SELECT * FROM MenuItems WHERE MenuId=" + id,con);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dvMenu.DataSource = dt;
                    dvMenu.DataBind();
                }
            }
        }
    }
}