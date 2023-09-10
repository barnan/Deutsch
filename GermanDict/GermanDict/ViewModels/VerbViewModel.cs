using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public class VerbViewModel : WordViewModel
    {
        public VerbViewModel(IRepository<IWord> repository) 
            : base(repository)
        {
        }

        public override WordType WordType => WordType.Verb;

    }
}
