using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace MatchWebApp
{
    public partial class StadiumManagerRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"].ToString();
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
            conn.Close();

        }

        public string getWhileLoopData()
        {
            string username = Request.QueryString["username"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from allPendingRequestsMS3('" + username + "')";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            string htmlStr = "";

            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string ClubRepresantative = rdr.GetString(0);
                string HostClubname = rdr.GetString(1);
                string GuestClubname = rdr.GetString(2);
                string MatchStartTime=rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string MatchEndTime =rdr.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string Status=rdr.GetString(5);
                htmlStr += "<tr><td>" + ClubRepresantative + "</td><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + MatchStartTime + "</td><td>" + MatchEndTime+ "</td><td>"+Status+ "</td></tr>";
        }

            conn.Close();
            return htmlStr;
        }
    }
}