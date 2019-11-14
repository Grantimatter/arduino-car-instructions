using InstructionSoftware.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace InstructionSoftware.ViewModels
{
    public class CloseAppViewModel
    {
        public CloseAppCommand ShutdownApplicationCommand { get; private set; }

        public CloseAppViewModel()
        {
            ShutdownApplicationCommand = new CloseAppCommand(ShutdownApp);
        }

        public void ShutdownApp()
        {
            Application.Current.Shutdown();
        }
    }
}
