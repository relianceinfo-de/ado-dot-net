using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.CData.AzureDevOps;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Azure_ADO_App.Models;


namespace Test_Azure_ADO_App.Controllers
{
    public class HomeController : Controller
    {
        private static string PAT = ConfigurationManager.AppSettings["PersonalAccessToken"];
        public ActionResult Index()
        {
            var result = LoadData();
            return View(result);
        }

        public ActionResult About()
        {

            var result = LoadDataBuilds();
            return View(result);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Project> lstProjects = new List<Project>();

        public List<Project> LoadData()
        {
            using (AzureDevOpsConnection connection = new AzureDevOpsConnection($"AuthScheme=Basic;Organization=griffinv4;ProjectId=GriffinERP;PersonalAccessToken={PAT};"))
            {
                connection.Open();

                AzureDevOpsCommand cmd = new AzureDevOpsCommand("SELECT * FROM Projects", connection);

                AzureDevOpsDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Project proj = new Project();
                    proj.Id = Convert.ToString(rdr["Id"]);
                    proj.LastUpdateTime = Convert.ToDateTime(rdr["LastUpdateTime"]);
                    proj.Name = Convert.ToString(rdr["Name"]);
                    proj.Revision = Convert.ToInt32(rdr["Revision"]);
                    proj.State = Convert.ToString(rdr["State"]);
                    proj.Url = Convert.ToString(rdr["Url"]);

                    //proj.CapabilitiesVersionControlGitEnabled = rdr["CapabilitiesVersionControlGitEnabled"] != null ? Convert.ToBoolean(rdr["CapabilitiesVersionControlGitEnabled"]) : false;

                    lstProjects.Add(proj);
                }

                rdr.Close();

                return lstProjects;

            }
        }

        public List<Builds> lstBuilds = new List<Builds>();
        public List<Builds> LoadDataBuilds()
        {
           
            using (AzureDevOpsConnection connection = new AzureDevOpsConnection($"AuthScheme=Basic;Organization=griffinv4;ProjectId=GriffinERP;PersonalAccessToken={PAT};"))
            {
                connection.Open();

                AzureDevOpsCommand cmd = new AzureDevOpsCommand("SELECT * FROM Builds", connection);

                AzureDevOpsDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Builds build = new Builds();
                    build.AgentSpecificationIdentifier = Convert.ToString(rdr["AgentSpecificationIdentifier"]);
                    build.BuildNumber = Convert.ToString(rdr["BuildNumber"]);
                    build.BuildNumberRevision = Convert.ToInt32(rdr["BuildNumberRevision"]);
                   // build.ControllerCreatedDate = Convert.ToDateTime(rdr["ControllerCreatedDate"]);
                    build.ControllerDescription = Convert.ToString(rdr["ControllerDescription"]);
                    //build.ControllerEnabled = Convert.ToBoolean(rdr["ControllerEnabled"]);
                    //build.ControllerId = Convert.ToInt32(rdr["ControllerId"]);

                    //proj.CapabilitiesVersionControlGitEnabled = rdr["CapabilitiesVersionControlGitEnabled"] != null ? Convert.ToBoolean(rdr["CapabilitiesVersionControlGitEnabled"]) : false;

                    lstBuilds.Add(build);
                }

                rdr.Close();

                return lstBuilds;

            }
        }
    }
}