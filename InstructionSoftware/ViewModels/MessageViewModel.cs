using InstructionSoftware.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace InstructionSoftware.ViewModels
{
    public class MessageViewModel
    {
        public MessageCommand DisplayMessageCommand { get; private set; }

        public MessageViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
