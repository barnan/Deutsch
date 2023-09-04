using GermanDict.Interfaces;

namespace GermanDict.Words
{
    public static class WordFactory
    {
        public static IWord CreateNoun(Article article, string word, string pluralForm, List<string> phrases, List<string> hun_meanings)
        {
            return new Noun(article, word, pluralForm, phrases, hun_meanings);
        }

        public static IWord CreateVerb(string infinitive, string inflected, string praeteritum, string perfect, List<string> phrases, List<string> hun_meanings)
        {
            return new Verb(infinitive, inflected, praeteritum, perfect, phrases, hun_meanings);
        }

        public static IWord CreateAdjective(string basic, bool adjectiveBoostingUnusual, List<string> phrases, List<string> hun_meanings)
        {
            return new Adjective(basic, adjectiveBoostingUnusual, phrases, hun_meanings);
        }

        public static IWord CreateUnusualAdjective(string basic, string comparative, string superlative, bool adjectiveBoostingUnusual, List<string> phrases, List<string> hun_meanings)
        {
            return new UnusualAdjective(basic, comparative, superlative, adjectiveBoostingUnusual, phrases, hun_meanings);
        }

    }
}
