using GermanDict.Interfaces;
using GermanDict.Words;

namespace Words.Parsers
{
    internal class VerbParser : IParser<IWord>
    {

        private const char _PROPERTY_SEPARATOR = ';';
        private const char _LIST_SEPARATOR = ':';

        public string Convert(IWord word)
        {
            if (word is not IVerb verb)
            {
                return "";
            }
            return $"{verb.WordType}{_PROPERTY_SEPARATOR}" +
                $"{verb.Infinitive}{_PROPERTY_SEPARATOR}" +
                $"{verb.Inflected}{_PROPERTY_SEPARATOR}" +
                $"{verb.Praeteritum}{_PROPERTY_SEPARATOR}" +
                $"{verb.Perfect}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, verb.HUN_Meanings)}{_PROPERTY_SEPARATOR}" +
                $"{string.Join(_LIST_SEPARATOR, verb.Phrases)}{_PROPERTY_SEPARATOR}";
        }

        public IWord Parse(string text)
        {
            string[] fragments = text.Split(_PROPERTY_SEPARATOR);
            string[] meanings = fragments[5].Split(_LIST_SEPARATOR);
            string[] phrases = fragments[6].Split(_LIST_SEPARATOR);

            IWord verb = new Verb(fragments[1], fragments[2], fragments[3], fragments[4], meanings.ToList(), phrases.ToList());

            return verb;
        }

    }
}
