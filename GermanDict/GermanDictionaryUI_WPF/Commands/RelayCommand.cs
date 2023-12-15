using System;
using System.Windows.Input;

namespace GermanDict.UI.Commands
{
    public class RelayCommand : ICommand
    {
        private Action _actionToExecute;
        private Action<object> _actionToExecuteWithParam;
        private Predicate<object> _canExecute;

        private event EventHandler CanExecuteChangedInternal;


        public RelayCommand(Action execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action actionToExecute, Predicate<object> canExecute)
        {
            Nullcheck(actionToExecute, canExecute);

            _actionToExecute = actionToExecute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> actionToExecuteWithParam, Predicate<object> canExecute)
        {
            Nullcheck(actionToExecuteWithParam, canExecute);

            _actionToExecuteWithParam = actionToExecuteWithParam;
            _canExecute = canExecute;
        }              

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute != null && _canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            if (_actionToExecuteWithParam != null)
            {
                _actionToExecuteWithParam(parameter);
                return;
            }

            _actionToExecute();
        }


        public void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            _canExecute = _ => false;
            _actionToExecute = () => { return; };
            _actionToExecuteWithParam = _ => { return; };
        }

        #region private

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        private void Nullcheck(object actionToExecute, object canExecute)
        {
            if (actionToExecute == null)
            {
                throw new ArgumentNullException("actionToExecute");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
        }

        #endregion
    }
}
