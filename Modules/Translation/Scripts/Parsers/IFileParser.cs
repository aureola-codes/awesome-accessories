using System.Collections.Generic;

namespace Aureola.Translation
{
    public interface IFileParser
    {
        public void SetContents(string contents);
        public Dictionary<string, string> Parse();
    }
}
