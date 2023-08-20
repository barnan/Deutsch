using System.ComponentModel;

namespace GermanDict.Interfaces
{
    public enum Article
    {
        [Description("-")]
        None,
        [Description("der")]
        r,
        [Description("die")]
        e,
        [Description("das")]
        s        
    }

    public enum WordType
    {
        Noun,
        Verb,
        Adjective
    }

    public enum AdjectiveBoosting
    {
        Normal,
        Unusual
    }
}
