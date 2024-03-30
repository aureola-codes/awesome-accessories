using System.Collections.Generic;

namespace Aureola
{
    public interface IParser
    {
        public Dictionary<string, string> Parse(string contents);
        public string Serialize(Dictionary<string, string> dictionary);
    }
}
