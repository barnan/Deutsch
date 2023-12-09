using GermanDict.Factories;
using GermanDict.Interfaces;
using System.Text;


namespace GermanDict.Words.Parsers
{
    internal class Parser : IParser<IWord>
    {
        protected const char _PROPERTY_SEPARATOR = ';';
        protected const char _LIST_SEPARATOR = ':';
        protected const char _DEPTH_SEPARATOR = ':';


        public IWord Parse(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);
            WordType wType = (WordType)Enum.Parse(typeof(WordType), fragments[0]);

            switch (wType)
            {
                case WordType.Noun:
                    return Parse_Noun(text);
                //case WordType.Article:
                //    return Parse_Article(text);
                case WordType.Verb:
                    return Parse_Verb(text);
                case WordType.Adjective:
                    return Parse_Adjective(text);
                default:
                    throw new ArgumentException($"Incoming text could not been parsed: {text}");
            }
        }

        public string Convert(IWord word)
        {
            switch (word.WordType)
            {
                case WordType.Noun:
                    return Convert_Noun(word);
                //case WordType.Article:
                //    return Convert_Article(word);
                case WordType.Verb:
                    return Convert_Verb(word);
                case WordType.Adjective:
                    return Convert_Adjective(word);
                default:
                    throw new ArgumentException($"Incoming IWORD could not been converted: {word.WordType}");
            }
        }


        #region Attributes

        private List<IWordAttribute> Parse_Attributes(string attributeText)
        {
            List<IWordAttribute> attribList = new List<IWordAttribute>();

            string[] attribs = attributeText.Split(_LIST_SEPARATOR);
            foreach (var item in attribs)
            {
                string[] fragments = item.Split(_PROPERTY_SEPARATOR);
                Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

                IWordAttribute attribute = WordFactory.Create_Attribute(lang, fragments[0]);
                attribList.Add(attribute);
            }
            return attribList;
        }

        private string Convert_Attributes(List<IWordAttribute> attributeList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var attrib in attributeList)
            {
                sb.Append($"{attrib.Text}{_PROPERTY_SEPARATOR}{attrib.Language}" +
                    $"{_LIST_SEPARATOR}");
            }
            return sb.ToString();
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

            return $"{article.Name}{_PROPERTY_SEPARATOR}" +
                $"{article.Language}{_PROPERTY_SEPARATOR}";
        }


        #endregion

        #region Verb 

        private IWord Parse_Verb(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string atributesText = parts[1];
            List<IWordAttribute> atributes = Parse_Attributes(atributesText);

            IWord verb = WordFactory.Create_Verb(lang, atributes, fragments[3], fragments[4], fragments[5], fragments[6]);

            return verb;
        }

        private string Convert_Verb(IWord word)
        {
            if (word is not IVerb verb)
            {
                throw new ArgumentException("Not proper parameter");
            }

            string attributesText = Convert_Attributes(verb.WordAttributes);

            return $"{_DEPTH_SEPARATOR}" +
                $"{verb.WordType}{_PROPERTY_SEPARATOR}" +
                $"{verb.Language}{_PROPERTY_SEPARATOR}" +
                $"{verb.Infinitive}{_PROPERTY_SEPARATOR}" +
                $"{verb.Inflected}{_PROPERTY_SEPARATOR}" +
                $"{verb.Praeteritum}{_PROPERTY_SEPARATOR}" +
                $"{verb.Perfect}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributesText}{_DEPTH_SEPARATOR}";
        }

        #endregion

        #region noun

        public IWord Parse_Noun(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string attributesText = parts[1];
            List<IWordAttribute> attributes = Parse_Attributes(attributesText);

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
            string attributesText = Convert_Attributes(noun.WordAttributes);
            string articleText = Convert_Article(noun.Article);

            return $"{_DEPTH_SEPARATOR}" +
                $"{noun.WordType}{_PROPERTY_SEPARATOR}" +
                $"{noun.Language}{_PROPERTY_SEPARATOR}" +
                $"{noun.Word}{_PROPERTY_SEPARATOR}" +
                $"{noun.PluralForm}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributesText}{_DEPTH_SEPARATOR}" +
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

            string attributesText = Convert_Attributes(adjective.WordAttributes);

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
                $"{attributesText}{_DEPTH_SEPARATOR}";
            }
            else
            {
                return $"{_DEPTH_SEPARATOR}" +
                $"{adjective.WordType}{_PROPERTY_SEPARATOR}" +
                $"{adjective.Language}{_PROPERTY_SEPARATOR}" +
                $"{adjective.AdjectiveBoostingUnusual}" +
                $"{adjective.Basic}{_PROPERTY_SEPARATOR}" +
                $"{_DEPTH_SEPARATOR}" +
                $"{attributesText}{_DEPTH_SEPARATOR}";
            }
        }

        public IWord Parse_Adjective(string text)
        {
            string[] parts = text.Split(_DEPTH_SEPARATOR);
            string[] fragments = parts[0].Split(_PROPERTY_SEPARATOR);

            Language lang = (Language)Enum.Parse(typeof(Language), fragments[1]);

            string attributesText = parts[1];
            List<IWordAttribute> attributes = Parse_Attributes(attributesText);

            bool AdjectiveBoostingUnusual = bool.Parse(fragments[2]);

            if (AdjectiveBoostingUnusual)
            {
                return WordFactory.Create_UnusualAdjective(lang, attributes, fragments[3], fragments[4], fragments[5], AdjectiveBoostingUnusual);
            }
            else
            {
                return WordFactory.Create_Adjective(lang, attributes, fragments[3], AdjectiveBoostingUnusual);
            }
        }

        #endregion

    }
}
