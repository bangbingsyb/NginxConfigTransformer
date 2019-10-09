using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    public class NgxResponse
    {
        public NgxResponse()
        {
            Errors = new List<NgxError>();
            Config = new List<NgxConfig>();
        }

        [JsonProperty("status", Order = 1)]
        public string Status { get; set; }

        [JsonProperty("errors", Order = 2)]
        public List<NgxError> Errors;

        [JsonProperty("config", Order = 3)]
        public List<NgxConfig> Config { get; set; } = new List<NgxConfig>();
    }
}
