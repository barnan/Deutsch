using GermanDict.Interfaces;
using System.Collections.Generic;

namespace GermanDict.UI.ViewModels
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
            Name = "AddAdjective";
        }

        public override WordType WordType => WordType.Adjective;


        private string _basic;
        public string Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                OnPropertyChanged();
            }
        }


        private bool _adjectiveBoostingUnusual;
        public bool IsAdjectiveBoostingUnusual
        {
            get { return _adjectiveBoostingUnusual; }
            set
            {
                _adjectiveBoostingUnusual = value;
                OnPropertyChanged();
            }
        }


        private List<bool> _availableAdjectiveBoosting = new List<bool> { true, false };
        public List<bool> AvailableAdjectiveBoosting
        {
            get { return _availableAdjectiveBoosting; }
            set
            {
                _availableAdjectiveBoosting = value;
                OnPropertyChanged();
            }
        }


        private string _comparative;
        public string Comparative
        {
            get { return _comparative; }
            set
            {
                _comparative = value;
                OnPropertyChanged();
            }
        }


        private string _superlative;
        public string Superlative
        {
            get { return _superlative; }
            set
            {
                _superlative = value;
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
