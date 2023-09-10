using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
    public abstract class WordViewModel : ViewModelBase
    {
		public abstract WordType WordType { get; }

        public IRepository<IWord> Repository { get; }

        public WordViewModel(IRepository<IWord> repository)
        {
            Repository = repository;
        }

    }
}
