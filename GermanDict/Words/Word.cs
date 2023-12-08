using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal abstract class Word : IWord
    {
        protected int _MINIMUM_MATCHING_WORD_LENGTH = 3;

        public Word()
        {
        }

        #region IWord

        public abstract WordType WordType { get; }

        public Language Language { get; }

        public List<IWordAttribute> WordAttributes { get; } = new List<IWordAttribute> { };

        public abstract bool Equals(IDictionaryItem? other);

        public abstract bool IsMatchingWithText(string text);

        #endregion

        #region IFormattable

        public abstract string ToString(string? format, IFormatProvider? formatProvider);

        #endregion
        
    }
}
