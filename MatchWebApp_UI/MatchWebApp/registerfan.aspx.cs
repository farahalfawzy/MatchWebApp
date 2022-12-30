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
    public partial class registerfan : System.Web.UI.Page
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
            

            String Fanname = name.Text;
            String username = Username.Text.ToLower();
            String password = Password.Text;
            String NationalId = NID.Text;
            String phone_number = phoneno.Text;
            String address = add.Text;
            String Birthdate = birthdate.Text;
            Debug.Write(Birthdate + "\n\n");

            if (username.Equals("") || Fanname.Equals("") || password.Equals("") || Birthdate == "" || NationalId.Equals("") || address.Equals("") || phone_number == null)
            {
                String errormsg = "please fill in all of the fields";
                Label1.Text = errormsg;
                Response.Redirect("registerfan.aspx?err=" + errormsg + " ");



            }
            else
            {
                int phonenumber = Int32.Parse(phoneno.Text);


                SqlCommand registerfan= new SqlCommand("registerfan", conn);
                registerfan.CommandType = CommandType.StoredProcedure;

                registerfan.Parameters.Add(new SqlParameter("@Fname", Fanname));
                registerfan.Parameters.Add(new SqlParameter("@username", username));
                registerfan.Parameters.Add(new SqlParameter("@password", password));
                registerfan.Parameters.Add(new SqlParameter("@n_id", NationalId));
                registerfan.Parameters.Add(new SqlParameter("@birth_date", Birthdate));
                registerfan.Parameters.Add(new SqlParameter("@address", address));
                registerfan.Parameters.Add(new SqlParameter("@phone_no", phonenumber));


                SqlParameter type = registerfan.Parameters.Add("@type", SqlDbType.VarChar, 50);
                SqlParameter success = registerfan.Parameters.Add("@suc", SqlDbType.Int);

                type.Direction = ParameterDirection.Output;
                success.Direction = ParameterDirection.Output;
                conn.Open();
                registerfan.ExecuteNonQuery();
                conn.Close();

                if (username.Equals("") || Fanname.Equals("") || password.Equals("") || Birthdate == "" || NationalId.Equals("") || address.Equals(""))
                {
                    String errormsg = "please fill in all of the fields";
                    Label1.Text = errormsg;
                    Response.Redirect("registerfan.aspx?err=" + errormsg + " ");

                }
                else
                {
                    if (success.Value.ToString().Equals("0"))
                    {
                        //Debug.Write("here");
                        String errormsg = type.Value.ToString();
                        Label1.Text = errormsg;
                        Response.Redirect("registerfan.aspx?err=" + errormsg + " ");


                    }
                    else
                    {
                        Response.Redirect("Fan.aspx?username=" + username + " ");
                    }
                }
            }
        }
    }
}