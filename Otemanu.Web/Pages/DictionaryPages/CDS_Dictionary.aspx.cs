using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu
{
    public partial class CDS_Dictionary : System.Web.UI.Page
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
                    if (!IsPostBack)
                        ViewState["numrows"] = 0;
                        LoadControls();
                }
            }
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (ViewState["controlsadded"] == null)
               LoadControls();
        }

        private void LoadControls()
        {
            Button addNewRow = new Button();
            addNewRow.Click += new System.EventHandler(addNewRow_Click);
            addNewRow.Text = "Add New Row";
            Panel1.Controls.Add(addNewRow);
            if ((int)(ViewState["numrows"]) == 0)
            {
                createRows();
            }
                // Adds Controls back after button is pressed
                ViewState["controlsadded"] = true;
        }
        private void addNewRow_Click(Object sender, System.EventArgs e)
        {
            ViewState["numrows"] = (int)(ViewState["numrows"]) + 1;
            int counter = (int)ViewState["numrows"];
            createRows();
        }
        private void createRows()
        {
            int count = 0;
            for (int i = 0; i < (int)ViewState["numrows"]; i++)
            {
                count = i + 1;
                //Generate Labels
                Label rowNumberLabel = new Label();
                rowNumberLabel.Text = "Row Count:";

                //Generate TextBoxes
                TextBox rowNumberText = new TextBox();
                rowNumberText.Text = count.ToString();
                rowNumberText.Width = 20;
                rowNumberText.Enabled = false;
                rowNumberText.ID = "row_number" + count.ToString();

                //Generate QueryID Dropdown
                // Get QueryIDs in one call, store in list (element 0 - mnemonic, element 1 - name, element, type)

                //Add Elements to Screen
                Panel1.Controls.Add(new LiteralControl("<BR>"));
                Panel1.Controls.Add(rowNumberLabel);
                Panel1.Controls.Add(rowNumberText);
                
            }

        }
    }
}