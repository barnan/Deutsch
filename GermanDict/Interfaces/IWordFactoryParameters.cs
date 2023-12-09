
namespace GermanDict.Interfaces
{
    public interface IFactory
    { }

    public interface IWordFactoryParameters
    {
        Language Language { get; }
        List<IWordAttribute> Attributes { get; }
    }

    public interface INounFactoryParameters : IWordFactoryParameters
    {
        IArticle Article { get; }
        string Word { get; }
        string PluralForm { get; }
    }

    public interface IVerbFactoryParameters : IWordFactoryParameters
    {
        string Infinitive { get; }
        string Inflected { get; }
        string Praeteritum { get; }
        string Perfect { get; }
    }


    public interface IAdjectiveFactoryParameters : IWordFactoryParameters
    {
        string Basic { get; }
        bool AdjectiveBoostingUnusual { get; }
    }

    public interface IUnusualAdjectiveFactoryParameters : IWordFactoryParameters
    {
        string Comparative { get; }
        string Superlative { get; }

        string Basic { get; }
        bool AdjectiveBoostingUnusual { get; }
    }

}
