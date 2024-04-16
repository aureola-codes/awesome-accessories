using System;
using System.Collections.Generic;
using System.Linq;

namespace Aureola
{
    public class YamlParser : IParser
    {
        public Dictionary<string, string> Parse(string contents)
        {
            var dictionary = new Dictionary<string, string>();
            
            var lines = contents.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines) {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length != 2) {
                    throw new FormatException("Line is not a valid key-value pair");
                }

                var key = parts[0].Trim();
                var value = parts[1].Trim().Trim('"');
                dictionary[key] = value;
            }

            return dictionary;
        }

        public string Serialize(Dictionary<string, string> dictionary)
        {
            return string.Join("\n", dictionary.Select(kv => $"{kv.Key}: \"{kv.Value}\""));
        }
    }
}
