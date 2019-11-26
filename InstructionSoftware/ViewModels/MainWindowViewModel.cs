using InstructionSoftware.User_Controls;
using InstructionSoftware.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InstructionSoftware.ViewModels
{
    public class MainWindowViewModel
    {
        public InstructionBlockModel ibm { get; set; }

        public MessageCommand DisplayMessageCommand { get; private set; }
        public CloseAppCommand CloseAppCommand { get; private set; }
        public AddInstructionCommand AddInstructionCommand { get; private set; }

        public static List<InstructionBlock> InstructionBlocks = new List<InstructionBlock>();

        public MainWindowViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
            CloseAppCommand = new CloseAppCommand(ShutdownApp);
            AddInstructionCommand = new AddInstructionCommand(AddInstruction);
            ibm = new InstructionBlockModel();
        }

        public void AddInstruction()
        {
            InstructionBlockModel.AddDefaultInstruction();
        }

        public void AddInstruction(User_Controls.InstructionBlock ib)
        {
            InstructionBlockModel.AddInstruction(ib);
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