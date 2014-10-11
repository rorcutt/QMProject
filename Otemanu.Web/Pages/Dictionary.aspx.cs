using System;
using System.Collections.Generic;
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
    }
}