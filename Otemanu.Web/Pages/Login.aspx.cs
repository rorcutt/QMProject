using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Otemanu
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            //int userId = 0;
            int userId = 1;

            string constr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("pr_ValidateUser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", TextBoxUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text.Trim());
                    cmd.Connection = con;

                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }                

                if (userId == -1)
                {
                    string message = "Username and/or password is incorrect.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
                else
                {
                    Response.Redirect("~/Pages/Home.aspx");
                }  
            }
        }
    }
}