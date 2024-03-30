using System;
using System.Collections.Generic;

namespace Aureola
{
    public class CSVParser : IParser
    {
        private string[] LINE_SEPARATORS = new string[] { "\r\n", "\n" };
        private string[] VALUE_SEPARATORS = new string[] { ",", ";", "\t", "|" };

        private string _lineSeparator = "\n";
        private string _valueSeparator = ",";

        public Dictionary<string, string> Parse(string contents)
        {
            _lineSeparator = DetectLineSeparator(contents);
            _valueSeparator = DetectValueSeparator(contents);

            var dictionary = new Dictionary<string, string>();

            var lines = contents.Split(_lineSeparator);
            foreach (var line in lines) {
                var keyValuePair = line.Split(_valueSeparator);
                dictionary.Add(TrimQuotationMarks(keyValuePair[0]), TrimQuotationMarks(keyValuePair[1]));
            }

            return dictionary;
        }

        public string Serialize(Dictionary<string, string> dictionary)
        {
            List<string> lines = new List<string>();
            foreach (var kvp in dictionary) {
                lines.Add($"\"{kvp.Key}\"{_valueSeparator}\"{kvp.Value}\"");
            }
            return string.Join(_lineSeparator, lines);
        }

        private string DetectLineSeparator(string content)
        {
            string mostFrequentSeparator = null;
            int maxCount = -1;

            foreach (string separator in LINE_SEPARATORS) {
                int count = content.Split(new string[] { separator }, StringSplitOptions.None).Length - 1;
                if (count > maxCount) {
                    maxCount = count;
                    mostFrequentSeparator = separator;
                }
            }

            return mostFrequentSeparator;
        }

        private string DetectValueSeparator(string content)
        {
            string mostFrequentSeparator = null;
            int highestCount = -1;

            foreach (var separator in VALUE_SEPARATORS) {
                int count = content.Split(new string[] { separator }, StringSplitOptions.None).Length - 1;
                if (count > highestCount) {
                    highestCount = count;
                    mostFrequentSeparator = separator;
                }
            }

            return mostFrequentSeparator;
        }

        private static string TrimQuotationMarks(string input)
        {
            if (input.StartsWith("\"") && input.EndsWith("\"")) {
                return input.Substring(1, input.Length - 2).Trim();
            }
            return input.Trim();
        }

    }
}
