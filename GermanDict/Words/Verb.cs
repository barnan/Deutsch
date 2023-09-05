﻿using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class Verb : Word, IVerb
    {
        public Verb(string infinitive, string inflected, string praeteritum, string perfect, List<string> phrases, List<string> hun_meanings)
            : base (hun_meanings, phrases)
        {
            Infinitive = infinitive;
            Inflected = inflected;
            Praeteritum = praeteritum;
            Perfect = perfect;
        }

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
                    return $"{Infinitive}{Environment.NewLine}" +
                        $"{HUN_Meanings}{Environment.NewLine}";
                case "L":
                default:
                    return $"{Infinitive}{Environment.NewLine}" +
                        $"{string.Join(',', HUN_Meanings.ToArray())}{Environment.NewLine}" +
                        $"{Inflected}{Environment.NewLine}" +
                        $"{Praeteritum}{Environment.NewLine}" +
                        $"{Perfect}{Environment.NewLine}" +
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

            Verb verbObj = obj as Verb;

            if (verbObj == null)
            {
                return false;
            }
            else
            {
                return Equals(verbObj);
            }
        }

        public override int GetHashCode()
        {
            string codeText = $"{Infinitive}{Inflected}{Praeteritum}{Perfect}";        // {string.Join('', Phrases)}{string.Join('', HUN_Meanings)}
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
