using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public class AdjectiveViewModel : WordViewModel
    {
        public AdjectiveViewModel(IRepository<IWord> repository) 
            : base(repository)
        {
        }

        public override WordType WordType => WordType.Adjective;

    }
}
