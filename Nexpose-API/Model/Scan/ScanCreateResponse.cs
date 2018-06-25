using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Model.Scan
{
    public partial class ScanCreateResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

   
}
