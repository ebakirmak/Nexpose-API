using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Scan
{
  
        public partial class ScanModel
        {
            [JsonProperty("links")]
            public Link[] Links { get; set; }

            [JsonProperty("page")]
            public Page Page { get; set; }

            [JsonProperty("resources")]
            public Resource[] Resources { get; set; }
        }

        public partial class Link
        {
            [JsonProperty("href")]
            public string Href { get; set; }

            [JsonProperty("rel")]
            public string Rel { get; set; }
        }

        public partial class Page
        {
            [JsonProperty("number")]
            public long Number { get; set; }

            [JsonProperty("size")]
            public long Size { get; set; }

            [JsonProperty("totalPages")]
            public long TotalPages { get; set; }

            [JsonProperty("totalResources")]
            public long TotalResources { get; set; }
        }

        public partial class Resource
        {
            [JsonProperty("assets")]
            public string Assets { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("endTime")]
            public string EndTime { get; set; }

            [JsonProperty("engineId")]
            public string EngineId { get; set; }

            [JsonProperty("engineName")]
            public string EngineName { get; set; }

            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("links")]
            public Link[] Links { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("scanName")]
            public string ScanName { get; set; }

            [JsonProperty("scanType")]
            public string ScanType { get; set; }

            [JsonProperty("siteId")]
            public long SiteId { get; set; }

            [JsonProperty("siteName")]
            public string SiteName { get; set; }

            [JsonProperty("startTime")]
            public string StartTime { get; set; }

            [JsonProperty("startedBy")]
            public string StartedBy { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("vulnerabilities")]
            public Vulnerabilities Vulnerabilities { get; set; }
        }

        public partial class Vulnerabilities
        {
            [JsonProperty("critical")]
            public long Critical { get; set; }

            [JsonProperty("moderate")]
            public long Moderate { get; set; }

            [JsonProperty("severe")]
            public long Severe { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

      

}

