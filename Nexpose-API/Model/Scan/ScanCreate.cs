using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Scan
{
    public partial class ScanCreate
    {
    
        [JsonProperty("engineId")]
        public string EngineId { get; set; }

        [JsonProperty("hosts")]
        public string[] Hosts { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("templateId")]
        public string TemplateId { get; set; }

        public ScanCreate(string hosts, string templateId)
        {
            try
            {
                this.TemplateId = templateId;

                if (hosts != null)
                {
                    this.Hosts = new string[hosts.Split(',').Length];
                    this.Hosts = hosts.Split(',');
                }
                   
            }
            catch (Exception ex)
            {

                Console.WriteLine("ScanCreate::ScanCreate \nException: " + ex.Message);
            }
          
        }

        //public ScanCreate(string[] hosts, string templateId)
        //{
        //    this.TemplateId = templateId;
        //    this.Hosts = hosts;
        //}

    }

}
