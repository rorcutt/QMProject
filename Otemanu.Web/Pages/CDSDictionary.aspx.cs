using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Otemanu
{
    public partial class CDSDictionary : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                CDSDropDownList.DataSource = AllCDSDataSource;
                CDSDropDownList.DataValueField = "Id";
                CDSDropDownList.DataTextField = "Name";
                CDSDropDownList.DataBind();

                CDSDropDownList.Items.Insert(0, "Select a CDS");
            }            
        }

        protected void PreviewCDS_Click(object sender, EventArgs e)
        {
            DataView view = new DataView();
            DataTable table = new DataTable();
            view = CDSDefinitionDataSource.Select(DataSourceSelectArguments.Empty) as DataView;
            table = view.ToTable();

            Table formattingTable = new Table();

            foreach(DataRow row in table.Rows)
            {
                string rowValue = row.ItemArray[1].ToString();

                TableRow formattingRow = new TableRow();
                formattingTable.Controls.Add(formattingRow);
                TableCell formattingCellColumn1 = new TableCell { Width = 225 };                
                TableCell formattingCellColumn2 = new TableCell { Width = 225 };
                formattingRow.Controls.Add(formattingCellColumn1);
                formattingRow.Controls.Add(formattingCellColumn2);

                Label labelToAdd = new Label();
                labelToAdd.Font.Bold = true;

                if (rowValue.Equals("Label", StringComparison.OrdinalIgnoreCase))
                {                    
                    labelToAdd.Text = (string)row.ItemArray[0];
                    labelToAdd.Enabled = false;

                    formattingCellColumn1.Controls.Add(labelToAdd); 
                }
                else if (rowValue.Equals("TextBox", StringComparison.OrdinalIgnoreCase))
                {
                    labelToAdd.Text = string.Format("{0} ",(string)row.ItemArray[0]);
                    TextBox textBoxToAdd = new TextBox();

                    labelToAdd.Enabled = false;
                    textBoxToAdd.Enabled = false;

                    formattingCellColumn1.Controls.Add(labelToAdd);
                    formattingCellColumn2.Controls.Add(textBoxToAdd);
                }
                else if (rowValue.Equals("StandardDictionary", StringComparison.OrdinalIgnoreCase))
                {
                    labelToAdd.Text = string.Format("{0} ", (string)row.ItemArray[0]);

                    ComboBox itemDropDown = new ComboBox();
                    itemDropDown.AutoCompleteMode = ComboBoxAutoCompleteMode.Suggest;
                    itemDropDown.DropDownStyle = ComboBoxStyle.DropDown;

                    string tableName = (string)row.ItemArray[2];

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand comm = new SqlCommand("pr_GetStandardDictionaryItems", conn);

                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@tableName", tableName);

                        conn.Open();

                        SqlDataReader returnItems = comm.ExecuteReader();
                        while (returnItems.Read())
                        {
                            string name = returnItems["Name"].ToString();
                            itemDropDown.Items.Add(new ListItem(name, name));
                        }                        

                        conn.Close();
                    }

                    labelToAdd.Enabled = false;
                    itemDropDown.Enabled = true;

                    formattingCellColumn1.Controls.Add(labelToAdd);
                    formattingCellColumn2.Controls.Add(itemDropDown);
                }
            }

            DynamicCDSContent.Controls.Add(formattingTable);            
        }

        protected void CreateCDSButton_Click(object sender, EventArgs e)
        {
            string newCDSName = CreateCDSButtonTextBox.Text;
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
                    CreateCDSResultLabel.Text = "New CDS Create!";
                    CreateCDSResultLabel.Visible = true;
                }

                if (returnValue == 2)
                {
                    CreateCDSResultLabel.Text = "Existing CDS Updated!";
                    CreateCDSResultLabel.Visible = true;
                }

                conn.Close();
            }

            Response.Redirect("~/Pages/Dictionary.aspx");
        }

        protected void CDSDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = (DataView)QueriesByCDSDataSource.Select(DataSourceSelectArguments.Empty);

                foreach (ListItem item in QueryCheckBoxList.Items)
                {
                    item.Selected = false;
                    foreach (DataRow row in dv.Table.Rows)
                    {
                        string value = (string)row["Name"];
                        if (item.Value.Equals(row["Name"]))
                        {
                            item.Selected = true;
                            continue;
                        }
                    }
                }  
            }
            catch(Exception)
            {

            }
                          
        }
    }
}