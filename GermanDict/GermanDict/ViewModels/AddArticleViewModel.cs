using GermanDict.Interfaces;
using System.Collections.ObjectModel;

namespace GermanDict.ViewModels
{
    public class AddArticleViewModel : ViewModelBase
    {
        

        public AddArticleViewModel()
        {
            Name = "AddArticle";
        }


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


        private ObservableCollection<IArticle> _availableArticles;
        public ObservableCollection<IArticle> AvailableArticles
        {
            get { return _availableArticles; }
            set
            {
                _availableArticles = value;
                OnPropertyChanged();
            }
        }


        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Language> _availableLanguages;
        public ObservableCollection<Language> AvailableLanguages
        {
            get { return _availableLanguages; }
            set
            {
                _availableLanguages = value;
                OnPropertyChanged();
            }
        }

    }
}
