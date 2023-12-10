using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public class AdjectiveViewModel : WordViewModel
    {
        // it is needed because of the designinstance in the xaml
        public AdjectiveViewModel()
        {
        }

        public AdjectiveViewModel(IRepository<IDictionaryItem> repository) 
            : base(repository)
        {
        }

        public override WordType WordType => WordType.Adjective;

    }
}
