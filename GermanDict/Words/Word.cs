using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal abstract class Word : IWord
    {
        protected int _MINIMUM_MATCHING_WORD_LENGTH = 3;

        public Word()
        {
        }

        protected Word(Language language, List<IWordAttribute> attributes)
        {
            Language = language;
            WordAttributes = attributes;
        }

        #region IWord

        public abstract WordType WordType { get; }

        public Language Language { get; }

        public List<IWordAttribute> WordAttributes { get; }
        
        #endregion

        #region IRepositoryElement

        public abstract bool IsMatchingWithText(string text);

        #endregion

        #region IFormattable

        public abstract string ToString(string? format, IFormatProvider? formatProvider);

        #endregion

        #region Equals

        public virtual bool Equals(IDictionaryItem? other)
        {
            if (!(other is IWord word))
            {
                return false;
            }

            var distinct = WordAttributes.Except(word.WordAttributes, new WordAttributesComparer());
            if (Language == word.Language && distinct.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is IDictionaryItem))
            {
                return false;
            }
            return Equals(obj as IDictionaryItem);
        }


        #endregion

    }





}
