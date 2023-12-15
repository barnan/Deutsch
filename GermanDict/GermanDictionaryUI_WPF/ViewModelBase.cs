using BaseClasses;

namespace GermanDict.UI
{
    public abstract class ViewModelBase : BindableBase
    {
        private bool _isVisible = true;
        private string _name;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

    }
}
