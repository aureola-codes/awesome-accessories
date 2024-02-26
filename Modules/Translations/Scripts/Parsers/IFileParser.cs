using System.Collections.Generic;

namespace Aureola.Translations
{
    public interface IFileParser
    {
        public void SetContents(string contents);
        public Dictionary<string, string> Parse();
    }
}
