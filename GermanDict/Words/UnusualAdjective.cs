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

        #region IFormattable

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

        #endregion

        #region IEquatable

        public override bool Equals(IWord? other)
        {
            if (other == null)
                return false;

            if (this.GetHashCode() == other.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Verb adjObj = obj as Verb;

            if (adjObj == null)
            {
                return false;
            }
            else
            {
                return Equals(adjObj);
            }
        }

        public override int GetHashCode()
        {
            string codeText = $"{Basic}{Comparative}{Superlative}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
            int code = 0;
            foreach (char ch in codeText)
            {
                code += ch;
            }
            return code;
        }

        #endregion

    }
}
