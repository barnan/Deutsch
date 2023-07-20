using System.ComponentModel;

namespace Interfaces
{
    public enum Article
    {
        [Description("der")]
        r,
        [Description("die")]
        e,
        [Description("das")]
        s
    }

    public enum AdjectiveBoosting
    {
        Normal,
        Unusual
    }
}
