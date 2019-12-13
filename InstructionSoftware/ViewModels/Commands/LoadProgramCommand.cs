using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InstructionSoftware.ViewModels.Commands
{
    public class LoadProgramCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        private LoadProgram loadProgram;

        public LoadProgramCommand(Action execute)
        {
            _execute = execute;
        }

        public LoadProgramCommand(LoadProgram loadProgram)
        {
            this.loadProgram = loadProgram;
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
