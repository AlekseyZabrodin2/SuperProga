using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SuperProga.UI.Wpf.Commands
{
    public class SuperCommand : ICommand
    {
        Action<object> _action;
        Func<bool> _canExecuteFunc;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
          return _canExecuteFunc == null || _canExecuteFunc();
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);

        }

        public SuperCommand(Action<object> action, Func<bool> canExecuteFunc=null)
        {
            _action = action;
           _canExecuteFunc = canExecuteFunc;
        }
    }
}
