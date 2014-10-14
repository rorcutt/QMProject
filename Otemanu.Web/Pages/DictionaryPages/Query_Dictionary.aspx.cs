using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu
{
    public partial class Query_Dictionary : System.Web.UI.Page
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


        protected void Submit_Click(object sender, EventArgs e)
        {          
                InsertQueryDictEdit();
        }
        protected void InsertQueryDictEdit()
        {
            int userId = 0;

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("pr_SubmitQueryDict"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mnemonic", QueryMnemonicBox.Text);
                        cmd.Parameters.AddWithValue("@QueryDescription", QueryDescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@QueryTypeSelect", QueryTypeSelect.Text);
                        cmd.Parameters.AddWithValue("@QueryActive", ChangeToBit(ActiveList.Text));
                        cmd.Parameters.AddWithValue("@QueryLabel", QueryLabelTextBox.Text);

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
                        message = "Unsuccessful Add";
                        break;
                    case 1:
                        message = "Query Added Successfully\\nMnemonic: " + QueryMnemonicBox.Text;
                        break;
                    default:
                        message = "Query Edited Successfully\\nMnemonic: " + QueryMnemonicBox.Text;
                        break;
                }

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                QueryGrid.DataBind();
            }
        }
        protected int ChangeToBit(string item)
        {
            if (item == "Y")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        protected void QueryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = QueryGrid.SelectedRow;

            QueryMnemonicBox.Text = row.Cells[1].Text;
            QueryDescriptionBox.Text = row.Cells[2].Text;
            QueryTypeSelect.Text = row.Cells[3].Text;
            ActiveList.Text = row.Cells[4].Text;
            QueryLabelTextBox.Text = row.Cells[5].Text;
        }
    }
}