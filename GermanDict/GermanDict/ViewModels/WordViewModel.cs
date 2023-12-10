using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public abstract class WordViewModel : ViewModelBase
    {
        public WordViewModel(IRepository<IDictionaryItem> repository)
        {
            Repository = repository;
        }

        // it is needed because of the designinstance in the xaml
        public WordViewModel()
        {
        }

        public abstract WordType WordType { get; }

        public IRepository<IDictionaryItem> Repository { get; }

    }
}
