using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MatchWebApp
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Club_name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Location_TextChanged(object sender, EventArgs e)
        {

        }

        protected void delete_club_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Stadium_name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Stadium_location_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Stadium_capacity_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Delete_stadium_name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Block_national_id_TextChanged(object sender, EventArgs e)
        {

        }

        protected void add_new_club_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String Cname = Club_name.Text.ToLower();
            String location = Location.Text.ToLower();
            SqlCommand addClub = new SqlCommand("addClub", conn);
            addClub.CommandType = CommandType.StoredProcedure;
            addClub.Parameters.Add(new SqlParameter("@clubName", Cname));
            addClub.Parameters.Add(new SqlParameter("@location", location));
            conn.Open();
            addClub.ExecuteNonQuery();
            Club_name.Text = "club added successfully";
            Location.Text = "";
            conn.Close();


        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String Cname = delete_club.Text.ToLower();
            SqlCommand deleteclub = new SqlCommand("deleteClub", conn);
            deleteclub.CommandType = CommandType.StoredProcedure;
            deleteclub.Parameters.Add(new SqlParameter("@clubName", Cname));
            SqlCommand allClubs = new SqlCommand("select * from Club", conn);

            conn.Open();
            SqlDataReader rdr = allClubs.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));


                if (name.Equals(Cname))
                {


                    flag = true;

                }


            }
            if (flag == true)
            {
                conn.Close();
                conn.Open();
                deleteclub.ExecuteNonQuery();
                delete_club.Text = "club deleted successfully";

            }
            else
            {
                delete_club.Text = "this club doesnt exist";
            }


            conn.Close();
        }

        protected void add_stadium_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String sname = Stadium_name.Text.ToLower();
            String slocation = Stadium_location.Text.ToLower();
            int capacity = Int32.Parse(Stadium_capacity.Text);

            SqlCommand addstadium = new SqlCommand("addStadium", conn);
            addstadium.CommandType = CommandType.StoredProcedure;

            addstadium.Parameters.Add(new SqlParameter("@sname", sname));
            addstadium.Parameters.Add(new SqlParameter("@location", slocation));
            addstadium.Parameters.Add(new SqlParameter("@capacity", capacity));

            conn.Open();

            addstadium.ExecuteNonQuery();
            Stadium_name.Text = "stadium added successfully";
            Stadium_location.Text = "";
            Stadium_capacity.Text = "";
            conn.Close();
        }

        protected void delete_stadium_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String sname = Delete_stadium_name.Text.ToLower();

            SqlCommand delete_stadium = new SqlCommand("deleteStadium", conn);

            delete_stadium.CommandType = CommandType.StoredProcedure;
            delete_stadium.Parameters.Add(new SqlParameter("@sname", sname));


            SqlCommand allstadiums = new SqlCommand("select * from Stadium", conn);

            conn.Open();
            SqlDataReader rdr = allstadiums.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));


                if (name.Equals(sname))
                {


                    flag = true;

                }


            }
            if (flag == true)
            {
                conn.Close();
                conn.Open();
                delete_stadium.ExecuteNonQuery();
                Delete_stadium_name.Text = "stadium deleted successfully";


            }
            else
            {
                Delete_stadium_name.Text = "this stadium doesnt exist";


            }


            conn.Close();
        }

        protected void Block_fan_Click(object sender, EventArgs e)
        {
            Boolean flag1 = false;
            Boolean flag2 = false;

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String n_id = Block_national_id.Text.ToLower();
            SqlCommand block_fan = new SqlCommand("blockFan", conn);

            block_fan.CommandType = CommandType.StoredProcedure;
            block_fan.Parameters.Add(new SqlParameter("@national_id", n_id));

            SqlCommand allfans = new SqlCommand("select * from fan", conn);

            conn.Open();
            SqlDataReader rdr = allfans.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String NID = rdr[0].ToString();
                String status = rdr[5].ToString();
                Debug.Write(status);


                if (NID.Equals(n_id))
                {


                    flag1 = true;
                    if (status == "False")
                    {
                        flag2 = true;
                    }

                }


            }
            if (flag1 == true)
            {
                if (flag2 == true)
                {
                    Block_national_id.Text = "this fan is already blocked";

                }
                else
                {
                    conn.Close();
                    conn.Open();
                    block_fan.ExecuteNonQuery();
                    Block_national_id.Text = "fan blocked successfully";
                }

            }
            else
            {
                Block_national_id.Text = "this fan doesnt exist";


            }


            conn.Close();



        }
    }
}
