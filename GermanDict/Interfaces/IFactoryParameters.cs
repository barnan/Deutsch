
namespace GermanDict.Interfaces
{
    public interface IFactoryParameters
    {
        Type Type { get; }
    }

    public interface INounFactoryParameters : IFactoryParameters
    {
        IArticle Article { get; }
        string Word { get; }
        string PluralForm { get; }
        IEnumerable<string> Phrases { get; } 
        IEnumerable<string> HUN_Meanings { get; }
    }

    public interface IVerbFactoryParameters : IFactoryParameters
    {
        string Infinitive { get; }
        string Inflected { get; }
        string Praeteritum { get; }
        string Perfect { get; }
        IEnumerable<string> Phrases { get; }
        IEnumerable<string> HUN_Meanings { get; }
    }


    public interface IAdjectiveFactoryParameters : IFactoryParameters
    {
        string Basic { get; }
        bool AdjectiveBoostingUnusual { get; }
        IEnumerable<string> Phrases { get; }
        IEnumerable<string> HUN_Meanings { get; }
    }

    public interface IUnusualAdjectiveFactoryParameters : IFactoryParameters
    {
        string Comparative { get; }
        string Superlative { get; }

        string Basic { get; }
        bool AdjectiveBoostingUnusual { get; }
        IEnumerable<string> Phrases { get; }
        IEnumerable<string> HUN_Meanings { get; }
    }

}
