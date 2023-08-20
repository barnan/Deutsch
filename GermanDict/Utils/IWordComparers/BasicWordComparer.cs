using GermanDict.Interfaces;

namespace Utils
{
    internal class BasicWordComparer : IComparer<IWord>
    {
        public int Compare(IWord? word1, IWord? word2)
        {
            if (word1 == null && word2 == null)
            {
                return 0;
            }

            if (word1 == null)
            {
                return -1;
            }

            if (word2 == null)
            {
                return 1;
            }

            if (ReferenceEquals(word1, word2))
            {
                return 0;
            }

            if (word1.WordType != word2.WordType)
            {
                return word1.WordType < word2.WordType ? -1 : 1;
            }

            switch (word1.WordType)
            {
                case WordType.Noun:
                    INoun noun1 = word1 as INoun;
                    INoun noun2 = word2 as INoun;
                    return CompareNoun(noun1, noun2);
                case WordType.Verb:
                    IVerb verb1 = word1 as IVerb;
                    IVerb verb2 = word2 as IVerb;
                    return CompareVerb(verb1, verb2);
                case WordType.Adjective:
                    IAdjective adj1 = word1 as IAdjective;
                    IAdjective adj2 = word2 as IAdjective;
                    return CompareAdjective(adj1, adj2);
                default:
                    throw new InvalidOperationException($"The received word has invalid {nameof(WordType)} value ({word1.WordType})");
            }
        }

        private int CompareNoun(INoun noun1, INoun noun2)
        {
            if (noun1.Article == noun2.Article)
            {
                return noun1.Word.CompareTo(noun2.Word);
            }

            return noun1.Article < noun2.Article ? -1 : 1;  
        }

        private int CompareVerb(IVerb verb1, IVerb verb2)
        {
            return verb1.Infinitive.CompareTo(verb2.Infinitive);
        }

        private int CompareAdjective(IAdjective adj1, IAdjective adj2)
        {
            return adj1.Basic.CompareTo(adj2.Basic);
        }
    }
}
