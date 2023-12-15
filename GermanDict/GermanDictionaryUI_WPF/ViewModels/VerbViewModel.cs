using GermanDict.Interfaces;
using System.Collections.Generic;

namespace GermanDict.UI.ViewModels
{
    public class VerbViewModel : WordViewModel
    {
        public VerbViewModel(IRepository<IDictionaryItem> repository) 
            : base(repository)
        {
            Name = "AddVerb";
        }

        // it is needed because of the designinstance in the xaml
        public VerbViewModel()
        {
        }

        public override WordType WordType => WordType.Verb;


        private string _infinitive;
        public string Infinitive
        {
            get { return _infinitive; }
            set
            {
                _infinitive = value;
                OnPropertyChanged();
            }
        }


        private string _inflected;
        public string Inflected
        {
            get { return _inflected; }
            set
            {
                _inflected = value;
                OnPropertyChanged();
            }
        }


        private string _praeteritum;
        public string Praeteritum
        {
            get { return _praeteritum; }
            set
            {
                _praeteritum = value;
                OnPropertyChanged();
            }
        }


        private string _perfect;
        public string Perfect
        {
            get { return _perfect; }
            set
            {
                _perfect = value;
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
