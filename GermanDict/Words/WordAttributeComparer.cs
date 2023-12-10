using GermanDict.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace GermanDict.Words
{
    internal class WordAttributesComparer : IEqualityComparer<IWordAttribute>
    {
        public bool Equals(IWordAttribute? x, IWordAttribute? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null && y is null)
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            if (x.Text == y.Text)
            {
                return true;
            }
            return false;
        }

        // todo: disallownull???
        public int GetHashCode([DisallowNull] IWordAttribute attrib)
        {
            return attrib.GetHashCode();
        }
    }
}
