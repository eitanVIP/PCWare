using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCWare.Pages
{
    public partial class Build : System.Web.UI.Page
    {
        public string msg;
        public string Options;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                msg = $"<a href=\"SignIn.aspx\" style=\"font-size: 3rem;\" class=\"center\">Sign In!</a>";
                return;
            }

            if (Request.Form["submit"] != null)
                saveBuild();

            loadBuild();
        }

        void loadBuild()
        {
            string queryBuilds = $"select * from BuildsTBL where Id = {Session["Id"]}";
            DataTable tableBuilds = Helper.ExecuteDataTable("PCWare.mdf", queryBuilds);

            if (!IsPostBack)
                if (tableBuilds.Rows.Count != 0)
                    msg = $"<b class=\"center\" style=\"font-size: 3rem; color: lawngreen;\">Your Build Loaded</b>";

            string queryCPU = $"select * from CPUTBL order by PerformanceMark desc";
            DataTable tableCPU = Helper.ExecuteDataTable("PCWare.mdf", queryCPU);

            string queryMotherboard = $"select * from MotherboardTBL order by Price desc";
            DataTable tableMotherboard = Helper.ExecuteDataTable("PCWare.mdf", queryMotherboard);

            string queryRAM = $"select * from RAMTBL order by Volume desc";
            DataTable tableRAM = Helper.ExecuteDataTable("PCWare.mdf", queryRAM);

            string querySSD = $"select * from SSDTBL order by Volume desc";
            DataTable tableSSD = Helper.ExecuteDataTable("PCWare.mdf", querySSD);

            string queryHDD = $"select * from HDDTBL order by Volume desc";
            DataTable tableHDD = Helper.ExecuteDataTable("PCWare.mdf", queryHDD);

            string queryGPU = $"select * from GPUTBL order by PerformanceMark desc";
            DataTable tableGPU = Helper.ExecuteDataTable("PCWare.mdf", queryGPU);

            string queryPSU = $"select * from PSUTBL order by Watt desc";
            DataTable tablePSU = Helper.ExecuteDataTable("PCWare.mdf", queryPSU);

            string queryFan = $"select * from FanTBL order by Price desc";
            DataTable tableFan = Helper.ExecuteDataTable("PCWare.mdf", queryFan);

            string queryPCCase = $"select * from PCCaseTBL order by Size desc";
            DataTable tablePCCase = Helper.ExecuteDataTable("PCWare.mdf", queryPCCase);

            Options = CreateOptions(tableCPU, "CPU", tableBuilds);
            Options += CreateOptions(tableMotherboard, "Motherboard", tableBuilds);
            Options += CreateOptions(tableRAM, "RAM", tableBuilds);
            Options += CreateOptions(tableSSD, "SSD", tableBuilds);
            Options += CreateOptions(tableHDD, "HDD", tableBuilds);
            Options += CreateOptions(tableGPU, "GPU", tableBuilds);
            Options += CreateOptions(tablePSU, "PSU", tableBuilds);
            Options += CreateOptions(tableFan, "Fan", tableBuilds);
            Options += CreateOptions(tablePCCase, "PCCase", tableBuilds);
        }

        void saveBuild()
        {
            string CPU = Request.Form["CPU"];
            string Motherboard = Request.Form["Motherboard"];
            string RAM = Request.Form["RAM"];
            string SSD = Request.Form["SSD"];
            string HDD = Request.Form["HDD"];
            string GPU = Request.Form["GPU"];
            string PSU = Request.Form["PSU"];
            string Fan = Request.Form["Fan"];
            string PCCase = Request.Form["PCCase"];

            string saveQuery = $"select * from BuildsTBL where Id = {Session["Id"]}";
            DataTable saveTable = Helper.ExecuteDataTable("PCWare.mdf", saveQuery);

            if (saveTable.Rows.Count == 0)
            {
                saveQuery = $"insert into BuildsTBL " +
                    $"(Id, CPU, Motherboard, RAM, SSD, HDD, GPU, PSU, Fan, PCCase)" +
                    $" values ({Session["Id"]}, '{CPU}', '{Motherboard}', '{RAM}', '{SSD}', '{HDD}', '{GPU}', '{PSU}', '{Fan}', '{PCCase}')";
                Helper.DoQuery("PCWareDB.mdf", saveQuery);
            }
            else
            {
                saveQuery = $"update BuildsTBL set " +
                    $"CPU = '{CPU}'," +
                    $" Motherboard = '{Motherboard}'," +
                    $" RAM = '{RAM}'," +
                    $" SSD = '{SSD}'," +
                    $" HDD = '{HDD}'," +
                    $" GPU = '{GPU}'," +
                    $" PSU = '{PSU}'," +
                    $" Fan = '{Fan}'," +
                    $" PCCase = '{PCCase}'" +
                    $" where Id = {Session["id"]}";
                Helper.DoQuery("PCWareDB.mdf", saveQuery);
            }

            msg = $"<b class=\"center\" style=\"font-size: 3rem; color: lawngreen;\">Saved!</b>";
        }

        string CreateOptions(DataTable table, string item, DataTable tableBuilds)
        {
            string result = $"<li>\n<label for=\"{item}\">{item}:</label>\n" +
                $"<select id=\"{item}\" name=\"{item}\">";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string Name = (string)table.Rows[i]["Name"];
                string Selected = "";

                if (tableBuilds.Rows.Count != 0)
                    Selected = checkBuildItem(Name, tableBuilds, item) ? "selected" : "";

                result += $"<option value=\"{Name}\" {Selected}>{Name}</option>\n";
            }

            result += "</select>\n</li>";

            return result;
        }

        bool checkBuildItem(string name, DataTable table, string item)
        {
            if(table.Rows[0][item].GetType() == typeof(System.DBNull))
                return false;

            return name.Equals((string)table.Rows[0][item]);
        }
    }
}