using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InstructionSoftware.ViewModels.Commands
{
    public class AddInstructionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public AddInstructionCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}