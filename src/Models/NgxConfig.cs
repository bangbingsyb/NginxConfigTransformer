using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    public class NgxConfig
    {
        public NgxConfig()
        {
            Errors = new List<NgxError>();
            Parsed = new List<NgxDirective>();
        }

        [JsonProperty("file", Order = 1)]
        public string File { get; set; }

        [JsonProperty("status", Order = 2)]
        public string Status { get; set; }

        [JsonProperty("errors", Order = 3)]
        public List<NgxError> Errors;

        [JsonProperty("parsed", Order = 4)]
        public List<NgxDirective> Parsed { get; set; }
    }
}
