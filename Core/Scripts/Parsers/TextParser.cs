using System.Collections.Generic;

namespace Aureola
{
    public class TextParser : IParser
    {
        public Dictionary<string, string> Parse(string contents)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("_TEXT_", contents);
            return dictionary;
        }

        public string Serialize(Dictionary<string, string> dictionary)
        {
            return dictionary["_TEXT_"];
        }
    }
}
