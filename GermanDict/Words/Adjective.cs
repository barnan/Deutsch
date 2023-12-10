using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Adjective : Word, IAdjective
    {
        public Adjective(Language language, IWordAttribute attribute, string basic, bool adjectiveBoostingUnusual)
            : base(language, attribute)
        {
            Basic = basic;
            AdjectiveBoostingUnusual = adjectiveBoostingUnusual;
        }

        #region IAdjective

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

        public override WordType WordType => WordType.Adjective;

        #endregion

        #region overrides of IWord

        public override bool IsMatchingWithText(string text)
        {
            if (text.Length < _MINIMUM_MATCHING_WORD_LENGTH)
            { 
                return false;
            }

            return Basic.Contains(text);
        }

        #endregion

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
                    return $"{Basic}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Language}{Environment.NewLine}" +
                        $"{WordAttribute}{Environment.NewLine}" +
                        $"{Basic}{Environment.NewLine}";
            }
        }

        #endregion

        #region IEquatable

        public override bool Equals(IDictionaryItem? other)
        {
            if (!(other is IAdjective adj))
            {
                return false;
            }

            var comparer = new WordAttributesComparer();

            if ((adj as IWord).Equals(other) &&
                comparer.Equals(WordAttribute, adj.WordAttribute) &&
                Basic == adj.Basic)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public override int GetHashCode()
        //{
        //    string codeText = $"{Basic}{AdjectiveBoostingUnusual}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
        //    int code = 0;
        //    foreach (char ch in codeText)
        //    {
        //        code += ch;
        //    }
        //    return code;
        //}

        #endregion
    }
}
