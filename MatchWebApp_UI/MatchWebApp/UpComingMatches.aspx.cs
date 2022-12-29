



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace MatchWebApp
{

    public partial class UpComingMatches : System.Web.UI.Page
    {
        String Club;
        protected void Page_Load(object sender, EventArgs e)
        {
            Club = Request.QueryString["Club"].ToString();
            Debug.WriteLine("\n\n\n" + Club + "\n\n\n");
        }

        public string getWhileLoopData()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from upcomingMatchesOTwo('" + Club + "')";
            Debug.WriteLine("\n\n\n" + str + "\n\n\n");
            SqlCommand upcomingMatchesOTwo = new SqlCommand(str, conn);
            string htmlStr = "";

            conn.Open();
            SqlDataReader rdr = upcomingMatchesOTwo.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string Stadium = "";
                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);
                DateTime MatchStartTime = rdr.GetDateTime(2);
                DateTime MatchEndTime = rdr.GetDateTime(3);
                try
                {
                    Stadium = rdr.GetString(4);
                }
                catch{
                    Stadium = "not initialized yet";
                }
                htmlStr += "</td><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + MatchStartTime + "</td><td>" + MatchEndTime + "</td><td>" + Stadium + "</td></tr>";
            }

            conn.Close();
            return htmlStr;
        }
    }
}
