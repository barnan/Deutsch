using GermanDict.Factories;
using GermanDict.Interfaces;


namespace GermanDict.Words.Parsers
{
    internal class DictionaryParser : IDictionaryParser<IDictionaryItem>
    {
        protected const char _PROPERTY_SEPARATOR = ';';
        protected const char _DEPTH_SEPARATOR = '/';


        public IDictionaryItem Parse(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);
            WordType wType = (WordType)Enum.Parse(typeof(WordType), fragments[0]);

            switch (wType)
            {
                case WordType.Noun:
                    return Parse_Noun(text);
                case WordType.Verb:
                    return Parse_Verb(text);
                case WordType.Adjective:
                    return Parse_Adjective(text);
                default:
                    throw new ArgumentException($"Incoming text could not been parsed: {text}");
            }
        }

        public string Convert(IDictionaryItem item)
        {
            if (item is IArticle article)
            {
                return Convert_Article(article);
            }
            if (item is IWordAttribute attribute)
            {
                return Convert_Attribute(attribute);
            }
            if (item is IPhrase)
            {
                throw new NotImplementedException();
            }
            
            if (item is not IWord word)
            {
                throw new ArgumentException();
            }
            
            switch (word.WordType)
            {
                case WordType.Noun:
                    return Convert_Noun(word);
                case WordType.Verb:
                    return Convert_Verb(word);
                case WordType.Adjective:
                    return Convert_Adjective(word);
                default:
                    throw new ArgumentException($"Incoming IWORD could not been converted: {word.WordType}");
            }
        }

        #region Attributes

        //private List<IWordAttribute> Parse_Attributes(string attributesText)
        //{
        //    List<IWordAttribute> attribList = new List<IWordAttribute>();

        //    string[] attribs = attributesText.Split(_LIST_SEPARATOR);
        //    foreach (var item in attribs)
        //    {
        //        attribList.Add(Parse_Attribute(item));
        //    }
        //    return attribList;
        //}

        //private string Convert_Attributes(List<IWordAttribute> attributeList)
        //{
        //    IEnumerable<string> stringList = attributeList.Select(Convert_Attribute);
        //    return string.Join(_LIST_SEPARATOR, stringList);
        //}

        private IWordAttribute Parse_Attribute(string attributeText)
        {
            string[] fragments = attributeText.Split(_PROPERTY_SEPARATOR);

            IWordAttribute attribute = WordFactory.Create_Attribute(fragments[1]);
            return attribute;
        }

        private string Convert_Attribute(IWordAttribute attribute)
        {
            return $"{WordType.Attribute}" +
                $"{_PROPERTY_SEPARATOR}" +
                $"{attribute.Text}";
        }

        #endregion

        #region Article

        private IArticle Parse_Article(string text)
        {
            string[] fragments = text.Split(_PROPERTY_SEPARATOR);
            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            IArticle article = WordFactory.Create_Article(fragments[0], lang);

            return article;
        }

        private string Convert_Article(IArticle article)
        {
            if (article == null)
            {
                throw new ArgumentException("Not proper parameter");
            }

            return $"{article.Name}" +
                $"{_PROPERTY_SEPARATOR}" +
                $"{article.Language}";
        }


        #endregion

        #region Verb 

        private IWord Parse_Verb(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string atributeText = parts[1];
            IWordAttribute atribute = Parse_Attribute(atributeText);

            IWord verb = WordFactory.Create_Verb(lang, atribute, fragments[3], fragments[4], fragments[5], fragments[6]);

            return verb;
        }

        private string Convert_Verb(IWord word)
        {
            if (word is not IVerb verb)
            {
                throw new ArgumentException("Not proper parameter");
            }

            string attributeText = Convert_Attribute(verb.WordAttribute);

            return $"{_DEPTH_SEPARATOR}" +
                $"{verb.WordType}{_PROPERTY_SEPARATOR}" +
                $"{verb.Language}{_PROPERTY_SEPARATOR}" +
                $"{verb.Infinitive}{_PROPERTY_SEPARATOR}" +
                $"{verb.Inflected}{_PROPERTY_SEPARATOR}" +
                $"{verb.Praeteritum}{_PROPERTY_SEPARATOR}" +
                $"{verb.Perfect}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributeText}{_DEPTH_SEPARATOR}";
        }

        #endregion

        #region noun

        public IWord Parse_Noun(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string attributeText = parts[1];
            IWordAttribute attributes = Parse_Attribute(attributeText);

            string articleText = parts[2];
            IArticle article = Parse_Article(articleText);

            IWord noun = WordFactory.Create_Noun(lang, attributes, article, fragments[1], fragments[2]);

            return noun;
        }

        public string Convert_Noun(IWord word)
        {
            if (word is not INoun noun)
            {
                throw new ArgumentException("Not proper parameter");
            }
            string attributeText = Convert_Attribute(noun.WordAttribute);
            string articleText = Convert_Article(noun.Article);

            return $"{_DEPTH_SEPARATOR}" +
                $"{noun.WordType}{_PROPERTY_SEPARATOR}" +
                $"{noun.Language}{_PROPERTY_SEPARATOR}" +
                $"{noun.SingularForm}{_PROPERTY_SEPARATOR}" +
                $"{noun.PluralForm}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributeText}{_DEPTH_SEPARATOR}" +
                $"{articleText}{_DEPTH_SEPARATOR}";
        }

        #endregion

        #region adjective

        public string Convert_Adjective(IWord word)
        {
            if (word is not IAdjective adjective)
            {
                throw new ArgumentException("Not proper parameter");
            }

            string attributeText = Convert_Attribute(adjective.WordAttribute);

            if (adjective is IAdjectiveUnusual unusual)
            {
                return $"{_DEPTH_SEPARATOR}" +
                $"{unusual.WordType}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Language}{_PROPERTY_SEPARATOR}" +
                $"{unusual.AdjectiveBoostingUnusual}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Basic}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Comparative}{_PROPERTY_SEPARATOR}" +
                $"{unusual.Superlative}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributeText}{_DEPTH_SEPARATOR}";
            }
            else
            {
                return $"{_DEPTH_SEPARATOR}" +
                $"{adjective.WordType}{_PROPERTY_SEPARATOR}" +
                $"{adjective.Language}{_PROPERTY_SEPARATOR}" +
                $"{adjective.AdjectiveBoostingUnusual}" +
                $"{adjective.Basic}{_PROPERTY_SEPARATOR}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributeText}{_DEPTH_SEPARATOR}";
            }
        }

        public IWord Parse_Adjective(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string attributeText = parts[1];
            IWordAttribute attribute = Parse_Attribute(attributeText);

            bool AdjectiveBoostingUnusual = bool.Parse(fragments[2]);

            if (AdjectiveBoostingUnusual)
            {
                return WordFactory.Create_UnusualAdjective(lang, attribute, fragments[3], fragments[4], fragments[5], AdjectiveBoostingUnusual);
            }
            else
            {
                return WordFactory.Create_Adjective(lang, attribute, fragments[3], AdjectiveBoostingUnusual);
            }
        }

        #endregion

    }
}
