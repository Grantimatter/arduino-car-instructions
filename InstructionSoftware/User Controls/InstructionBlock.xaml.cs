using InstructionSoftware.ViewModels;
using InstructionSoftware.ViewModels.Commands;
using System.Windows.Controls;
using InstructionSoftware.Models;
using System;

namespace InstructionSoftware.User_Controls
{
    public partial class InstructionBlock : UserControl
    {
        public RemoveInstructionCommand RemoveInstructionCommand { get; private set; }

        public InstructionBlock()
        {
            InitializeComponent();
            this.DataContext = this;
            RemoveInstructionCommand = new RemoveInstructionCommand(RemoveInstruction);
            removeButton.CommandParameter = this;
            dtComboBox.ItemsSource = Enum.GetValues(typeof(Instruction.DriveType));
        }

        private void RemoveInstruction(InstructionBlock ib)
        {
            InstructionBlockModel.RemoveInstruction(ib);
        }

        public string InstructionLabel { get; set; }
        public int InstructionIndex { get; set; }
        public System.Windows.Media.SolidColorBrush BlockColor { get; set; }
        public System.Windows.Media.SolidColorBrush BgColor { get; set; }
        public int MaxLength { get; set; }
    }
}
