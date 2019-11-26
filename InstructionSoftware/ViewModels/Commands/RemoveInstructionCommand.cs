using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace InstructionSoftware.ViewModels.Commands
{
    public class RemoveInstructionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<User_Controls.InstructionBlock> _execute;

        public RemoveInstructionCommand(Action<User_Controls.InstructionBlock> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as User_Controls.InstructionBlock);
        }
    }
}
