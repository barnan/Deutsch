using GermanDict.Interfaces;
using GermanDict.Words;

namespace Words.Parsers
{
    internal class NounParser : IParser<IWord>
    {
        private const char _PROPERTY_SEPARATOR = ';';
        private const char _LIST_SEPARATOR = ':';

        public IWord Parse(string text)
        {
            string[] fragments = text.Split(_PROPERTY_SEPARATOR);
            string[] meanings = fragments[3].Split(_LIST_SEPARATOR);
            string[] phrases = fragments[4].Split(_LIST_SEPARATOR);

            Article article = (Article)Enum.Parse(typeof(Article), fragments[0]);

            IWord noun = new Noun(article, fragments[1], fragments[2], meanings.ToList(), phrases.ToList());

            return noun;
        }

        public string Convert(IWord word)
        {
            if (word is not INoun noun)
            {
                return "";
            }
            return $"{noun.Article}{_PROPERTY_SEPARATOR}" +
                $"{noun.Word}{_PROPERTY_SEPARATOR}" +
                $"{noun.PluralForm}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, noun.HUN_Meanings)}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, noun.Phrases)}{_PROPERTY_SEPARATOR}";
        }
    }
}
