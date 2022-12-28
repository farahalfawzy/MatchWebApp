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
using System.Data.SqlTypes;


namespace MatchWebApp
{
    public partial class sportsAssociationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host = hostClub.Text.ToLower();
            String guest = guestClub.Text.ToLower();
            String start = startTime.Text;
            String end = endTime.Text;
            String date = DateOfMatch.Text;

            Boolean flag1 = false;
            Boolean flag2 = false;


            SqlCommand loginproc = new SqlCommand("addNewMatch", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@hostClub", host));
            loginproc.Parameters.Add(new SqlParameter("@guestClub", guest));
            loginproc.Parameters.Add(new SqlParameter("@startTime", date + " " + start));
            loginproc.Parameters.Add(new SqlParameter("@endTime", date + " " + end));
            SqlCommand allClubs = new SqlCommand("select * from club", conn);
            conn.Open();
            SqlDataReader rdr = allClubs.ExecuteReader(CommandBehavior.CloseConnection);
            if (start == "" || end == "" || date == "")
            {
                String errormsg = "pick start time,end time and date";
                label1.Text = errormsg;
            }
            else if (host == "" || guest == "")
            {
                String errormsg = "pick a host club and a guest club";
                label1.Text = errormsg;
            }

            else if (host != guest)
            {
                while (rdr.Read())
                {
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    if (name.Equals(host))
                    {
                        flag1 = true;
                    }
                    if (name.Equals(guest))
                    {
                        flag2 = true;
                    }

                }
                conn.Close();
                if (flag1 == true && flag2 == true)
                {
                    conn.Open();

                    loginproc.ExecuteNonQuery();
                    label1.Text = "match added successfully";

                }
                else
                {
                    String errormsg = "club may not registered";
                    guestClub.Text = errormsg;
                    hostClub.Text = errormsg;
                    label1.Text = "";


                }


            }

            else
            {
                String errormsg = "hostclub and guestclub can't be the same";
                guestClub.Text = errormsg;
                hostClub.Text = errormsg;
                label1.Text = "";

            }



            conn.Close();
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host = hostClub1.Text.ToLower();
            String guest = guestClub1.Text.ToLower();
            String start = startTime1.Text;
            String end = endTime1.Text;
            String date = DateOfMatch1.Text;
            Boolean flag1 = false;
            Boolean flag2 = false;

            SqlCommand find = new SqlCommand("MatchExists", conn);
            find.CommandType = CommandType.StoredProcedure;
            find.Parameters.Add(new SqlParameter("@hostClub", host));
            find.Parameters.Add(new SqlParameter("@guestClub", guest));
            find.Parameters.Add(new SqlParameter("@startTime", date + " " + start));
            find.Parameters.Add(new SqlParameter("@endTime", date + " " + end));
            SqlParameter check = find.Parameters.Add("@check", SqlDbType.Int);
            check.Direction = ParameterDirection.Output;
            conn.Open();
            find.ExecuteNonQuery();
            conn.Close();

            if (check.Value.ToString().Equals("0"))
            {
                label2.Text = "this match doesnt exist";
            }
            else if (!(check.Value.ToString().Equals("0")))
            {

                SqlCommand loginproc = new SqlCommand("deleteMatch", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@hostClub", host));
                loginproc.Parameters.Add(new SqlParameter("@guestClub", guest));
                loginproc.Parameters.Add(new SqlParameter("@startTime", date + " " + start));
                loginproc.Parameters.Add(new SqlParameter("@endTime", date + " " + end));
                SqlCommand allClubs = new SqlCommand("select * from club", conn);
                conn.Open();
                SqlDataReader rdr = allClubs.ExecuteReader(CommandBehavior.CloseConnection);
                if (start == "" || end == "" || date == "")
                {
                    String errormsg = "pick start time,end time and date";
                    label2.Text = errormsg;
                }
                else if (host == "" || guest == "")
                {
                    String errormsg = "pick a host club and a guest club";
                    label2.Text = errormsg;
                }

                else if (host != guest)
                {
                    while (rdr.Read())
                    {
                        String name = rdr.GetString(rdr.GetOrdinal("name"));
                        if (name.Equals(host))
                        {
                            flag1 = true;
                        }
                        if (name.Equals(guest))
                        {
                            flag2 = true;
                        }

                    }
                    conn.Close();
                    if (flag1 == true && flag2 == true)
                    {
                        conn.Open();

                        loginproc.ExecuteNonQuery();
                        label2.Text = "match deleted successfully";

                    }
                    else
                    {
                        String errormsg = "club may not registered";
                        guestClub1.Text = errormsg;
                        hostClub1.Text = errormsg;
                        label2.Text = "";


                    }


                }

                else
                {
                    String errormsg = "hostclub and guestclub can't be the same";
                    guestClub1.Text = errormsg;
                    hostClub1.Text = errormsg;
                    label2.Text = "";


                }



                conn.Close();
            }

        }
        public string getWhileLoopData()
        {


            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from upcomingMatches()";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            string htmlStr = "";
            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);
                String MatchStartTime = rdr.GetDateTime(2).ToString("yyyy-MM-dd HH:mm:ss.fff");
                String MatchEndTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                htmlStr += "</tr><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + MatchStartTime + "</td><td>" + MatchEndTime + "</td><tr>";
            }

            conn.Close();
            return htmlStr;
        }


        public string getWhileLoopData1()
        {


            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from AlreadyPlayedMatches()";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            string htmlStr = "";

            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);
                String MatchStartTime = rdr.GetDateTime(2).ToString("yyyy-MM-dd HH:mm:ss.fff");
                String MatchEndTime = rdr.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.fff");
                htmlStr += "</tr><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><td>" + MatchStartTime + "</td><td>" + MatchEndTime + "</td><tr>";
            }

            conn.Close();
            return htmlStr;
        }

        public string getWhileLoopData2()
        {


            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from MatchesNeverPlayed";
            SqlCommand allStadiumManagers = new SqlCommand(str, conn);
            string htmlStr = "";

            conn.Open();
            SqlDataReader rdr = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                string HostClubname = rdr.GetString(0);
                string GuestClubname = rdr.GetString(1);

                htmlStr += "</tr><td>" + HostClubname + "</td><td>" + GuestClubname + "</td><tr>";
            }

            conn.Close();
            return htmlStr;
        }





    }

}