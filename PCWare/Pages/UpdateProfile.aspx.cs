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
        public string query = "";
        public string formTable = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["submit"] == null)
                return;

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
}