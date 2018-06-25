using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Site
{
    public partial class SiteCreateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

 

}
