using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatchWebApp
{
    public partial class ClubRepresentative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Stadiums_Click(object sender, EventArgs e)
        {
            string Date = TextBox1.Text;
            Response.Redirect("allAvailableStadiums.aspx?Date=" + Date + " ");
        }
    }
}