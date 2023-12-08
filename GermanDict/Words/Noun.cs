using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Noun : Word, INoun
    {
        public Noun(Language language, List<IWordAttribute> attributes, IArticle article, string word, string pluralForm)
            : base(language, attributes)
        {
            Article = article;
            Word = word;
            PluralForm = pluralForm;
        }

        #region INoun

        public IArticle Article
        {
            get;
            private set;
        }

        public string Word
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
                   Word.Contains(text) ||
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
                    return $"{Word}{Environment.NewLine}";
                case "L":
                default:
                    string attrib = WordAttributes.Count > 0 ? $"[{string.Join(',', WordAttributes)}]{Environment.NewLine}" : "";

                    return $"{Language}{Environment.NewLine}" +
                        attrib +
                        $"{Article}{Environment.NewLine}" +
                        $"{Word}{Environment.NewLine}" +
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

            var distinct = WordAttributes.Except(noun.WordAttributes, new WordAttributesComparer());

            if ((noun as IWord).Equals(other) &&
                distinct.Count() == 0 &&
                Article == noun.Article &&
                Word == noun.Word &&
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
