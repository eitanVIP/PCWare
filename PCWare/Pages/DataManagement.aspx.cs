using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare.Pages
{
    public partial class DataManagement : System.Web.UI.Page
    {
        public string msg;

        public string UsersQuery;
        public string UsersTable;

        public string BuildsQuery;
        public string BuildsTable;

        public string Query1;
        public string Query1Table;

        public string Query2;
        public string Query2Table;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                msg = $"<a href=\"SignIn.aspx\" style=\"font-size: 3rem;\" class=\"center\">Sign In!</a>";
                return;
            }

            if (!(bool)Session["admin"])
            {
                msg = $"<b class=\"center\" style=\"font-size: 3rem; color: red;\">Access Denied!</b>";
                return;
            }

            Delete();

            UsersQuery = "select * from UsersTBL";
            DataTable table = Helper.ExecuteDataTable("Banana ba tachat", UsersQuery);
            UsersTable = CreateTable(table);

            BuildsQuery = "select * from BuildsTBL";
            table = Helper.ExecuteDataTable("Banana ba tachat", BuildsQuery);
            BuildsTable = CreateTable(table);

            Query1 = "select * from UsersTBL where city = 'Hadera'";
            table = Helper.ExecuteDataTable("Banana ba tachat", Query1);
            Query1Table = CreateTable(table);

            Query2 = "select * from UsersTBL where (bday between 1997 and 2011) and gender = 'Male'";
            table = Helper.ExecuteDataTable("Banana ba tachat", Query2);
            Query2Table = CreateTable(table);
        }

        string CreateTable(DataTable table)
        {
            string result = "<table style=\"margin-top: 0px;\" class=\"styledTable\">" +
                "<tr>";

            for (int k = 0; k < table.Columns.Count; k++)
                result += $"<th>{table.Columns[k].ColumnName}</th>";

            result += "<th>Delete</th>" +
                "</tr>";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                result += $"<tr>";

                for (int j = 0; j < table.Rows[i].ItemArray.Length; j++)
                    result += $"<td>{table.Rows[i][j]}</td>";
                
                result += $"<td><input type=\"submit\" name=\"delete{table.Rows[i]["Id"]}\" value=\"Delete\" /></td>" +
                    $"</tr>";
            }

            result += "</table>";

            return result;
        }
    
        void Delete()
        {
            string query = "select * from UsersTBL";
            DataTable table = Helper.ExecuteDataTable("Banana ba tachat", query);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int id = (int)table.Rows[i]["Id"];

                if (Request.Form[$"delete{id}"] != null)
                {
                    query = $"delete from UsersTBL where Id = {id}";
                    Helper.DoQuery("Banana ba tachat", query);

                    query = $"delete from BuildsTBL where Id = {id}";
                    Helper.DoQuery("Banana ba tachat", query);
                }
            }
        }
    }
}