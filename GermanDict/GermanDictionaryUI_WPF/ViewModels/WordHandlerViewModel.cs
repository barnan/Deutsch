using GermanDict.Interfaces;

namespace GermanDict.UI.ViewModels
{
    public abstract class WordHandlerViewModel : RepositoryViewModel
    {
        public WordHandlerViewModel(IRepository<IDictionaryItem> repository)
            : base(repository)
        {
        }

        // it is needed because of the designinstance in the xaml
        public WordHandlerViewModel()
        {
        }

        public abstract WordType WordType { get; }
    }
}
