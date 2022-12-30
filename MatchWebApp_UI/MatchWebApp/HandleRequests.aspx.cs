using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Diagnostics;

namespace MatchWebApp
{
    public partial class HandleRequests : System.Web.UI.Page
    {
        String username;
        string ClubRepresantative;
        string HostClubname;
        string GuestClubname;
        String MatchStartTime;
        String MatchEndTime;
        string Status;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"].ToString();
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand allStadiumManagers = new SqlCommand("select * from StadiumManager", conn);

            conn.Open();
            SqlDataReader rdr2 = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                String name = rdr2.GetString(rdr2.GetOrdinal("name"));
                String usernametemp = rdr2.GetString(rdr2.GetOrdinal("username"));
                if (usernametemp.Equals(username))
                {
                    Label1.Text = name;
                    break;
                }
            }
            conn.Close();



            String str = "select * from allPendingRequestsMS3('" + username + "') where status = 'unhandled'";


            SqlCommand allPendingRequestsMS3 = new SqlCommand(str, conn);
            int i = 1;
            conn.Open();
            SqlDataReader rdr = allPendingRequestsMS3.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string ClubRepresantative = rdr.GetString(0);
                string HostClubname = rdr.GetString(1);
                string GuestClubname = rdr.GetString(2);
                String MatchStartTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff"); 
                String MatchEndTime = rdr.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff"); 
                string Status = rdr.GetString(5);
                DropDownList1.Items.Add("Request number " + i);

                i++;
            }


        }
        public string getWhileLoopData()
        {
            username = Request.QueryString["username"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from allPendingRequestsMS3('" + username + "') where status = 'unhandled'";


            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            string htmlStr = "";
            int i = 1;
            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string ClubRepresantative = rdr.GetString(0);
                string HostClubname = rdr.GetString(1);
                string GuestClubname = rdr.GetString(2);
                String MatchStartTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                String MatchEndTime = rdr.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string Status = rdr.GetString(5);
                htmlStr += "<tr><td>" + i + "</td><td>" + ClubRepresantative + "</td><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + MatchStartTime + "</td><td>" + MatchEndTime + "</td></tr>";
                i++;
            }

            return htmlStr;
        }

        protected void accept_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from allPendingRequestsMS3('" + username + "') where status = 'unhandled'";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            String temp = DropDownList1.SelectedItem.Value;
            if (!temp.Equals("Request no."))
            {
                int request_no = Int32.Parse(temp.Replace("Request number ", ""));

                int i = 1;
                conn.Open();
                SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    ClubRepresantative = rdr.GetString(0);
                    HostClubname = rdr.GetString(1);
                    GuestClubname = rdr.GetString(2);
                     MatchStartTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                     MatchEndTime = rdr.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Status = rdr.GetString(5);
                    if (i == request_no)
                    {
                        break;
                    }
                    i++;
                }
                conn.Close();


                SqlCommand AcceptReq = new SqlCommand("acceptRequest", conn);
                AcceptReq.CommandType = CommandType.StoredProcedure;

                AcceptReq.Parameters.Add(new SqlParameter("@SMusername", username));
                AcceptReq.Parameters.Add(new SqlParameter("@hostClub", HostClubname));
                AcceptReq.Parameters.Add(new SqlParameter("@competeClub", GuestClubname));
                AcceptReq.Parameters.Add(new SqlParameter("@startTime", MatchStartTime));
                Debug.Write(username+"\n");
                Debug.Write(HostClubname + "\n");
                Debug.Write(GuestClubname + "\n");
                Debug.Write(MatchStartTime + "\n");


                conn.Open();
                AcceptReq.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("HandleRequests.aspx?username=" + username + "");
            
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void reject_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from allPendingRequestsMS3('" + username + "') where status = 'unhandled'";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            String temp = DropDownList1.SelectedItem.Value;
            if (!temp.Equals("Request no."))
            {
                int request_no = Int32.Parse(temp.Replace("Request number ", ""));

                int i = 1;
                conn.Open();
                SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    ClubRepresantative = rdr.GetString(0);
                    HostClubname = rdr.GetString(1);
                    GuestClubname = rdr.GetString(2);
                     MatchStartTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                     MatchEndTime = rdr.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Status = rdr.GetString(5);
                    if (i == request_no)
                    {
                        break;
                    }
                    i++;
                }
                conn.Close();


                SqlCommand RejectReq = new SqlCommand("rejectRequest", conn);
                RejectReq.CommandType = CommandType.StoredProcedure;

                RejectReq.Parameters.Add(new SqlParameter("@SMusername", username));
                RejectReq.Parameters.Add(new SqlParameter("@hostClub", HostClubname));
                RejectReq.Parameters.Add(new SqlParameter("@competeClub", GuestClubname));
                RejectReq.Parameters.Add(new SqlParameter("@startTime", MatchStartTime));

                conn.Open();
                RejectReq.ExecuteNonQuery();
                conn.Close();
                Debug.Write("here\n");

            }
            Response.Redirect("HandleRequests.aspx?username=" + username + "");

        }
    }
}