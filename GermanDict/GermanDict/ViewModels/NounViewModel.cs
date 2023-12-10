using GermanDict.Interfaces;

namespace GermanDict.ViewModels
{
	public class NounViewModel : WordViewModel
    {
        // it is needed because of the designinstance in the xaml
        public NounViewModel()
        {
        }

        public NounViewModel(IRepository<IDictionaryItem> repository)
            : base(repository)
        {
        }


        public override WordType WordType => WordType.Noun;


        private string _article;
		public string Article
		{
			get { return _article; }
			set
			{
				_article = value;
				OnPropertyChanged();
			}
		}


		private string _singularForm;
		public string SingularForm
		{
			get { return _singularForm; }
			set
			{
				_singularForm = value;
				OnPropertyChanged();
			}
		}


		private string _pluralForm;
		public string PluralForm
		{
			get { return _pluralForm; }
			set
			{
				_pluralForm = value;
				OnPropertyChanged();
			}
		}

		
	}
}
