using GermanDict.Interfaces;

namespace Utils
{
    internal class NounParser : IWordParser
    {
        private const char _PROPERTY_SEPARATOR = ';';
        private const char _LIST_SEPARATOR = ':';

        public string Convert(IWord word)
        {
            if (word is not IAdjective adjective)
            {
                return "";
            }

            if (adjective is IUnusualAdjective unusual)
            {
                return $"{unusual.Basic}{_PROPERTY_SEPARATOR}" +
                $"{unusual.AdjectiveBoostingUnusual}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Comparative}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Superlative}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, adjective.HUN_Meanings)}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, adjective.Phrases)}{_PROPERTY_SEPARATOR}";
            }
            else
            {
                return $"{adjective.Basic}{_PROPERTY_SEPARATOR}" +
                $"{adjective.AdjectiveBoostingUnusual}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, adjective.HUN_Meanings)}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, adjective.Phrases)}{_PROPERTY_SEPARATOR}";
            }
        }

        public IWord Parse(string text)
        {
            string[] fragments = text.Split(_PROPERTY_SEPARATOR);
            bool AdjectiveBoostingUnusual = bool.Parse(fragments[1]);

            if (AdjectiveBoostingUnusual)
            {
                string[] meanings = fragments[4].Split(_LIST_SEPARATOR);
                string[] phrases = fragments[5].Split(_LIST_SEPARATOR);
                return new UnusualAdjective(fragments[0], fragments[2], fragments[3], AdjectiveBoostingUnusual, phrases.ToList(), meanings.ToList());
            }
            else
            {
                string[] meanings = fragments[2].Split(_LIST_SEPARATOR);
                string[] phrases = fragments[3].Split(_LIST_SEPARATOR);
                return new Adjective(fragments[0], AdjectiveBoostingUnusual, phrases.ToList(), meanings.ToList());
            }
        }
    }
}
