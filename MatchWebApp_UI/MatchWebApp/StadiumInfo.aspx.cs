using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatchWebApp
{
    public partial class StadiumInfo : System.Web.UI.Page
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

            Label1.Text = username;


            SqlCommand AllStadInfo = new SqlCommand("select sm.username , s.* from Stadium s , StadiumManager sm where s.id=sm.stadium_id ", conn);

            conn.Open();
            SqlDataReader rdr2 = AllStadInfo.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                String usernametemp = rdr2.GetString(rdr2.GetOrdinal("username"));
                if (usernametemp.Equals(username)) {
                    int Sid = rdr2.GetInt32(rdr2.GetOrdinal("Id"));
                    String Sname = rdr2.GetString(rdr2.GetOrdinal("Name"));
                    String Sloc = rdr2.GetString(rdr2.GetOrdinal("Location"));
                    Boolean Sstatus = rdr2.GetBoolean(rdr2.GetOrdinal("Status"));
                    int Scap = rdr2.GetInt32(rdr2.GetOrdinal("Capacity"));
                    ID.Text = Sid + "";
                    name.Text = Sname;
                    location.Text = Sloc;
                    cap.Text = Scap + "";
                    if (Sstatus.Equals(true))
                    {
                        status.Text = "Available";
                    }
                    else
                    {
                        status.Text = "Not Avaialable";
                    }
                    break;
                }

            }
        }
    }
}