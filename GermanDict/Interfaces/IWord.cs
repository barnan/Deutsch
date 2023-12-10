
namespace GermanDict.Interfaces
{

    public interface IWord : ILanguageDictionaryItem
    {
        WordType WordType { get; }
        IWordAttribute WordAttribute { get; }
    }


    public interface IVerb : IWord
    {
        string Infinitive { get; }
        
        string Inflected { get; }

        string Praeteritum { get; }

        string Perfect { get; }
    }


    public interface IVerbHandler : IVerb
    {
        new string Infinitive { get; set; }

        new string Inflected { get; set; }

        new string Praeteritum { get; set; }

        new string Perfect { get; set; }
    }


    public interface INoun : IWord
    {
        IArticle Article { get; }

        string SingularForm { get; }

        string PluralForm { get; }
    }


    public interface INounHandler : INoun
    {
        new IArticle Article { get; set; }

        new string Word { get; set; }

        new string PluralForm { get; set; }
    }


    public interface IAdjective : IWord
    {
        string Basic { get; }

        bool AdjectiveBoostingUnusual { get; }
    }


    public interface IAdjectiveHandler : IAdjective
    {
        new string Basic { get; set; }

        new bool AdjectiveBoostingUnusual { get; set; }
    }



    public interface IAdjectiveUnusual : IAdjective
    {
        string Comparative { get; }

        string Superlative { get; }
    }


    public interface IAdjectiveUnusualHandler : IAdjectiveUnusual
    {
        new string Comparative { get; set; }

        new string Superlative { get; set; }
    }

}
