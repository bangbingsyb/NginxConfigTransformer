using System;
using System.IO;
using Newtonsoft.Json;

namespace NginxConfTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            TransformerConfig config = ParseArgs(args);

            NgxResponse ngxJson;
            using (StreamReader sr = File.OpenText(config.InputFile))
            {
                Console.WriteLine($"Reading the input file {config.InputFile} ...");
                string json = sr.ReadToEnd();
                ngxJson = JsonConvert.DeserializeObject<NgxResponse>(json);
            }

            Console.WriteLine($"Merging Nginx configurations ...");
            NgxResponse merged = ConfigProcessor.Merge(ref ngxJson);

            string mergedOutput = JsonConvert.SerializeObject(
                merged,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            if (config.OutputFile != null)
            {
                Console.WriteLine($"Writing the merged configurations to the output file {config.OutputFile} ...");
                File.WriteAllText(config.OutputFile, mergedOutput);
            }
            else
            {
                Console.WriteLine($"Writing the merged configurations to console ...");
                Console.Write(mergedOutput);
            }
        }

        private static TransformerConfig ParseArgs(string[] args)
        {
            var config = new TransformerConfig();

            int index = 0;
            while (index < args.Length)
            {
                if (args[index] == "--in")
                {
                    if (++index < args.Length)
                    {
                        config.InputFile = args[index];
                    }
                }
                else if(args[index] == "--out")
                {
                    if (++index < args.Length)
                    {
                        config.OutputFile = args[index];
                    }
                }

                index++;
            }

            if (string.IsNullOrEmpty(config.InputFile))
            {
                throw new Exception("Input file is required - specify its path using \"--in\"");
            }

            return config;
        }
    }
}
