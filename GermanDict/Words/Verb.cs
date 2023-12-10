using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Verb : Word, IVerb
    {
        public Verb(Language language, IWordAttribute attribute, string infinitive, string inflected, string praeteritum, string perfect)
            : base(language, attribute)
        {
            Infinitive = infinitive;
            Inflected = inflected;
            Praeteritum = praeteritum;
            Perfect = perfect;
        }

        #region IVerb

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

        #endregion

        #region overrides of IWord

        public override bool IsMatchingWithText(string text)
        {
            if (text.Length < _MINIMUM_MATCHING_WORD_LENGTH)
            {
                return false;
            }

            return Infinitive.Contains(text) ||
                   Inflected.Contains(text) ||
                   Praeteritum.Contains(text) ||
                   Perfect.Contains(text);
        }

        #endregion

        #region IFormattable

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
                    return $"{Infinitive}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Language}{Environment.NewLine}" +
                        $"{WordAttribute}{Environment.NewLine}" +
                        $"{Infinitive}{Environment.NewLine}" +
                        $"{Inflected}{Environment.NewLine}" +
                        $"{Praeteritum}{Environment.NewLine}" +
                        $"{Perfect}{Environment.NewLine}";
            }
        }

        #endregion

        #region IEquatable

        public override bool Equals(IDictionaryItem? other)
        {
            if (!(other is IVerb verb))
            {
                return false;
            }
            var comparer = new WordAttributesComparer();

            if ((verb as IDictionaryItem).Equals(other) &&
                comparer.Equals(WordAttribute, verb.WordAttribute) &&
                Infinitive == verb.Infinitive &&
                Inflected == verb.Inflected &&
                Praeteritum == verb.Praeteritum &&
                Perfect == verb.Perfect)
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
        //    string codeText = $"{Infinitive}{Inflected}{Praeteritum}{Perfect}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
        //    int code = 0;
        //    foreach (char ch in codeText)
        //    {
        //        code += ch;
        //    }
        //    return code;
        //}

        #endregion

        #region parser



        #endregion
    }
}
