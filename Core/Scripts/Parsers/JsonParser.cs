using Aureola.AwesomeAccessories.SimpleJSON;
using System.Collections.Generic;

namespace Aureola
{
    public class JsonParser : IParser
    {
        public Dictionary<string, string> Parse(string contents)
        {
            var jsonObject = JSON.Parse(contents);
            var dictionary = new Dictionary<string, string>();
            foreach (var keyValuePair in jsonObject) {
                dictionary.Add(keyValuePair.Key, keyValuePair.Value.Value);
            }

            return dictionary;
        }

        public string Serialize(Dictionary<string, string> dictionary)
        {
            var jsonObject = new JSONObject();
            foreach (var keyValuePair in dictionary) {
                jsonObject.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return jsonObject.ToString(4);
        }
    }
}
