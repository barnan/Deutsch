using GermanDict.Interfaces;
using Interfaces;

namespace GermanDict.Words
{
    public class Noun : INoun
    {
        #region INoun
        public Article Article => throw new NotImplementedException();

        public string PluralForm => throw new NotImplementedException();

        public string Phrase => throw new NotImplementedException();

        public List<string> HUN_Meanings => throw new NotImplementedException();

        string INoun.Noun => throw new NotImplementedException();

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}