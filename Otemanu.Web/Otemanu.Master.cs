using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Otemanu
{
    public partial class Otemanu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {                       
        }

        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}