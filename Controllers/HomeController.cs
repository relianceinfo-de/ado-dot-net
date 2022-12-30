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
            var result = LoadDataWorklist();

            return View(result);
        }

        public ActionResult Team()
        {
            var result = LoadDataTeams();

            return View(result);
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
                    //var contollerCreatedDate = rdr["ControllerCreatedDate"];
                    //if (contollerCreatedDate != String.Empty)
                    //{
                    //    build.ControllerCreatedDate = Convert.ToDateTime(rdr["ControllerCreatedDate"]);
                    //}

                    build.ControllerDescription = Convert.ToString(rdr["ControllerDescription"]);
                    //var controllerEnabled = rdr["ControllerEnabled"];
                    //if (controllerEnabled != null)
                    //{
                    //    build.ControllerEnabled = Convert.ToBoolean(rdr["ControllerEnabled"]);
                    //}

                    //build.ControllerId = Convert.ToInt32(rdr["ControllerId"]);

                    //proj.CapabilitiesVersionControlGitEnabled = rdr["CapabilitiesVersionControlGitEnabled"] != null ? Convert.ToBoolean(rdr["CapabilitiesVersionControlGitEnabled"]) : false;

                    lstBuilds.Add(build);
                }

                rdr.Close();

                return lstBuilds;

            }
        }

        public List<WorkItems> lstWorklist = new List<WorkItems>();
        public List<WorkItems> LoadDataWorklist()
        {

            using (AzureDevOpsConnection connection = new AzureDevOpsConnection($"AuthScheme=Basic;Organization=griffinv4;ProjectId=GriffinERP;PersonalAccessToken={PAT};"))
            {
                connection.Open();

                AzureDevOpsCommand cmd = new AzureDevOpsCommand("SELECT * FROM WorkItems", connection);

                AzureDevOpsDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    WorkItems wrklist = new WorkItems();
                    wrklist.Id = Convert.ToInt32(rdr["Id"]);
                    wrklist.LinksSelfHref = Convert.ToString(rdr["LinksSelfHref"]);
                    wrklist.LinksFieldsHref = Convert.ToString(rdr["LinksFieldsHref"]);
                    wrklist.LinksHtmlHref = Convert.ToString(rdr["LinksHtmlHref"]);
                    wrklist.LinksWorkItemHistoryHref = Convert.ToString(rdr["LinksWorkItemHistoryHref"]);
                    wrklist.LinksWorkItemRevisionsHref = Convert.ToString(rdr["LinksWorkItemRevisionsHref"]);
                    wrklist.LinksWorkItemTypeHref = Convert.ToString(rdr["LinksWorkItemTypeHref"]);
                    wrklist.LinksWorkItemUpdatesHref = Convert.ToString(rdr["LinksWorkItemUpdatesHref"]);
                    //wrklist.Fields = Convert.ToString(rdr["Fields"]);
                    wrklist.ProjectId = Convert.ToString(rdr["ProjectId"]);
                    wrklist.Rev = Convert.ToInt32(rdr["Rev"]);
                    wrklist.Url = Convert.ToString(rdr["Url"]);

                    lstWorklist.Add(wrklist);
                }

                rdr.Close();

                return lstWorklist;

            }
        }

        public List<Teams> lstTeams = new List<Teams>();
        public List<Teams> LoadDataTeams()
        {

            using (AzureDevOpsConnection connection = new AzureDevOpsConnection($"AuthScheme=Basic;Organization=griffinv4;ProjectId=GriffinERP;PersonalAccessToken={PAT};"))
            {
                connection.Open();

                AzureDevOpsCommand cmd = new AzureDevOpsCommand("SELECT * FROM Teams", connection);

                AzureDevOpsDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Teams wrklist = new Teams();
                    wrklist.Id = Convert.ToString(rdr["Id"]);
                    wrklist.IdentityId = Convert.ToString(rdr["IdentityId"]);
                    //wrklist.IdentityIsActive = Convert.ToBoolean(rdr["IdentityIsActive"]);
                   // wrklist.IdentityIsContainer = Convert.ToBoolean(rdr["IdentityIsContainer"]);
                    wrklist.IdentityMasterId = Convert.ToString(rdr["IdentityMasterId"]);
                    //wrklist.IdentityMetaTypeId = Convert.ToInt32(rdr["IdentityMetaTypeId"]);
                    wrklist.IdentityProviderDisplayName = Convert.ToString(rdr["IdentityProviderDisplayName"]);
                    //wrklist.IdentityResourceVersion = Convert.ToInt32(rdr["IdentityResourceVersion"]);
                    
                    wrklist.IdentitySubjectDescriptor = Convert.ToString(rdr["IdentitySubjectDescriptor"]);
                    wrklist.IdentityUrl = Convert.ToString(rdr["IdentityUrl"]);
                    wrklist.Name = Convert.ToString(rdr["Name"]);
                    wrklist.ProjectId = Convert.ToString(rdr["ProjectId"]);
                    wrklist.ProjectName = Convert.ToString(rdr["ProjectName"]);
                    wrklist.Url = Convert.ToString(rdr["Url"]);
                    

                    lstTeams.Add(wrklist);
                }

                rdr.Close();

                return lstTeams;

            }
        }
    }
}