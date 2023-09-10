using GermanDict.Interfaces;
using System.Collections.Generic;

namespace GermanDict.ViewModels
{
	public class NounViewModel : WordViewModel
    {
        public NounViewModel(IRepository<IWord> repository)
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


		private string _word;
		public string Word
		{
			get { return _word; }
			set
			{
				_word = value;
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

		private List<string> _phrases;
		public List<string> Phrases
		{
			get { return _phrases; }
			set
			{
				_phrases = value;
				OnPropertyChanged();
			}
		}


		private List<string> _hun_Meanings;
        

        public List<string> HUN_Meanings
		{
			get { return _hun_Meanings; }
			set
			{
				_hun_Meanings = value;
				OnPropertyChanged();
			}
		}

	}
}
