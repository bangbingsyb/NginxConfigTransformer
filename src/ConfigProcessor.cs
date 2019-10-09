using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    public static class ConfigProcessor
    {
        public static NgxResponse Merge(ref NgxResponse original)
        {
            var merged = new NgxResponse();
            merged.Status = original.Status;
            merged.Config.Add(original.Config[0]);

            for (int i = 0; i < merged.Config[0].Parsed.Count; i++)
            {
                NgxDirective directive = merged.Config[0].Parsed[i];

                ExpandIncludes(ref directive, ref original);
            }

            return merged;
        }

        private static void ExpandIncludes(ref NgxDirective directive, ref NgxResponse response)
        {
            if (directive.Block == null)
            {
                return;
            }

            for (int i = 0; i < directive.Block.Count; i++)
            {
                NgxDirective childDirective = directive.Block[i];
                if (childDirective.Directive == "include")
                {
                    Console.WriteLine($"Find \"include\" directive in {directive.Directive}");
                    directive.Block.RemoveAt(i);

                    List<int> configRefList = childDirective.Includes;

                    for (int j = 0; j < configRefList.Count; j++)
                    {
                        int index = configRefList[j];
                        NgxConfig config = response.Config[index];
                        Console.WriteLine($"Include {config.File}");

                        foreach (NgxDirective includedDirective in config.Parsed)
                        {
                            directive.Block.Add(includedDirective);
                        }
                    }

                }

                ExpandIncludes(ref childDirective, ref response);
            }
        }
    }
}
