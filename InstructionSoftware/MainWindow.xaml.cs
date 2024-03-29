﻿using InstructionSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InstructionSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StackPanel InstructionsStackPanel { get; set; }
        public ScrollViewer IstScrollView { get; private set; }
        public static MainWindow Instance;

        public MainWindow()
        {
            Instance = this;

            InitializeComponent();
            DataContext = new MainWindowViewModel();
            IstScrollView = InstructionScrollView;
            IstScrollView.Content = InstructionsStackPanel;
        }

        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else
                return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {

        }

        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);
            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }

        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }

        private void CalculateScale()
        {
            double yScale = ActualHeight / 250f;
            double xScale = ActualWidth / 200f;
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(main_window, value);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo("https://github.com/Grantimatter/arduino-car-instructions/wiki")
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(ps);
            e.Handled = true;
        }
    }
}
