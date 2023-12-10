using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public class VerbViewModel : WordViewModel
    {
        public VerbViewModel(IRepository<IDictionaryItem> repository) 
            : base(repository)
        {
        }

        // it is needed because of the designinstance in the xaml
        public VerbViewModel()
        {
        }

        public override WordType WordType => WordType.Verb;

    }
}
