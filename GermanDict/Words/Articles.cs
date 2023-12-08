using GermanDict.Interfaces;

namespace GermanDict.Words
{
    public abstract class ArticleBase : IArticle
    {
        protected ArticleBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #region IArtikel

        public string Name { get; }
        public int Id { get; }

        #endregion

        public abstract WordType WordType { get; }

        public abstract Language Language { get; }

        public bool Equals(IWord? other)
        {
            if (other is IArticle article)
            {
                if (WordType == article.WordType || Language == article.Language || Name == article.Name || Id == article.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract bool IsMatchingWithText(string text);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class DeutschArtikel : ArticleBase
    {
        private DeutschArtikel(int id, string name)
            :base(id, name)
        {
        }

        public static DeutschArtikel None { get; } = new DeutschArtikel(0, "-");
        public static DeutschArtikel Der { get; } = new DeutschArtikel(1, "der");
        public static DeutschArtikel Die { get; } = new DeutschArtikel(1, "die");
        public static DeutschArtikel Das { get; } = new DeutschArtikel(1, "das");

        #region IWord

        public override WordType WordType => WordType.Article;

        public override Language Language => Language.German;

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return Name;
        }

        public bool Equals(IWord? other)
        {
            if (other is IArticle article)
            {
                if (WordType == article.WordType || Language == article.Language || Name == article.Name || Id == article.Id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IRepositoryElement

        public bool IsMatchingWithText(string text)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public sealed class HungarianArticle : IArticle
    {
        #region IArtikel

        public string Name { get; }
        public int Id { get; }

        #endregion

        private HungarianArticle(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static HungarianArticle None { get; } = new HungarianArticle(0, "-");

        #region IWord

        public WordType WordType => WordType.Article;

        public Language Language => throw new NotImplementedException();

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return Name;
        }

        #endregion

        #region IRepositoryElement

        public bool IsMatchingWithText(string text)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
