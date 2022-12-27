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
using static System.Net.Mime.MediaTypeNames;

namespace MatchWebApp
{
    public partial class ViewMatches : System.Web.UI.Page
    {
        String username;
        String date;
        int NID;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"].ToString();
            date = Request.QueryString["date"].ToString();
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from availableMatchesToAttend2('" + date + "')";


            SqlCommand availableMatches = new SqlCommand(str, conn);
            conn.Open();
            SqlDataReader rdr = availableMatches.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);
                string Stadium = rdr.GetString(2);
                string location = rdr.GetString(3);
                DropDownList1.Items.Add(HostClubname +"-"+GuestClubname);
            }
            string connStr2 = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn2 = new SqlConnection(connStr2);
            str = "select National_Id from Fan where username Like '" + username + "'";


            SqlCommand getNID = new SqlCommand(str, conn2);
            conn2.Open();
            SqlDataReader rdr2 = getNID.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {

                 NID = rdr2.GetInt32(0);
            }


        }
        public string getWhileLoopData()
        {

            username = Request.QueryString["username"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from availableMatchesToAttend2('" + date + "')";


            SqlCommand availableMatches = new SqlCommand(str, conn);
            string htmlStr = "";
            conn.Open();
            SqlDataReader rdr = availableMatches.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                
                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);
                string Stadium = rdr.GetString(2);
                string location = rdr.GetString(3);
                htmlStr += "<tr><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + Stadium + "</td><td>" + location + "</td></tr>";
            }

            return htmlStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String clubnames = DropDownList1.SelectedItem.Value;
            SqlCommand purchaseticket = new SqlCommand("purchaseTicket", conn);
            purchaseticket.CommandType = CommandType.StoredProcedure;
            purchaseticket.Parameters.Add(new SqlParameter("@nId", NID));
            string[] clubs = clubnames.Split('-');


            purchaseticket.Parameters.Add(new SqlParameter("@hostClub", clubs[0]));
            purchaseticket.Parameters.Add(new SqlParameter("@compClub", clubs[1]));
            purchaseticket.Parameters.Add(new SqlParameter("@Date", date));


            conn.Open();
            purchaseticket.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("ViewMatches.aspx?username=" + username + "&date=" + date);



        }
    }
}