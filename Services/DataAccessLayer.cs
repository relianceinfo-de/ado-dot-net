using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.CData.AzureDevOps;
using System.Linq;
using System.Web;
using Test_Azure_ADO_App.Models;

namespace WebApplication1.Services
{
    public class DataAccessLayer
    {
        private static string PAT = ConfigurationManager.AppSettings["PersonalAccessToken"];

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
    }
}