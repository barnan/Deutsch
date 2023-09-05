
using System.Globalization;

namespace GermanDict.Interfaces
{
    public interface IWord : IFormattable, IEquatable<IWord>
    {
        List<string> Phrases { get; }

        List<string> HUN_Meanings { get; }

        WordType WordType { get; }
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
        Article Article { get; }

        string Word { get; }

        string PluralForm { get; }
    }

    public interface INounHandler : INoun
    {
        new Article Article { get; set; }

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



    public interface IUnusualAdjective : IAdjective
    {
        string Comparative { get; }

        string Superlative { get; }
    }

    public interface IUnusualAdjectiveHandler : IUnusualAdjective
    {
        new string Comparative { get; set; }

        new string Superlative { get; set; }
    }

}
