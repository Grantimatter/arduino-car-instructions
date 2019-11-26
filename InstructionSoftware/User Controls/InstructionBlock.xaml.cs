using InstructionSoftware.ViewModels;
using InstructionSoftware.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
