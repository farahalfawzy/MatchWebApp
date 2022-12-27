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
            String host = hostClub.Text;
            String guest = guestClub.Text;
            String start = startTime.Text;
            String end = endTime.Text;
            String date = DateOfMatch.Text;


            Boolean flag1 = false;
            Boolean flag2 = false;
            Debug.Write(date + " " + start + "\n");
            Debug.Write(date + " " + end + "\n");


            SqlCommand loginproc = new SqlCommand("addNewMatch", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@hostClub", host));
            loginproc.Parameters.Add(new SqlParameter("@guestClub", guest));
            loginproc.Parameters.Add(new SqlParameter("@startTime", date + " " + start));
            loginproc.Parameters.Add(new SqlParameter("@endTime", date + " " + end));
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
                        flag2 = true;
                    }

                }
                conn.Close();
                if (flag1 == true && flag2 == true)
                {
                    conn.Open();

                    loginproc.ExecuteNonQuery();
                    label1.Text = "registered successfully";

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

    }
}