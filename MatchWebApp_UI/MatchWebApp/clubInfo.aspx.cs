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
using System.Xml.Linq;


namespace MatchWebApp
{
    public partial class clubInfo : System.Web.UI.Page
    {
        String username;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            username = Request.QueryString["username"].ToString();
            Debug.WriteLine(username + "\n\n");

            SqlCommand allClubRep = new SqlCommand("allClubRepresenting", conn);
            allClubRep.CommandType = CommandType.StoredProcedure;
            allClubRep.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter Id = allClubRep.Parameters.Add("@id", SqlDbType.Int);
            SqlParameter Name = allClubRep.Parameters.Add("@Name", SqlDbType.VarChar, 20);
            SqlParameter Loc = allClubRep.Parameters.Add("@Location", SqlDbType.VarChar, 20);
            Id.Direction = ParameterDirection.Output;
            Name.Direction = ParameterDirection.Output;
            Loc.Direction = ParameterDirection.Output;
            conn.Open();
            allClubRep.ExecuteNonQuery();
            conn.Close();
            ID1.Text = "ID:" + Id.Value.ToString();
            name.Text = "Name:" + Name.Value.ToString();
            loc.Text = "Location:" + Loc.Value.ToString();

        }
    }
}