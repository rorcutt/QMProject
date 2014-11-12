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
        #region Variables

        /// <summary>
        /// The variable is used to store the persistent Cache value "SelectedRibbonItem"
        /// which is the id of the navigation ribbon control that is currently selected.
        /// This value should match the child page that the application is on.
        /// </summary>
        public string selectedRibbonItemId;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                UserLabel.Text = HttpContext.Current.User.Identity.Name; 
            }

            selectedRibbonItemId = (string)Cache.Get("SelectedRibbonItem");

            if (selectedRibbonItemId == null)
                selectedRibbonItemId = "HomeRibbonItem";

            SelectRibbonItem(selectedRibbonItemId);

            HomeRibbonItem.Click += RibbonItem_Click;
            AddOccurenceRibbonItem.Click += RibbonItem_Click;
            BuildRibbonItem.Click += RibbonItem_Click;
            ReportsRibbonItem.Click += RibbonItem_Click;
            DictionaryRibbonItem.Click += RibbonItem_Click;
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// This event is raised any time a ribbon item is clicked
        /// Important note: The event will not be triggerd if the LargeItem 
        /// control of the ribbon has the NavigationUrl set.
        /// </summary>
        void RibbonItem_Click(object sender, EventArgs e)
        {
            //HomeRibbonItem.Checked = false;
            string redirectUrl = "~/Pages/Home.aspx";
            OfficeWebUI.Ribbon.LargeItem temp = (OfficeWebUI.Ribbon.LargeItem)sender;

            if (temp.ID.Equals("HomeRibbonItem"))
            {
                Cache.Insert("SelectedRibbonItem", "HomeRibbonItem");
                redirectUrl = "~/Pages/Home.aspx";
            }
            else if (temp.ID.Equals("AddOccurenceRibbonItem"))
            {
                Cache.Insert("SelectedRibbonItem", "AddOccurenceRibbonItem");
                redirectUrl = "~/Pages/AddOccurence.aspx";
            }
            else if (temp.ID.Equals("BuildRibbonItem"))
            {
                Cache.Insert("SelectedRibbonItem", "BuildRibbonItem");
                redirectUrl = "~/Pages/Build.aspx";
            }
            else if (temp.ID.Equals("ReportsRibbonItem"))
            {
                Cache.Insert("SelectedRibbonItem", "ReportsRibbonItem");
                redirectUrl = "~/Pages/Reports.aspx";
            }
            else if (temp.ID.Equals("DictionaryRibbonItem"))
            {
                Cache.Insert("SelectedRibbonItem", "DictionaryRibbonItem");
                redirectUrl = "~/Pages/Dictionaries.aspx";
            }

            Response.Redirect(redirectUrl);
        }        

        /// <summary>
        /// This method is called when the Sign Out button is clicked
        /// </summary>
        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Pages/Login.aspx");
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// This method highlights the selected navigation menu item
        /// </summary>
        private void SelectRibbonItem(string selectedRibbonItemId)
        {
            if (selectedRibbonItemId.Equals("HomeRibbonItem"))
            {
                HomeRibbonItem.Checked = true;
            }
            else if (selectedRibbonItemId.Equals("AddOccurenceRibbonItem"))
            {
                AddOccurenceRibbonItem.Checked = true;
            }
            else if (selectedRibbonItemId.Equals("BuildRibbonItem"))
            {
                BuildRibbonItem.Checked = true;
            }
            else if (selectedRibbonItemId.Equals("ReportsRibbonItem"))
            {
                ReportsRibbonItem.Checked = true;
            }
            else if (selectedRibbonItemId.Equals("DictionaryRibbonItem"))
            {
                DictionaryRibbonItem.Checked = true;
            }
        }

        #endregion
    }
}