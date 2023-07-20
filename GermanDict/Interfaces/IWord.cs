using Interfaces;

namespace GermanDict.Interfaces
{
    public interface IWord : IFormattable
    {
        string Phrase { get; }

        List<string> HUN_Meanings { get; }
    }

    public interface IVerb : IWord
    {
        string Infinitive { get; }
        
        string Inflected { get; }

        string Praeteritum { get; }

        string Perfect { get; }
    }

    public interface INoun : IWord
    {
        Article Article { get; }

        string Noun { get; }

        string PluralForm { get; }
    }

    public interface IAdjective : IWord
    {
        string Basic { get; }

        AdjectiveBoosting AdjectiveBoosting { get; }

    }

    public interface IUnusualAdjective : IAdjective
    {
        string Comparative { get; }

        string Superlative { get; }
    }

}
