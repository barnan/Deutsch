using GermanDict.Interfaces;

namespace GermanDict.UI.ViewModels
{
    public abstract class RepositoryViewModel : ViewModelBase
    {
        public RepositoryViewModel(IRepository<IDictionaryItem> repository)
        {
            Repository = repository;
        }

        // it is needed because of the designinstance in the xaml
        public RepositoryViewModel()
        {
        }
                
        public IRepository<IDictionaryItem> Repository { get; }

    }
}
