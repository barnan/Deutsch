using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal abstract class Word : IWord
    {
        public Word(List<string> phrases, List<string> hun_meanings)
        {
            HUN_Meanings = hun_meanings;
            Phrases = phrases;
        }

        public List<string> Phrases
        {
            get;
            private set;
        }

        public List<string> HUN_Meanings
        {
            get;
            private set;
        }

        public abstract WordType WordType { get; }

        public abstract bool Equals(IWord? other);

        public abstract string ToString(string? format, IFormatProvider? formatProvider);
    }
}
