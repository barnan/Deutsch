using GermanDict.Interfaces;
using GermanDict.Words;
using GermanDict.Words.Parsers;
using Words.Parsers;

namespace Factories
{
    public static class WordFactory
    {
        public static IWord CreateWord(WordType wordType, IFactoryParameters factoryParameter) 
        {
            switch (wordType)
            {
                case WordType.Noun:
                    if (!(factoryParameter is INounFactoryParameters nounParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IFactoryParameters)}");
                    }
                    return new Noun(nounParameters.Article, nounParameters.Word, nounParameters.PluralForm, nounParameters.Phrases, nounParameters.HUN_Meanings);

                case WordType.Verb:
                    if (!(factoryParameter is IVerbFactoryParameters verbParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IFactoryParameters)}");
                    }
                    return new Verb(verbParameters.Infinitive, verbParameters.Inflected, verbParameters.Praeteritum, verbParameters.Perfect, verbParameters.Phrases, verbParameters.HUN_Meanings );

                case WordType.Adjective:
                    if (!(factoryParameter is IAdjectiveFactoryParameters adjParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IFactoryParameters)}");
                    }
                    
                    if (adjParameters.AdjectiveBoostingUnusual && factoryParameter is IUnusualAdjectiveFactoryParameters unusualAdjParameters)
                    {
                        new UnusualAdjective(unusualAdjParameters.Basic, unusualAdjParameters.Comparative, unusualAdjParameters.Superlative, unusualAdjParameters.AdjectiveBoostingUnusual, unusualAdjParameters.Phrases, unusualAdjParameters.HUN_Meanings);
                    }
                    
                    return new Adjective(adjParameters.Basic, adjParameters.AdjectiveBoostingUnusual, adjParameters.Phrases, adjParameters.HUN_Meanings);
                
                default:
                    throw new ArgumentException($"{nameof(WordType)} ({wordType}) can not be interpreted");
            }
        }


        internal static IParser<IWord> _nounParser = new NounParser();
        internal static IParser<IWord> _verbParser = new VerbParser();
        internal static IParser<IWord> _adjectiveParser = new AdjectiveParser();


        public static IParser<IWord> GetParser(WordType wordType)
        {
            switch (wordType)
            {
                case WordType.Noun:
                    return _nounParser;
                case WordType.Verb:
                    return _verbParser;
                case WordType.Adjective:
                    return _adjectiveParser;
                default:
                    throw new Exception("No more parsers are available");
            }
        }

    }
}
