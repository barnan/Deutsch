using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Verb : Word, IVerb
    {
        public Verb(string infinitive, string inflected, string praeteritum, string perfect, List<string> phrases, List<string> hun_meanings)
            : base (hun_meanings, phrases)
        {
            Infinitive = infinitive;
            Inflected = inflected;
            Praeteritum = praeteritum;
            Perfect = perfect;
        }

        public string Infinitive
        {
            get;
            private set;
        }

        public string Inflected
        {
            get;
            private set;
        }

        public string Praeteritum
        {
            get;
            private set;
        }

        public string Perfect
        {
            get;
            private set;
        }

        public override WordType WordType => WordType.Verb;

        /// <summary>
        /// IFormattable
        /// </summary>
        /// <param name="format">S (short) or L (long)</param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public override string ToString(string? format = null, IFormatProvider? formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "L";
            }

            switch (format.ToUpperInvariant())
            {
                case "S":
                    return $"{Infinitive}{Environment.NewLine}" +
                        $"{HUN_Meanings}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Infinitive}{Environment.NewLine}" +
                        $"{string.Join(',', HUN_Meanings.ToArray())}{Environment.NewLine}" +
                        $"{Inflected}{Environment.NewLine}" +
                        $"{Praeteritum}{Environment.NewLine}" +
                        $"{Perfect}{Environment.NewLine}" +
                        $"{string.Join(',', Phrases.ToArray())}{Environment.NewLine}";
            }
        }
    }
}
