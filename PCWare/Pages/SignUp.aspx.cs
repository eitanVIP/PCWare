﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare.Pages
{
    public partial class SignUp : System.Web.UI.Page
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

            formTable = "<table class=\"styledTable\" style=\"margin-left: auto; margin-right: auto;\">";
            formTable += "<tr><td>uname:</td><td>" + uname + "</td></tr>";
            formTable += "<tr><td>fname:</td><td>" + fname + "</td></tr>";
            formTable += "<tr><td>lname:</td><td>" + lname + "</td></tr>";
            formTable += "<tr><td>bday:</td><td>" + bday + "</td></tr>";
            formTable += "<tr><td>gender:</td><td>" + gender + "</td></tr>";
            formTable += "<tr><td>hobbies:</td><td>" + Hobbies + "</td></tr>";
            formTable += "<tr><td>email:</td><td>" + email + "</td></tr>";
            formTable += "<tr><td>phone:</td><td>" + phone + "</td></tr>";
            formTable += "<tr><td>pw:</td><td>" + pw + "</td></tr>";
            formTable += "<tr><td>pwConfirm:</td><td>" + pwConfirm + "</td></tr>";
            formTable += "</table> <br />";
            formTable = "";

            query = $"select * from UsersTBL where uname = '{uname}'";
            DataTable table = Helper.ExecuteDataTable("PCWareDB.mdf", query);

            if(table.Rows.Count > 0)
            {
                string style = $"{'"'}color: red; font-size: 3rem;{'"'}";
                query = $"<b style={style}>Username Already Taken!</b>";
                return;
            }

            DataRowCollection rows = Helper.ExecuteDataTable("PCWareDB.mdf", "select * from usersTBL").Rows;
            int id = (int)rows[rows.Count - 1]["Id"] + 1;
            query = $"insert into UsersTBL (Id, uname, fname, lname, bday, gender, hobbies, city, email, phone, pw, admin) values ({id}, '{uname}', '{fname}', '{lname}', {bday}, '{gender}', '{Hobbies}', '{city}', '{email}', '{phone}', '{pw}', 0)";
            Helper.DoQuery("PCWareDB.mdf", query);
            
            Session["id"] = id;
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
            Session["admin"] = false;

            Application.Lock();
            Application["Users"] = (int)Application["Users"] + 1;
            Application.UnLock();

            Response.Redirect("MainPage.aspx");
        }
    }
}