using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Site
{
    public partial class SitesModel
    {
        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }
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
        public long Assets { get; set; }

        [JsonProperty("connectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("lastScanTime")]
        public string LastScanTime { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("riskScore")]
        public double RiskScore { get; set; }

        [JsonProperty("scanEngine")]
        public string ScanEngine { get; set; }

        [JsonProperty("scanTemplate")]
        public string ScanTemplate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

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
