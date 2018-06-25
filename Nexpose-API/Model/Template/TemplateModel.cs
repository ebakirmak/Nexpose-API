using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Scan
{
    public class TemplateModel
    {
        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }
    }

    public partial class Resource
    {
      

        [JsonProperty("id")]
        public string ID { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

  
    }
}
