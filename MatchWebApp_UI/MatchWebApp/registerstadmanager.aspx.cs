using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Diagnostics;

namespace MatchWebApp
{
    public partial class registerstadmanager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill label with empty string if first time rendering or error message
            string str = Request.QueryString["err"].ToString();
            Label1.Text = str;

            
            //fill drop down list
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand allStadiums = new SqlCommand("SELECT name from allStadiums", conn);

            conn.Open();
            SqlDataReader rdr = allStadiums.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                DropDownList1.Items.Add(name);
                
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String Managername = name.Text;
            String username = Username.Text;
            String password = Password.Text;
            String stadium = DropDownList1.SelectedItem.Value;


            SqlCommand registerstadmanager = new SqlCommand("registerstadiummanager", conn);
            registerstadmanager.CommandType = CommandType.StoredProcedure;

            registerstadmanager.Parameters.Add(new SqlParameter("@mname", Managername));
            registerstadmanager.Parameters.Add(new SqlParameter("@sname", stadium));
            registerstadmanager.Parameters.Add(new SqlParameter("@username", username));
            registerstadmanager.Parameters.Add(new SqlParameter("@password", password));

            SqlParameter type = registerstadmanager.Parameters.Add("@type", SqlDbType.VarChar, 50);
            SqlParameter success = registerstadmanager.Parameters.Add("@suc", SqlDbType.Int);

            type.Direction = ParameterDirection.Output;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            registerstadmanager.ExecuteNonQuery();
            conn.Close();

            if (username.Equals("") || Managername.Equals("") || password.Equals(""))
            {
                String errormsg = "please fill in all of the fields";
                Label1.Text = errormsg;
                Response.Redirect("registerstadmanager.aspx?err='" + errormsg + "' ");



            }
            else
            {
                if (success.Value.ToString().Equals("0"))
                {
                    //Debug.Write("here");
                    String errormsg = type.Value.ToString();
                    Label1.Text = errormsg;
                    Response.Redirect("registerstadmanager.aspx?err=" + errormsg + " ");


                }
                else
                {
                    
                    Response.Redirect("registerstadmanager.aspx?username=" + username + " ");


                }
            }

        }
    }
}