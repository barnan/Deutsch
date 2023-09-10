using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal abstract class Word : IWord
    {
        protected int _MINIMUM_MATCHING_WORD_LENGTH = 3;

        public Word(IEnumerable<string> phrases, IEnumerable<string> hun_meanings)
        {
            HUN_Meanings = hun_meanings;
            Phrases = phrases;
        }

        #region IWord

        public IEnumerable<string> Phrases
        {
            get;
            private set;
        }

        public IEnumerable<string> HUN_Meanings
        {
            get;
            private set;
        }

        public abstract WordType WordType { get; }

        public abstract bool Equals(IWord? other);

        public abstract bool IsMatchingWithText(string text);

        #endregion

        #region IFormattable

        public abstract string ToString(string? format, IFormatProvider? formatProvider);

        #endregion
        
    }
}
