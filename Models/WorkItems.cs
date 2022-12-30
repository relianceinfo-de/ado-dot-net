using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Azure_ADO_App.Models
{
    public class WorkItems
    {
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string Fields { get; set; }
        public string LinksFieldsHref { get; set; }
        public string LinksHtmlHref { get; set; }
        public string LinksSelfHref { get; set; }
        public string LinksWorkItemHistoryHref { get; set; }
        public string LinksWorkItemRevisionsHref { get; set; }
        public string LinksWorkItemTypeHref { get; set; }
        public string LinksWorkItemUpdatesHref { get; set; }
        public int Rev { get; set; }
        public string Url { get; set; }
    }

}