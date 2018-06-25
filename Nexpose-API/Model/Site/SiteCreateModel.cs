using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Site
{
    public partial class SiteCreateModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("engineId")]
        public string EngineId { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("scan")]
        public Scan Scan { get; set; }

        [JsonProperty("scanTemplateId")]
        public string ScanTemplateId { get; set; }

        public SiteCreateModel(string name,string targets,string scanTemplateID)
        {
            try
            {
                this.Name = name;
                int count = targets.Split(',').Length;
                this.Scan = new Scan();
                this.Scan.Assets = new Assets();
                this.Scan.Assets.IncludedTargets = new CludedTargets();

                this.Scan.Assets.IncludedTargets.Addresses = new string[count];
                int counter = 0;
                foreach (var item in targets.Split(','))
                {
                    this.Scan.Assets.IncludedTargets.Addresses[counter] = item;
                    counter += 1;
                }
                this.Scan.Connection = new Connection();
                this.Scan.Connection.Id = 1;
                this.ScanTemplateId = scanTemplateID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("SiteCreateModel::Constructor \nException: " + ex.Message);
                throw;
            }
          
        }

    }

    public partial class Link
    {
        [JsonProperty("href")]
        public string SCMHref { get; set; }

        [JsonProperty("rel")]
        public string SCMRel { get; set; }
    }

    public partial class Scan
    {
        [JsonProperty("assets")]
        public Assets Assets { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }
    }

    public partial class Assets
    {
        [JsonProperty("excludedAssetGroups")]
        public CludedAssetGroups ExcludedAssetGroups { get; set; }

        [JsonProperty("excludedTargets")]
        public CludedTargets ExcludedTargets { get; set; }

        [JsonProperty("includedAssetGroups")]
        public CludedAssetGroups IncludedAssetGroups { get; set; }

        [JsonProperty("includedTargets")]
        public CludedTargets IncludedTargets { get; set; }
    }

    public partial class CludedAssetGroups
    {
        [JsonProperty("assetGroupIDs")]
        public long[] AssetGroupIDs { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class CludedTargets
    {
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class Connection
    {
        [JsonProperty("id")]
        public Int64 Id { get; set; }
    }

}
