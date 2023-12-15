
using GermanDict.Interfaces;

namespace GermanDict.UI.ViewModels
{
    public class SearchWordViewModel : RepositoryViewModel
    {
        // it is needed because of the designinstance in the xaml
        public SearchWordViewModel()
        {
        }

        public SearchWordViewModel(IRepository<IDictionaryItem> repository)
            : base(repository)
        {
            Name = "SearchWord";
        }

    }
}
