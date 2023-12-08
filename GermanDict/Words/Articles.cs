using GermanDict.Interfaces;

namespace GermanDict.Words
{
    public abstract class ArticleBase : IArticle
    {
        protected ArticleBase(string name)
        {
            Name = name;
        }

        #region IArticle

        public string Name { get; }

        public abstract Language Language { get; }

        #endregion

        #region IFormattable

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"{Name} ({Language})";
        }

        #endregion

        #region Equals

        public bool Equals(IDictionaryItem? other)
        {
            if (other is IArticle article)
            {
                if (Language == article.Language && Name == article.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals(obj);
        }

        #endregion

        public abstract bool IsMatchingWithText(string text);

    }

    public sealed class DeutschArticle : ArticleBase
    {
        private DeutschArticle(string name)
            : base(name)
        {
        }

        public static DeutschArticle None { get; } = new DeutschArticle("-");
        public static DeutschArticle Der { get; } = new DeutschArticle("der");
        public static DeutschArticle Die { get; } = new DeutschArticle("die");
        public static DeutschArticle Das { get; } = new DeutschArticle("das");


        public override Language Language => Language.German;

        #region IRepositoryElement

        public override bool IsMatchingWithText(string text)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public sealed class HungarianArticle : ArticleBase, IArticle
    {
        private HungarianArticle(string name)
            : base(name)
        {
        }

        public static HungarianArticle None { get; } = new HungarianArticle("-");

        public override Language Language => Language.Hungarian;

        #region IRepositoryElement

        public override bool IsMatchingWithText(string text)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
