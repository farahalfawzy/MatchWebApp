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
    public partial class clubRepresentative : System.Web.UI.Page
    {
        String username;
        String N;
        String Club;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            username = Request.QueryString["username"].ToString();
            Label1.Text = Request.QueryString["err"].ToString();
            Label2.Text = Request.QueryString["err2"].ToString();

            SqlCommand allStadiumManagers = new SqlCommand("select name from StadiumManager", conn);

            conn.Open();
            SqlDataReader rdr2 = allStadiumManagers.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                stadiumManagers.Items.Add(rdr2.GetString(0));
            }
            conn.Close();

            SqlCommand clubR = new SqlCommand("representativeClub", conn);
            clubR.CommandType = CommandType.StoredProcedure;
            clubR.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter Name = clubR.Parameters.Add("@Club", SqlDbType.VarChar, 20);
            Name.Direction = ParameterDirection.Output;
            conn.Open();
            clubR.ExecuteNonQuery();
            Club = Name.Value.ToString();
            conn.Close();

            SqlCommand MatchesR = new SqlCommand("allMatchesR", conn);
            MatchesR.CommandType = CommandType.StoredProcedure;
            MatchesR.Parameters.Add(new SqlParameter("@club", Club));
            conn.Open();
            MatchesR.ExecuteNonQuery();
            SqlDataReader rdr = MatchesR.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                MatchTimes.Items.Add(rdr.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
            conn.Close();


        }

        protected void clubInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("clubInfo.aspx?username=" + username + "");
            //upcomingMatchesOfClub
        }

        protected void Upcoming_Matches_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand RepClub = new SqlCommand("representativeClub", conn);
            RepClub.CommandType = CommandType.StoredProcedure;
            RepClub.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter Name = RepClub.Parameters.Add("@Club", SqlDbType.VarChar, 20);
            Name.Direction = ParameterDirection.Output;
            conn.Open();
            RepClub.ExecuteNonQuery();
            conn.Close();
            N = Name.Value.ToString();
            Debug.WriteLine("\n\n\n" + N + "\n\n\n");
            Response.Redirect("UpComingMatches.aspx?Club=" + N + " ");

        }

        protected void Stadiums_Click(object sender, EventArgs e)
        {
            string Date = TextBox1.Text+" "+ TextBox2;
            if (TextBox1.Text.Equals("") || TextBox2.Equals(""))
                Response.Redirect("ClubRepresentative.aspx?username=" + username + "&err= please fill all fields &err2= ");
            else
            Response.Redirect("allAvailableStadiums.aspx?Date=" + Date + " ");
        }

        protected void Request_Click(object sender, EventArgs e)
        {
            String Manager = stadiumManagers.SelectedItem.Value;
            String Time = MatchTimes.SelectedItem.Value;
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand HostRequest = new SqlCommand("abdoHostRequest", conn);
            HostRequest.CommandType = CommandType.StoredProcedure;
            HostRequest.Parameters.Add(new SqlParameter("@cname", Club));
            HostRequest.Parameters.Add(new SqlParameter("@mname", Manager));
            Debug.Write(Time+"\n");
            HostRequest.Parameters.Add(new SqlParameter("@timeofmatch", Time));
            SqlParameter success = HostRequest.Parameters.Add("@suc", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            conn.Open();
            HostRequest.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString().Equals("0"))
            {
                Response.Redirect("ClubRepresentative.aspx?username=" + username + "&err= &err2='Request already exists'");

            }
            else
            {
                Response.Redirect("ClubRepresentative.aspx?username=" + username + "&err= &err2='Request Added Successfully'");
            }
        }
    }
}