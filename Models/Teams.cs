using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Azure_ADO_App.Models
{
    public class Teams
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string IdentityId { get; set; }
        public bool IdentityIsActive { get; set; }
        public bool IdentityIsContainer { get; set; }
        public string IdentityMasterId { get; set; }
        public int IdentityMetaTypeId { get; set; }
        public string IdentityProviderDisplayName { get; set; }
        public int IdentityResourceVersion { get; set; }
        public string IdentitySubjectDescriptor { get; set; }
        public string IdentityUrl { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Url { get; set; }
    }
}