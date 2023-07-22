using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Adjective : Word, IAdjective
    {
        public Adjective(string basic, bool adjectiveBoostingUnusual, List<string> phrases, List<string> hun_meanings)
            : base(phrases, hun_meanings)
        {
            Basic = basic;
            AdjectiveBoostingUnusual = adjectiveBoostingUnusual;
        }

        public string Basic
        {
            get;
            private set;
        }

        public bool AdjectiveBoostingUnusual
        {
            get;
            private set;
        }

        public List<string> Phrases
        {
            get;
            private set;
        }

        public List<string> HUN_Meanings
        {
            get;
            private set;
        }

        public override WordType WordType => WordType.Adjective;

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
