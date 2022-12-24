using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatchWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
  
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (DropDownList1.SelectedValue == "nothing")
            {
                errorLabel.Text = "please choose from the drop down list";
            }
            else
            {
                if (DropDownList1.SelectedValue == "Stadium Manager")
                {
                    //pass no msg in the label
                    String msg = null;
                    Response.Redirect("registerstadmanager.aspx?err=" + msg + " ");
                }
                else 
                {
                    if (DropDownList1.SelectedValue == "Sports Association Manager")
                    {
                        //pass no msg in the label
                        String msg = null;
                        Response.Redirect("registersportsassocmanader.aspx?err=" + msg + " ");
                    }
                    else 
                    {
                        if (DropDownList1.SelectedValue == "Club Representative")
                        {
                            String msg = null;
                            Response.Redirect("registerclubrep.aspx?err=" + msg + " ");
                        }
                        else
                        {
                            if (DropDownList1.SelectedValue == "Fane")
                            {
                                String msg = null;
                                Response.Redirect("registerfan.aspx?err=" + msg + " ");
                            }
                        }

                            
                    }
                }
            }



        }    
    }
    
}