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
        public MessageCommand DisplayMessageCommand { get; private set; }
        public CloseAppCommand CloseAppCommand { get; private set; }
        public AddInstructionCommand AddInstructionCommand { get; private set; }

        public MainWindowViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
            CloseAppCommand = new CloseAppCommand(ShutdownApp);
            AddInstructionCommand = new AddInstructionCommand(AddInstruction);

            MainWindow.Instance.InstructionsStackPanel = new StackPanel();
            MainWindow.Instance.InstructionsStackPanel.VerticalAlignment = VerticalAlignment.Top;
            MainWindow.Instance.InstructionsStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            User_Controls.InstructionBlock ib = new User_Controls.InstructionBlock();
            AddInstruction();
        }

        private void AddInstruction()
        {
            AddDefaultInstruction();
        }

        private void AddDefaultInstruction()
        {
            User_Controls.InstructionBlock ib = new User_Controls.InstructionBlock();
            ib.BgColor = InstructionBgColorFinder();

            ib.InstructionIndex = MainWindow.Instance.InstructionsStackPanel.Children.Count + 1;
            ib.InstructionLabel = "New Instruction";
            ib.BlockColor = new SolidColorBrush(Colors.Maroon);

            MainWindow.Instance.InstructionsStackPanel.Children.Add(ib);
        }

        private SolidColorBrush InstructionBgColorFinder()
        {
            if (MainWindow.Instance.InstructionsStackPanel.Children.Count == 0)
                return new SolidColorBrush(Colors.LightGray);
            else if (MainWindow.Instance.InstructionsStackPanel.Children.Count % 2 > 0)
                return new SolidColorBrush(Colors.Gray);
            else
                return new SolidColorBrush(Colors.LightGray);
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