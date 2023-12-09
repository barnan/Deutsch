
using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class WordAttribute : IWordAttribute
    {
        public WordAttribute(Language lang, string text)
        {
            Text = text;
            Language = lang;
        }

        public string Text { get; }

        public Language Language { get; }

        public bool Equals(IDictionaryItem? other)
        {
            if (!(other is IWordAttribute attrib))
            {
                return false;
            }
            if (attrib.Language == Language && attrib.Text == Text)
            {
                return true;
            }
            return false;
        }

        public bool IsMatchingWithText(string text)
        {
            throw new NotImplementedException();
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "L";
            }

            switch (format.ToUpperInvariant())
            {
                case "S":
                    return $"{Text}";
                case "L":
                default:
                    return $"{Language}{Environment.NewLine}" +
                        $"{Text}{Environment.NewLine}";
            }
        }
    }
}
