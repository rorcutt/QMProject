using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu
{
    public partial class Dictionary : System.Web.UI.Page
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
            }

            DynamicCDSContent.Controls.Add(formattingTable);            
        }
    }
}