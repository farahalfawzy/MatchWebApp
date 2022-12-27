using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatchWebApp
{
    public partial class Fan : System.Web.UI.Page
    {
        String username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String temp = date.Text +" "+ time.Text;
            if (date.Text == "" || time.Text == "")
            {
                Label1.Text = "Please enter a valid Date and Time";
            }
            else
            {
                Response.Redirect("ViewMatches.aspx?username=" + username + "&date=" + temp);
            }



        }
    }
}