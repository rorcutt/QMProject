using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Otemanu
{
    public partial class UserAudit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                Label userLabel = (Label)Master.FindControl("UserLabel");
                if (userLabel != null)
                {
                    userLabel.Text = User.Identity.Name;
                }
            }
        }

        public static void InsertUserAudit(string program, string facility, string username, string page_name)
        {
            int userId = 0;

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("pr_InsertUserAudit"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Program", program);
                        cmd.Parameters.AddWithValue("@Facility", facility);
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@PageVisited", page_name);
                        cmd.Connection = con;

                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "UserAudit Key Not Unique";
                        break;
                    default:
                        message = "Audit Successful.\\nUser Id: " + username.ToString();
                        break;
                }

                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }
    }
}