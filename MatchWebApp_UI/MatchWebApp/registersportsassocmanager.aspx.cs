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
using System.Xml.Linq;

namespace MatchWebApp
{
    public partial class registersportsassocmanager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString["err"].ToString();
            Label1.Text = str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String Manname = name.Text;
            String username = Username.Text;
            String password = Password.Text;


            SqlCommand registerstadmanager = new SqlCommand("registersportsassocmanager", conn);
            registerstadmanager.CommandType = CommandType.StoredProcedure;

            registerstadmanager.Parameters.Add(new SqlParameter("@name", Manname));
            registerstadmanager.Parameters.Add(new SqlParameter("@username", username));
            registerstadmanager.Parameters.Add(new SqlParameter("@password", password));

            SqlParameter type = registerstadmanager.Parameters.Add("@type", SqlDbType.VarChar, 50);
            SqlParameter success = registerstadmanager.Parameters.Add("@suc", SqlDbType.Int);

            type.Direction = ParameterDirection.Output;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            registerstadmanager.ExecuteNonQuery();
            conn.Close();

            if (username.Equals("") || Manname.Equals("") || password.Equals(""))
            {
                String errormsg = "please fill in all of the fields";
                Label1.Text = errormsg;
                Response.Redirect("registersportsassocmanager.aspx?err=" + errormsg + " ");



            }
            else
            {
                if (success.Value.ToString().Equals("0"))
                {
                    //Debug.Write("here");
                    String errormsg = type.Value.ToString();
                    Label1.Text = errormsg;
                    Response.Redirect("registersportsassocmanager.aspx?err=" + errormsg + " ");


                }
                else
                {

                    Response.Redirect("SportsAssociationManager.aspx?username=" + username + " ");


                }
            }

        }
    }
}








    
