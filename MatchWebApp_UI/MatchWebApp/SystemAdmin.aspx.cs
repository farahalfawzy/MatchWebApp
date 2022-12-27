using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            String Cname = Club_name.Text;
            String location = Location.Text;
            SqlCommand addClub = new SqlCommand("addClub", conn);
            addClub.CommandType = CommandType.StoredProcedure;
            addClub.Parameters.Add(new SqlParameter("@clubName", Cname));
            addClub.Parameters.Add(new SqlParameter("@location", location));
            conn.Open();
            addClub.ExecuteNonQuery();
            conn.Close();


        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String Cname = delete_club.Text;
            SqlCommand deleteclub = new SqlCommand("deleteClub", conn);
            deleteclub.CommandType = CommandType.StoredProcedure;
            deleteclub.Parameters.Add(new SqlParameter("@clubName", Cname));
            conn.Open();
            deleteclub.ExecuteNonQuery();
            conn.Close();
        }

        protected void add_stadium_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String sname = Stadium_name.Text;
            String slocation = Stadium_location.Text;
            int capacity = Int32.Parse(Stadium_capacity.Text);

            SqlCommand addstadium = new SqlCommand("addStadium", conn);
            addstadium.CommandType = CommandType.StoredProcedure;

            addstadium.Parameters.Add(new SqlParameter("@sname", sname));
            addstadium.Parameters.Add(new SqlParameter("@location", slocation));
            addstadium.Parameters.Add(new SqlParameter("@capacity", capacity));

            conn.Open();
            addstadium.ExecuteNonQuery();
            conn.Close();
        }

        protected void delete_stadium_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String sname = Stadium_name.Text;

            SqlCommand delete_stadium = new SqlCommand("deleteStadium", conn);

            delete_stadium.CommandType = CommandType.StoredProcedure;
            delete_stadium.Parameters.Add(new SqlParameter("@sname", sname));

            conn.Open();
            delete_stadium.ExecuteNonQuery();
            conn.Close();
        }

        protected void Block_fan_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String n_id = Block_national_id.Text;
            SqlCommand block_fan = new SqlCommand("blockFan", conn);

            block_fan.CommandType = CommandType.StoredProcedure;
            block_fan.Parameters.Add(new SqlParameter("@national_id", n_id));

            conn.Open();
            block_fan.ExecuteNonQuery();
            conn.Close();


        }
    }
}