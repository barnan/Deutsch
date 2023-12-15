
namespace GermanDict.Interfaces
{
    public interface IDateTimeProvider : IObservable<DateTime>, IDisposable
    {
        DateTime GetDateTime();

    }
}
