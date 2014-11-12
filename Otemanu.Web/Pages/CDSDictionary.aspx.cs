using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu
{
    public partial class CDSDictionary : System.Web.UI.Page
    {
        private string ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
                TableCell formattingCellColumn3 = new TableCell { Width = 225 };
                formattingRow.Controls.Add(formattingCellColumn1);
                formattingRow.Controls.Add(formattingCellColumn2);
                formattingRow.Controls.Add(formattingCellColumn3);

                Label labelToAdd = new Label();
                labelToAdd.Font.Bold = true;

                Label typeLabel = new Label();
                typeLabel.Text = rowValue;
                formattingCellColumn3.Controls.Add(typeLabel); 

                if (rowValue.Equals("Label", StringComparison.OrdinalIgnoreCase))
                {
                    labelToAdd.Text = (string)row.ItemArray[0];

                    formattingCellColumn1.Controls.Add(labelToAdd);                    
                }
                else if (rowValue.Equals("TextBox", StringComparison.OrdinalIgnoreCase))
                {
                    labelToAdd.Text = string.Format("{0} ",(string)row.ItemArray[0]);
                    TextBox textBoxToAdd = new TextBox();

                    formattingCellColumn1.Controls.Add(labelToAdd);
                    formattingCellColumn2.Controls.Add(textBoxToAdd);
                }
                else if (rowValue.Equals("StandardDictionary", StringComparison.OrdinalIgnoreCase))
                {                    
                    labelToAdd.Text = string.Format("{0} ", (string)row.ItemArray[0]);

                    DropDownList itemDropDown = new DropDownList();                    

                    string tableName = (string)row.ItemArray[2];
                    typeLabel.Text = string.Format("{0}: {1}",typeLabel.Text, tableName);

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
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

                    formattingCellColumn1.Controls.Add(labelToAdd);
                    formattingCellColumn2.Controls.Add(itemDropDown);
                }
                typeLabel.Text = string.Format("[{0}]",typeLabel.Text);
            }

            DynamicCDSContent.Controls.Add(formattingTable);            
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
                        string value = Convert.ToString((int)row["Id"]);
                        if (item.Value.Equals(value, StringComparison.OrdinalIgnoreCase))                       
                            item.Selected = true;                        
                    }
                }  
            }
            catch(Exception)
            {
            }                          
        }

        protected void SaveCDSChangesButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in QueryCheckBoxList.Items)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand comm;
                    if (item.Selected)
                    {
                        comm = new SqlCommand("pr_InsertCDSQueryMapping", conn);
                    }
                    else
                    {
                        comm = new SqlCommand("pr_DeleteCDSQueryMapping", conn);
                    }

                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@customDefinedScreenId", CDSDropDownList.SelectedValue);
                    comm.Parameters.AddWithValue("@queryId", item.Value);

                    conn.Open();

                    comm.ExecuteNonQuery();                   

                    conn.Close();
                }
            }
        }

        protected void DeleteCDSButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand comm = new SqlCommand("pr_DeleteCDS", conn);

                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@customDefinedScreenId", CDSDropDownList.SelectedValue);                

                conn.Open();

                comm.ExecuteNonQuery();

                conn.Close();
            }

            Response.Redirect("~/Pages/CDSDictionary.aspx");
        }
    }
}