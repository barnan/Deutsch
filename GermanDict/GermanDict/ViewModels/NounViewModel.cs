using GermanDict.Interfaces;
using System.Collections.Generic;

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


        private IArticle _selectedArticle;
        public IArticle SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                _selectedArticle = value;
                OnPropertyChanged();
            }
        }


        private List<IArticle> _availableArticles;
        public List<IArticle> AvailableArticles
        {
            get { return _availableArticles; }
            set
            {
                _availableArticles = value;
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


        private IWordAttribute _selectedWordAttribute;
        public IWordAttribute SelectedWordAttribute
        {
            get { return _selectedWordAttribute; }
            set
            {
                _selectedWordAttribute = value;
                OnPropertyChanged();
            }
        }


        private List<IWordAttribute> _availableWordAttribute;
        public List<IWordAttribute> AvailableWordAttribute
        {
            get { return _availableWordAttribute; }
            set
            {
                _availableWordAttribute = value;
                OnPropertyChanged();
            }
        }


        private List<IPhrase> _phrases;
        public List<IPhrase> Phrases
        {
            get { return _phrases; }
            set
            {
                _phrases = value;
                OnPropertyChanged();
            }
        }


    }
}
