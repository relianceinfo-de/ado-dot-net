using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Azure_ADO_App.Models
{
    public class Project
    {
        public string Id { get; set; }

        public string CapabilitiesProcessTemplateName { get; set; }

        public string CapabilitiesProcessTemplateTypeId { get; set; }

        public string CapabilitiesVersionControlType { get; set; }

        public bool? CapabilitiesVersionControlGitEnabled { get; set; }

        public bool? CapabilitiesVersionControlTfvcEnabled { get; set; }

        public string DefaultTeamId { get; set; }
        public Guid Team { get; set; }

        public string DefaultTeamName { get; set; }

        public string DefaultTeamUrl { get; set; }

        public string DefaultTeamImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public string LinksCollectionHref { get; set; }

        public string LinksSelfHref { get; set; }

        public string LinksWebHref { get; set; }

        public string Name { get; set; }

        public int? Revision { get; set; }

        public string State { get; set; }

        public string Url { get; set; }
    }
}