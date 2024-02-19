using System.Collections.Generic;

namespace Aureola.Translations
{
    public class TextFileParser : IFileParser
    {
        private string _contents;

        public void SetContents(string contents)
        {
            _contents = contents;
        }

        public Dictionary<string, string> Parse()
        {
            var translations = new Dictionary<string, string>();
            translations.Add("", _contents);
            return translations;
        }
    }
}
