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
        public InstructionBlock()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string InstructionLabel { get; set; }
        public System.Windows.Media.SolidColorBrush bgColor { get; set; }
        public int MaxLength { get; set; }
    }
}
