using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Otemanu.Pages.DictionaryPages
{
    public class CDS_Object
    {
        private string mnemonic;
        private string description;
        private string active;
        private List<string[]> data;

        public void saveCDSObject()
        {
            int errorId = 0;

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                foreach (string[] item in data)
                {
                    using (SqlCommand cmd = new SqlCommand("pr_SubmitCDSDict"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Mnemonic", mnemonic);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.Parameters.AddWithValue("@Active", ChangeToBit(active));
                            cmd.Parameters.AddWithValue("@RowNum", item[0]);
                            cmd.Parameters.AddWithValue("@Query", item[1]);
                            cmd.Parameters.AddWithValue("@QueryLabel", item[2]);
                            cmd.Parameters.AddWithValue("@QueryRequired", ChangeToBit(item[3]));

                            cmd.Connection = con;

                            con.Open();
                            errorId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }
                }
                string message = string.Empty;
                switch (errorId)
                {
                    case -1:
                        message = "Unsuccessful Add";
                        break;
                    case 1:
                        message = "CDS Added Successfully\\nMnemonic: " + mnemonic;
                        break;
                    default:
                        message = "CDS Edited Successfully\\nMnemonic: " + mnemonic;
                        break;
                }

                // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                //QueryGrid.DataBind();
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




        //Getters and Setters
        public string getMnemonic()
        {
            return mnemonic;
        }
        public void setMnemonic(string mnemonic)
        {
            mnemonic = this.mnemonic;
        }

        public string getDescription()
        {
            return description;
        }
        public void setDescription(string description)
        {
            description = this.description;
        }

        public string getActive()
        {
            return active;
        }
        public void setActive(string active)
        {
            active = this.active;
        }

        public List<string[]> getData()
        {
            return data;
        }
        public void setData(List<string[]> data)
        {
            data = this.data;
        }
    }

}