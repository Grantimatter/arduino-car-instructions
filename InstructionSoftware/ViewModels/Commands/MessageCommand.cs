using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InstructionSoftware.ViewModels.Commands
{
    public class MessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<string> _execute;

        public MessageCommand(Action<string> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as string);
        }
    }
}