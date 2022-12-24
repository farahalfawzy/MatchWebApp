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
    public partial class Log_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = Username.Text;
            String pass = Password.Text;
            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@username", username));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.VarChar, 20);
            SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString().Equals( "0"))
            {
                //Debug.Write("here");
                String errormsg = type.Value.ToString();
                Label1.Text=errormsg;
            }
            else
            {
                Label1.Text = "";
                Username.Text = "";
                Password.Text = "";
                if (type.Value.ToString().Equals("SystemAdmin"))
                {
                    Response.Redirect("SystemAdmin.aspx?username=" + username + " ");
                }
                if (type.Value.ToString().Equals("ClubRepresentative"))
                {
                    Response.Redirect("ClubRepresentative.aspx?username=" + username + " ");
                }
                if (type.Value.ToString().Equals("StadiumManager"))
                {
                    //send username to the stadium manager webpage and render it
                    Response.Redirect("StadiumManager.aspx?username=" + username + " ");
                }
                if (type.Value.ToString().Equals("SportsAssocManager"))
                {
                    Response.Redirect("SportsAssociationManager.aspx?username=" + username + " ");
                }
                if (type.Value.ToString().Equals("fan"))
                {
                    Response.Redirect("Fan.aspx?username=" + username + " ");
                }
            }

            //Debug.Write(type.Value.ToString());
            //Debug.Write(success.Value.ToString());

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");

        }
    }
}