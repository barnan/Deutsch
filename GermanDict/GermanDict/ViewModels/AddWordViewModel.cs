using GermanDict.Commands;
using GermanDict.Interfaces;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace GermanDict.ViewModels
{
	public class AddWordViewModel : ViewModelBase
	{
        public AddWordViewModel()
        {            
        }

        public AddWordViewModel(UserControl[] userControls)
        {
            UserControls = userControls;
            SelectedUserControl = UserControls[0];
            AddButtonCommand = new RelayCommand(AddCommandAction);
        }
        

        private UserControl _selectedUserControl;
		public UserControl SelectedUserControl
        {
			get { return _selectedUserControl; }
			set
			{
                if (_selectedUserControl != null)
                {
                    _selectedUserControl.Visibility = System.Windows.Visibility.Collapsed;
                }
                _selectedUserControl = value;
                _selectedUserControl.Visibility = System.Windows.Visibility.Visible;
                OnPropertyChanged();
			}
		}


        public UserControl[] UserControls;


        private WordType _selectedWordType;
        public WordType SelectedWordType
        {
            get { return _selectedWordType; }
            set
            {
                _selectedWordType = value;
                OnPropertyChanged();

                UserControl selected = UserControls.First(p => (p.DataContext as WordViewModel).WordType == _selectedWordType);
                SelectedUserControl = selected;
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

         
        private void AddCommandAction(object obj)
        {
            ;
        }

        #endregion

    }
}
