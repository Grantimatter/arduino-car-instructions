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
    public class InstructionBlockModel
    {
        public InstructionBlockModel()
        {
            MainWindow.Instance.InstructionsStackPanel = new StackPanel();
            MainWindow.Instance.InstructionsStackPanel.VerticalAlignment = VerticalAlignment.Top;
            MainWindow.Instance.InstructionsStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            AddDefaultInstruction();
        }

        public static void RemoveInstruction(InstructionBlock obj)
        {
            if (MainWindow.Instance.InstructionsStackPanel.Children.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this instruction?", "This is the caption", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        MainWindowViewModel.InstructionBlocks.RemoveAt(obj.InstructionIndex - 1);
                        MainWindow.Instance.InstructionsStackPanel.Children.RemoveAt(obj.InstructionIndex - 1);

                        for (int i = 0; i < MainWindowViewModel.InstructionBlocks.Count; i++)
                        {
                            MainWindowViewModel.InstructionBlocks[i].InstructionIndex = i + 1;
                            MainWindowViewModel.InstructionBlocks[i].Name = "iBlock" + i + 1;
                            MainWindowViewModel.InstructionBlocks[i].indexLabel.Content = i + 1;
                            MainWindowViewModel.InstructionBlocks[i].mainGrid.Background = InstructionBgColorFinder(i + 1);
                        }
                        break;
                }
            }

            //MessageBox.Show("Children: " + MainWindow.Instance.InstructionsStackPanel.Children.Count + "\nInstruction Blocks: " + MainWindowViewModel.InstructionBlocks.Count);
        }

        public static void AddInstruction(User_Controls.InstructionBlock ib)
        {
            ib.BgColor = InstructionBgColorFinder(ib.InstructionIndex);
            ib.Name = "iBlock" + ib.InstructionIndex;
            MainWindowViewModel.InstructionBlocks.Insert(ib.InstructionIndex - 1, ib);

            MainWindow.Instance.InstructionsStackPanel.Children.Add(MainWindowViewModel.InstructionBlocks[ib.InstructionIndex - 1]);
        }

        public static void AddDefaultInstruction()
        {
            User_Controls.InstructionBlock ib = new User_Controls.InstructionBlock();
            ib.InstructionLabel = "New Instruction";
            ib.BlockColor = new SolidColorBrush(Colors.Maroon);
            ib.InstructionIndex = MainWindowViewModel.InstructionBlocks.Count + 1;

            AddInstruction(ib);
        }

        private static SolidColorBrush InstructionBgColorFinder(int i)
        {
            if (MainWindow.Instance.InstructionsStackPanel != null && i % 2 != 0)
                return new SolidColorBrush(Colors.White - (Colors.White * 0.1f));
            else
                return new SolidColorBrush(Colors.White);
        }
    }
}
