using GermanDict.Interfaces;
using GermanDict.Words;
using GermanDict.Words.Parsers;

namespace GermanDict.Factories
{
    public class WordFactory : IFactory
    {
        public static IWord CreateWord(WordType wordType, IWordFactoryParameters factoryParameter) 
        {
            switch (wordType)
            {
                case WordType.Noun:
                    if (!(factoryParameter is INounFactoryParameters nounParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IWordFactoryParameters)}");
                    }
                    return Create_Noun(nounParameters.Language, nounParameters.Attribute, nounParameters.Article, nounParameters.Word, nounParameters.PluralForm);

                case WordType.Verb:
                    if (!(factoryParameter is IVerbFactoryParameters verbParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IWordFactoryParameters)}");
                    }
                    return Create_Verb(verbParameters.Language, verbParameters.Attribute, verbParameters.Infinitive, verbParameters.Inflected, verbParameters.Praeteritum, verbParameters.Perfect);

                case WordType.Adjective:
                    if (!(factoryParameter is IAdjectiveFactoryParameters adjParameters))
                    {
                        throw new ArgumentException($"{wordType} can not be created with the recived {nameof(IWordFactoryParameters)}");
                    }
                    
                    if (adjParameters.AdjectiveBoostingUnusual && factoryParameter is IUnusualAdjectiveFactoryParameters unusualAdjParameters)
                    {
                        return Create_UnusualAdjective(unusualAdjParameters.Language, unusualAdjParameters.Attribute, unusualAdjParameters.Basic, unusualAdjParameters.Comparative, unusualAdjParameters.Superlative, unusualAdjParameters.AdjectiveBoostingUnusual);
                    }
                    
                    return Create_Adjective(adjParameters.Language, adjParameters.Attribute, adjParameters.Basic, adjParameters.AdjectiveBoostingUnusual);
                
                default:
                    throw new ArgumentException($"{nameof(WordType)} ({wordType}) can not be interpreted");
            }
        }


        internal static IVerb Create_Verb(Language language, IWordAttribute attribute, string infinitive, string inflected, string praeteritum, string perfect)
        {
            return new Verb(language, attribute, infinitive, inflected, praeteritum, perfect);
        }

        internal static INoun Create_Noun(Language language, IWordAttribute attribute, IArticle article, string word, string pluralForm)
        {
            return new Noun(language, attribute, article, word, pluralForm);
        }

        internal static IAdjective Create_Adjective(Language language, IWordAttribute attribute, string basic, bool adjectiveBoostingUnusual)
        {
            return new Adjective(language, attribute, basic, adjectiveBoostingUnusual);
        }

        internal static IAdjectiveUnusual Create_UnusualAdjective(Language language, IWordAttribute attribute, string basic, string comparative, string superlative, bool adjectiveBoostingUnusual)
        {
            return new AdjectiveUnusual(language, attribute, basic, comparative, superlative, adjectiveBoostingUnusual);
        }

        internal static IArticle Create_Article(string name, Language lang)
        {
            switch (lang)
            {                
                case Language.German:
                    var articles = DeutschArticle.GetArticles();
                    IArticle article = articles.Where(a => a.Name == name).First();
                    return article;
                
                case Language.English:
                case Language.Unknown:
                case Language.Hungarian:
                default:
                    throw new ArgumentException("Not proper input parameter");
            }
        }

        internal static IWordAttribute Create_Attribute(string name)
        {
            return new WordAttribute(name);
        }

        public static IDictionaryParser<IDictionaryItem> GetParser()
        {
            return new DictionaryParser();
        }


        //public static IParser<IWord> GetParser(WordType wordType)
        //{
        //    switch (wordType)
        //    {
        //        case WordType.Noun:
        //            return _nounParser;
        //        case WordType.Verb:
        //            return _verbParser;
        //        case WordType.Adjective:
        //            return _adjectiveParser;
        //        default:
        //            throw new Exception("No more parsers are available");
        //    }
        //}

    }
}
