using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MUSIC.MVVM.Helpers
{
    public class RelayCommand : ICommand
    {
        private Func<bool> canExecute;
        private Action executeAction;
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action executeAction,
        Func<bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }
        public RelayCommand(Action executeAction)
        {
            this.executeAction = executeAction;
            this.canExecute = () => true;
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
