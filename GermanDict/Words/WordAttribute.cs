
using GermanDict.Interfaces;

namespace GermanDict.Words
{
    internal class WordAttribute : IWordAttribute
    {
        public WordAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public bool Equals(IDictionaryItem? other)
        {
            if (!(other is IWordAttribute attrib))
            {
                return false;
            }
            if (attrib.Text == Text)
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
                case "L":
                default:
                    return $"[{Text}]";
            }
        }
    }
}
