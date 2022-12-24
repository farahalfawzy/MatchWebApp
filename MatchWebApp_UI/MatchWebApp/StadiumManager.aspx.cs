using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatchWebApp
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        String username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand allStadiumManagers = new SqlCommand("select * from StadiumManager", conn);

            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                String usernametemp = rdr.GetString(rdr.GetOrdinal("username"));
                if (usernametemp.Equals(username))
                {
                    Label1.Text = name;
                    break;
                }


            }



        }

        protected void Stadinfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("StadiumInfo.aspx?username=" + username + " ");

        }

        protected void allreq_Click(object sender, EventArgs e)
        {

            Response.Redirect("StadiumManagerRequests.aspx?username=" + username + " ");

        }
    }
}