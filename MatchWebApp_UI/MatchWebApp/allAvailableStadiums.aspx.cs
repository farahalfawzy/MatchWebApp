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
    public partial class allAvailableStadiums : System.Web.UI.Page
    {
        String Date;
        protected void Page_Load(object sender, EventArgs e)
        {
            Date = Request.QueryString["Date"].ToString();
            Debug.WriteLine("\n\n\n" + Date + "\n\n\n");
        }

        public string getWhileLoopData()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MatchWebApp"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String str = "select * from viewAvailableStadiumsOn('" + Date + "')";
            Debug.WriteLine("\n\n\n" + str + "\n\n\n");
            SqlCommand viewAvailableStadiumsOn = new SqlCommand(str, conn);
            string htmlStr = "";
            conn.Open();
            SqlDataReader rdr = viewAvailableStadiumsOn.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string Name = rdr.GetString(0);
                string Loc = rdr.GetString(1);
                int Capacity = rdr.GetInt32(2);
                htmlStr += "<tr><td>" + Name + "</td><td>" + Loc + "</td><td>" + Capacity+  "</td></tr>";
                Debug.WriteLine(htmlStr);
            }

            conn.Close();
            return htmlStr;
        }
    }
}
