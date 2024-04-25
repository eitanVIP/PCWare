using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public string Name = "<div class=\"center\">Welcome Guest</div>";
        public string SignInOut;

        protected void Page_Load(object sender, EventArgs e)
        {
            SignInOut = $"<li class=\"SignInOutLink\"><a href=\"SignIn.aspx\"><div>Sign In</div></a></li>";

            if (Session["fname"] != null)
            {
                Name = $"<a href=\"UpdateProfile.aspx\"><div>Welcome {Session["fname"]} {Session["lname"]}</div></a>";
                SignInOut = $"<li class=\"SignInOutLink\"><a href=\"SignOut.aspx\"><div>Sign Out</div></a></li>";
            }
        }
    }
}