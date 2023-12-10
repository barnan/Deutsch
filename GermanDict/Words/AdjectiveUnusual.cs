using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class AdjectiveUnusual : Adjective, IAdjectiveUnusual
    {
        public AdjectiveUnusual(Language language, IWordAttribute attribute, string basic, string comparative, string superlative, bool adjectiveBoostingUnusual) 
            : base(language, attribute, basic, adjectiveBoostingUnusual)
        {
            Comparative = comparative;
            Superlative = superlative;
        }

        #region IUnusualAdjective

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

        #endregion

        #region overrides of IWord

        public override bool IsMatchingWithText(string text)
        {
            if (text.Length < _MINIMUM_MATCHING_WORD_LENGTH)
            {
                return false;
            }

            return Basic.Contains(text) ||
                   Comparative.Contains(text) ||
                   Superlative.Contains(text);
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
                        $"{Basic}{Environment.NewLine}" +
                        $"{Comparative}{Environment.NewLine}" +
                        $"{Superlative}{Environment.NewLine}";
            }
        }

        #endregion

        #region IEquatable

        public override bool Equals(IDictionaryItem? other)
        {
            if (!(other is IAdjectiveUnusual adju))
            {
                return false;
            }

            var comparer = new WordAttributesComparer();

            if ((adju as IAdjective).Equals(other) &&
                comparer.Equals(WordAttribute, adju.WordAttribute) &&
                Comparative == adju.Comparative &&
                Superlative == adju.Superlative)
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
        //    string codeText = $"{Basic}{Comparative}{Superlative}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
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
