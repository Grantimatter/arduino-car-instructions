using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InstructionSoftware.ViewModels.Commands
{
    public class VerifyProgramCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action _execute;

        public VerifyProgramCommand(Action execute)
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
