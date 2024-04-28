using Microsoft.Ajax.Utilities;
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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        public string query      = "";
        public string formTable  = "";
        public string uname      = "";
        public string fname      = "";
        public string lname      = "";
        public int bday          =  0;
        public string email      = "";
        public string phone      = "";
        public string pw         = "";
        public string Male       = "";
        public string Female     = "";
        public string H0         = "";
        public string H1         = "";
        public string H2         = "";
        public string H3         = "";
        public string H4         = "";
        public string Hadera     = "";
        public string TelAviv    = "";
        public string Jerusalem  = "";
        public string PetahTikva = "";
        public string Eilat      = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
                return;

            if (Request.Form["submit"] != null)
            {
                string uname = Request.Form["uname"];
                string fname = Request.Form["fname"];
                string lname = Request.Form["lname"];
                string email = Request.Form["email"];
                string gender = Request.Form["gender"];
                string phone = Request.Form["phone"];
                string bday = Request.Form["bday"];
                string hobbies = Request.Form["hobbies"];
                string city = Request.Form["city"];
                string pw = Request.Form["pw"];
                string pwConfirm = Request.Form["pwConfirm"];
                string hob1 = "f";
                string hob2 = "f";
                string hob3 = "f";
                string hob4 = "f";
                string hob5 = "f";

                if (hobbies != null)
                {
                    hobbies = Request.Form["hobbies"].ToString();
                    if (hobbies.Contains('0')) hob1 = "t";
                    if (hobbies.Contains('1')) hob2 = "t";
                    if (hobbies.Contains('2')) hob3 = "t";
                    if (hobbies.Contains('3')) hob4 = "t";
                    if (hobbies.Contains('4')) hob5 = "t";
                }

                string Hobbies = hob1 + hob2 + hob3 + hob4 + hob5;

                query = $"select * from UsersTBL where uname = '{uname}' and Id != {Session["Id"]}";
                DataTable table = Helper.ExecuteDataTable("PCWareDB.mdf", query);

                if (table.Rows.Count > 0)
                {
                    string style = $"{'"'}color: red; font-size: 3rem;{'"'}";
                    query = $"<b style={style}>Username Already Taken!</b>";
                }
                else
                {
                    query = $"update UsersTBL set " +
                    $"uname = '{uname}'," +
                    $" fname = '{fname}'," +
                    $" lname = '{lname}'," +
                    $" bday = {bday}," +
                    $" gender = '{gender}'," +
                    $" hobbies = '{Hobbies}'," +
                    $" city = '{city}'," +
                    $" email = '{email}'," +
                    $" phone = {phone}," +
                    $" pw = '{pw}'" +
                    $" where Id = {Session["Id"]}";
                    Helper.DoQuery("PCWareDB.mdf", query);

                    Session["uname"] = uname;
                    Session["fname"] = fname;
                    Session["lname"] = lname;
                    Session["bday"] = bday;
                    Session["gender"] = gender;
                    Session["hobbies"] = hobbies;
                    Session["city"] = city;
                    Session["email"] = email;
                    Session["phone"] = phone;
                    Session["pw"] = pw;
                    Response.Redirect("MainPage.aspx");
                }
            }

            uname = (string)Session["uname"];
            fname = (string)Session["fname"];
            lname = (string)Session["lname"];
            bday  = (int)   Session ["bday"];
            email = (string)Session["email"];
            phone = (string)Session["phone"];
            pw    = (string)Session   ["pw"];

            if (Session["gender"].Equals("Male"))
                Male = "checked";
            else
                Female = "checked";

            H0 = Session["hobbies"].ToString()[0] == 't' ? "checked" : "";
            H1 = Session["hobbies"].ToString()[1] == 't' ? "checked" : "";
            H2 = Session["hobbies"].ToString()[2] == 't' ? "checked" : "";
            H3 = Session["hobbies"].ToString()[3] == 't' ? "checked" : "";
            H4 = Session["hobbies"].ToString()[4] == 't' ? "checked" : "";

            Hadera     = Session["city"].ToString() == "Hadera"      ? "selected" : "";
            TelAviv    = Session["city"].ToString() == "Tel Aviv"    ? "selected" : "";
            Jerusalem  = Session["city"].ToString() == "Jerusalem"   ? "selected" : "";
            PetahTikva = Session["city"].ToString() == "Petah Tikva" ? "selected" : "";
            Eilat      = Session["city"].ToString() == "Eilat"       ? "selected" : "";
        }
    }
}