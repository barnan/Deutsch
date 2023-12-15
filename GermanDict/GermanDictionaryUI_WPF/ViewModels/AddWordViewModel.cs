using GermanDict.UI.Commands;
using GermanDict.Interfaces;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace GermanDict.UI.ViewModels
{
	public class AddWordViewModel : ViewModelBase
	{
        // it is needed because of the design instance in the xaml
        public AddWordViewModel()
        {
        }

        public AddWordViewModel(UserControl[] userControls)
        {
            UserControls = userControls;
            SelectedUserControl = UserControls[0];
            AddButtonCommand = new RelayCommand(AddCommandAction);
            Name = "AddWord";
        }

        public UserControl[] UserControls;


        private UserControl _selectedUserControl;
		public UserControl SelectedUserControl
        {
			get { return _selectedUserControl; }
			set
			{
                if (_selectedUserControl != null)
                {
                    _selectedUserControl.Visibility = Visibility.Collapsed;
                }
                _selectedUserControl = value;
                _selectedUserControl.Visibility = Visibility.Visible;
                OnPropertyChanged();
			}
		}


        private WordType _selectedWordType;
        public WordType SelectedWordType
        {
            get { return _selectedWordType; }
            set
            {
                _selectedWordType = value;
                OnPropertyChanged();

                UserControl selected = UserControls.First(p => (p.DataContext as WordHandlerViewModel).WordType == _selectedWordType);
                SelectedUserControl = selected;

                if (_selectedWordType == WordType.Article || _selectedWordType == WordType.Attribute)
                {
                    IsAddButtonVisible = Visibility.Hidden;
                }
                else
                {
                    IsAddButtonVisible = Visibility.Visible;
                }
            }
        }

        private Visibility _isAddButtonVisible;
        public Visibility IsAddButtonVisible
        {
            get { return _isAddButtonVisible; }
            set
            {
                _isAddButtonVisible = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        private ICommand _addButtonCommand;
        public ICommand AddButtonCommand
        {
            get { return _addButtonCommand; }
            set
            {
                _addButtonCommand = value;
                OnPropertyChanged();
            }
        }

         
        private void AddCommandAction()
        {
            ;
        }

        #endregion

    }
}
