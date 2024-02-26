using System.Collections.Generic;

namespace Aureola.Translations
{
    public class CsvFileParser : IFileParser
    {
        private string _contents;

        public void SetContents(string contents)
        {
            _contents = contents;
        }

        public Dictionary<string, string> Parse()
        {
            var translations = new Dictionary<string, string>();

            var lines = _contents.Replace("\"", "").Split('\n');
            foreach (var line in lines) {
                var keyValuePair = line.Split(',');
                if (keyValuePair.Length == 2) {
                    translations[keyValuePair[0]] = keyValuePair[1];
                }
            }

            return translations;
        }
    }
}
