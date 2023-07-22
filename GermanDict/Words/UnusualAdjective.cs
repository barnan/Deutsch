using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class UnusualAdjective : Adjective, IUnusualAdjective
    {
        public UnusualAdjective(string basic, string comparative, string superlative, bool adjectiveBoostingUnusual, List<string> phrases, List<string> hun_meanings) 
            : base(basic, adjectiveBoostingUnusual, phrases, hun_meanings)
        {
            Comparative = comparative;
            Superlative = superlative;
        }

        public string Comparative
        {
            get;
            private set;
        }

        public string Superlative
        {
            get;
            private set;
        }

        public override string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "L";
            }

            switch (format.ToUpperInvariant())
            {
                case "S":
                    return $"{Basic}{Environment.NewLine}" +
                        $"{HUN_Meanings}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Basic}{Environment.NewLine}" +
                        $"{string.Join(',', HUN_Meanings.ToArray())}{Environment.NewLine}" +
                        $"{string.Join(',', Phrases.ToArray())}{Environment.NewLine}";
            }
        }

    }
}
