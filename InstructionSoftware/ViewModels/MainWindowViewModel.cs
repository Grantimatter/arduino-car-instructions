using InstructionSoftware.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace InstructionSoftware.ViewModels
{
    public class MainWindowViewModel
    {
        public MessageCommand DisplayMessageCommand { get; private set; }
        public CloseAppCommand CloseAppCommand { get; private set; }

        public MainWindowViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
            CloseAppCommand = new CloseAppCommand(ShutdownApp);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShutdownApp()
        {
            Application.Current.Shutdown();
        }
    }
}