using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SuperProga.UI.Wpf.Commands
{
    public class SuperCommand : ICommand
    {
        Action<object> _action;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);

        }

        public SuperCommand(Action<object> action)
        {
            _action = action;
        }
    }
}
