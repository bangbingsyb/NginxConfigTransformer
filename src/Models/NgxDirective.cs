using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    public class NgxDirective
    {
        public NgxDirective()
        {
            Args = new List<string>();

            // "Includes" and "Block" can be null
        }

        [JsonProperty("directive", Order = 1)]
        public string Directive { get; set; }

        [JsonProperty("line", Order = 2)]
        public int Line { get; set; }

        [JsonProperty("args", Order = 3)]
        public List<string> Args { get; set; }

        [JsonProperty("includes", Order = 4)]
        public List<int> Includes { get; set; }

        [JsonProperty("block", Order = 5)]
        public List<NgxDirective> Block { get; set; }
    }
}
