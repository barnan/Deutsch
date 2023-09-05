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
            string codeText = $"{Basic}{AdjectiveBoostingUnusual}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
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
