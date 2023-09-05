using GermanDict.Interfaces;
using System;
using System.Text;

namespace GermanDict.Words
{
    internal class Noun : Word, INoun
    {
        public Noun(Article article, string word, string pluralForm, List<string> phrases, List<string> hun_meanings)
            :base(hun_meanings, phrases)
        {
            Article = article;
            Word = word;
            PluralForm = pluralForm;
        }

        #region INoun

        public Article Article
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
                    return $"{Word}{Environment.NewLine}" +
                        $"{HUN_Meanings}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Article}{Environment.NewLine}" +
                        $"{Word}{Environment.NewLine}" +
                        $"{string.Join(',', HUN_Meanings.ToArray())}{Environment.NewLine}" +
                        $"{PluralForm}{Environment.NewLine}" +
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

            Noun nounObj = obj as Noun;

            if (nounObj == null)
            {
                return false;
            }
            else
            {
                return Equals(nounObj);
            }
        }

        public override int GetHashCode()
        {
            string codeText = $"{Article.ToString()}{Word}{PluralForm}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
            int code = 0;
            foreach (char ch in codeText)
            {
                code += ch;
            }
            return code;
        }

        #endregion

        #endregion
    }
}