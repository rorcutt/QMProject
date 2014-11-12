using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu.Pages
{
    public partial class CreateNewCDS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateNewCDSButton_Click(object sender, EventArgs e)
        {
            string newCDSName = CDSNameTextBox.Text;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand("pr_SaveCDS", conn);

                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Name", newCDSName);
                comm.Parameters.AddWithValue("@Description", string.Empty);

                conn.Open();

                int returnValue = (int)comm.ExecuteScalar();

                if (returnValue == 1)
                {
                }

                if (returnValue == 2)
                {
                }

                conn.Close();
            }

            Response.Redirect("~/Pages/CDSDictionary.aspx");
        }
    }
}