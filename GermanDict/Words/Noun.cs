using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Noun : Word, INoun
    {
        public Noun(Language language, IWordAttribute attribute, IArticle article, string word, string pluralForm)
            : base(language, attribute)
        {
            Article = article;
            SingularForm = word;
            PluralForm = pluralForm;
        }

        #region INoun

        public IArticle Article
        {
            get;
            private set;
        }

        public string SingularForm
        {
            get;
            private set;
        }

        public string PluralForm
        {
            get;
            private set;
        }

        public override WordType WordType => WordType.Noun;

        #endregion

        #region overrides of IWord

        public override bool IsMatchingWithText(string text)
        {
            if (text.Length < _MINIMUM_MATCHING_WORD_LENGTH)
            {
                return false;
            }

            return Article.ToString() == text ||
                   SingularForm.Contains(text) ||
                   PluralForm.Contains(text);
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
                    return $"{SingularForm}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Language}{Environment.NewLine}" +
                        $"{WordAttribute}{Environment.NewLine}" +
                        $"{Article}{Environment.NewLine}" +
                        $"{SingularForm}{Environment.NewLine}" +
                        $"{PluralForm}{Environment.NewLine}";
            }
        }

        #endregion

        #region IEquatable

        public override bool Equals(IDictionaryItem? other)
        {
            if (!(other is INoun noun))
            {
                return false;
            }
            var comparer = new WordAttributesComparer();

            if ((noun as IWord).Equals(other) &&
                comparer.Equals(WordAttribute, noun.WordAttribute) &&
                Article == noun.Article &&
                SingularForm == noun.SingularForm &&
                PluralForm == noun.PluralForm)
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
        //    string codeText = $"{Article.ToString()}{Word}{PluralForm}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
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
