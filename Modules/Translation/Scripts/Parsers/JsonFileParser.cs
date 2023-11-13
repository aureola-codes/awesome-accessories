using SimpleJSON;
using System.Collections.Generic;

namespace Aureola.Translation
{
    public class JsonFileParser : IFileParser
    {
        private string _contents;

        public void SetContents(string contents)
        {
            _contents = contents;
        }

        public Dictionary<string, string> Parse()
        {
            var translations = new Dictionary<string, string>();

            var jsonObject = JSON.Parse(_contents);
            foreach (var keyValuePair in jsonObject) {
                translations[keyValuePair.Key] = keyValuePair.Value.Value;
            }

            return translations;
        }
    }
}
