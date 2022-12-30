using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Azure_ADO_App.Models
{
    public class Builds
    {
        public int Id { get; set; }
        public string AgentSpecificationIdentifier { get; set; }
        public string BuildNumber { get; set; }
        public int BuildNumberRevision { get; set; }
        public DateTime ControllerCreatedDate { get; set; }
        public string ControllerDescription { get; set; }
        public bool ControllerEnabled { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public string ControllerStatus { get; set; }
        public DateTime ControllerUpdatedDate { get; set; }
        public string ControllerUri { get; set; }
        public string DefinitionId { get; set; }
        public bool Deleted { get; set; }
        public string DeletedByDisplayName { get; set; }
        public string DeletedById { get; set; }
        public string DeletedByUniqueName { get; set; }
    }
}