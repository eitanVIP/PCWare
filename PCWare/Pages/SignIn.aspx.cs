using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare.Pages
{
    public partial class SignIn : System.Web.UI.Page
    {
        public string query = "";
        public string formTable = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["submit"] == null)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.Segments.Length >= 1)
                    Session["PrePage"] = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                
                return;
            }

            string uname = Request.Form["uname"];
            string pw = Request.Form["pw"];

            formTable = "<br /> <table class=\"styledTable\" style=\"margin-left: auto; margin-right: auto;\">";
            formTable += "<tr><td>uname:</td><td>" + uname + "</td></tr>";
            formTable += "<tr><td>pw:</td><td>" + pw + "</td></tr>";
            formTable += "</table>";

            query = $"select * from UsersTBL where uname = '{uname}' and pw = '{pw}'";
            DataTable table = Helper.ExecuteDataTable("PCWareDB.mdf", query);

            if (table.Rows.Count != 0)
            {
                Session["Id"] = table.Rows[0]["Id"];
                Session["uname"] = table.Rows[0]["uname"];
                Session["fname"] = table.Rows[0]["fname"];
                Session["lname"] = table.Rows[0]["lname"];
                Session["bday"] = table.Rows[0]["bday"];
                Session["gender"] = table.Rows[0]["gender"];
                Session["hobbies"] = table.Rows[0]["hobbies"];
                Session["city"] = table.Rows[0]["city"];
                Session["email"] = table.Rows[0]["email"];
                Session["tel"] = table.Rows[0]["phone"];
                Session["pw"] = table.Rows[0]["pw"];
                Session["admin"] = table.Rows[0]["admin"];

                Application.Lock();
                Application["Users"] = (int)Application["Users"] + 1;
                Application.UnLock();

                if(Session["PrePage"] != null)
                    Response.Redirect($"{Session["PrePage"]}.aspx");
            }
        }
    }
}