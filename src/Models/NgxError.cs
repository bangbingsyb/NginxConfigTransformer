using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    public class NgxError
    {
        [JsonProperty("file", Order = 1)]
        public string File { get; set; }

        [JsonProperty("line", Order = 2)]
        public string Line { get; set; }

        [JsonProperty("error", Order = 3)]
        public string Error { get; set; }

        [JsonProperty("callback", Order = 4)]
        public string Callback { get; set; }
    }
}
