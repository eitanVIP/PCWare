using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare.Pages
{
    public partial class Compare : System.Web.UI.Page
    {
        public string CompareTable;

        public string Option1;
        public string Option2;

        public string CompareInput;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["choose"] != null)
                Session["CompareItem"] = Request.Form["Item"];

            if (Request.Form["compare"] != null)
            {
                Session["CompareName1"] = Request.Form["CompareName1"];
                Session["CompareName2"] = Request.Form["CompareName2"];
            }

            if (!IsPostBack)
                return;

            string query = $"select * from {Session["CompareItem"]}TBL order by Price desc";
            DataTable table = Helper.ExecuteDataTable("PCWare.mdf", query);

            Option1 = CreateOptions(table, 1);
            Option2 = CreateOptions(table, 2);
            CompareInput = "<li><input style=\"margin-bottom: 10px;\" type=\"submit\" name=\"compare\" value=\"Compare\" /></li>";

            if (Request.Form["compare"] == null)
                return;

            CompareTable = CreateTable(table);
        }

        string CreateOptions(DataTable table, int num)
        {
            string result = $"<li>\n" +
                $"<select style=\"margin-bottom: 10px;\" id=\"CompareName{num}\" name=\"CompareName{num}\">";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string Name = (string)table.Rows[i]["Name"];
                string Selected = Name.Equals(Session[$"CompareName{num}"]) ? "selected" : "";

                result += $"<option value=\"{Name}\" {Selected}>{Name}</option>\n";
            }

            result += "</select>\n</li>";

            return result;
        }

        string CreateTable(DataTable table)
        {
            string result = "<table style=\"margin-top: 20px; margin-left: 20px;\" class=\"styledTable\">" +
                "<tr>" +
                $"<th>\\</th>" +
                $"<th>{Session["CompareName1"]}</th>" +
                $"<th>{Session["CompareName2"]}</th></tr>" +
                "</tr>";

            for (int i = 1; i < table.Columns.Count; i++)
            {
                string columnName = table.Columns[i].ColumnName;
                DataRow option1Row = GetRow(table, (string)Session["CompareName1"]);
                DataRow option2Row = GetRow(table, (string)Session["CompareName2"]);
                object option1Value = option1Row[columnName];
                object option2Value = option2Row[columnName];

                result += $"<tr>";

                result += $"<td>{columnName}</td>";
                result += $"<td>{option1Value}</td>";
                result += $"<td>{option2Value}</td>";
                
                result += $"</tr>";
            }

            result += "</table>";

            return result;
        }

        DataRow GetRow(DataTable table, string name)
        {
            for (int i = 0; i < table.Rows.Count; i++)
                if (table.Rows[i][0].Equals(name))
                    return table.Rows[i];

            return null;
        }
    }
}