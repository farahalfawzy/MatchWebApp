using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System;

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
    public partial class sportsAssociationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host = hostClub.Text;
            String guest = guestClub.Text;
            String start = startTime.Text;
            String end = endTime.Text;
            Boolean flag1 = false;
            Boolean flag2 = false;

            SqlCommand loginproc = new SqlCommand("addNewMatch", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@hostClub", host));
            loginproc.Parameters.Add(new SqlParameter("@guestClub", guest));
            loginproc.Parameters.Add(new SqlParameter("@startTime", start));
            loginproc.Parameters.Add(new SqlParameter("@endTime", end));
            SqlCommand allClubs = new SqlCommand("select * from club", conn);
            conn.Open();
            SqlDataReader rdr = allClubs.ExecuteReader(CommandBehavior.CloseConnection);
            if (start == "" || end == "")
            {
                String errormsg = "pick a date";
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

                }
                else
                {
                    String errormsg = "club may not registered";
                    guestClub.Text = errormsg;
                    hostClub.Text = errormsg;

                }


            }

            else
            {
                String errormsg = "hostclub and guestclub can't be the same";
                guestClub.Text = errormsg;
                hostClub.Text = errormsg;

            }



            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host1 = hostClub1.Text;
            String guest1 = guestClub1.Text;
            String start1 = startTime1.Text;
            String end1 = endTime1.Text;
            Boolean flag3 = false;
            Boolean flag4 = false;

            SqlCommand loginproc = new SqlCommand("deleteMatch", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@hostClub", host1));
            loginproc.Parameters.Add(new SqlParameter("@guestClub", guest1));
            loginproc.Parameters.Add(new SqlParameter("@startTime", start1));
            loginproc.Parameters.Add(new SqlParameter("@endTime", end1));
            SqlCommand allClubs = new SqlCommand("select * from club", conn);
            conn.Open();
            SqlDataReader rdr = allClubs.ExecuteReader(CommandBehavior.CloseConnection);
            if (start1 == "" || end1 == "")
            {
                String errormsg = "pick a date";
                label2.Text = errormsg;
            }

            else if (host1 != guest1)
            {
                while (rdr.Read())
                {
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    if (name.Equals(host1))
                    {
                        flag3 = true;
                    }
                    if (name.Equals(guest1))
                    {
                        flag4 = true;
                    }

                }
                conn.Close();
                if (flag3 == true && flag4 == true)
                {
                    conn.Open();

                    loginproc.ExecuteNonQuery();

                }
                else
                {
                    String errormsg = "club may not registered";
                    guestClub1.Text = errormsg;
                    hostClub1.Text = errormsg;

                }


            }

            else
            {
                String errormsg = "hostclub and guestclub can't be the same";
                guestClub1.Text = errormsg;
                hostClub1.Text = errormsg;

            }



            conn.Close();
        }
    }
}