using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace InstructionSoftware.Models
{
    public static class Verify
    {
        public static string ExMessage { get; set; }
        public static string StdOut { get; private set; }
        public static string StdErr { get; private set; }

        private static ArduinoOutputWindow ardOut;

        public static void VerifyProgram()
        {
            ardOut = new ArduinoOutputWindow();
            ardOut.Owner = MainWindow.Instance;
            ardOut.Show();

            string args = "/k arduino-cli upload -p " + (string)MainWindow.Instance.serialComboBox.SelectedItem + " -t -b arduino:avr:uno CarSketch";

            StartProcess("cmd.exe", args);
            ardOut.ouputTextBox.Text = StdOut;
        }

        private static void StartProcess(string fileName, string arguments)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo(fileName, arguments);
            
            // Set options
            pInfo.WorkingDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;

            // Specify redirection
            pInfo.RedirectStandardOutput = true;
            pInfo.RedirectStandardInput = true;
            pInfo.RedirectStandardError = true;

            StdOut = string.Empty;

            Process process = new Process();
            process.StartInfo = pInfo;

            process.Start();

            StreamWriter wr = process.StandardInput;
            StreamReader rr = process.StandardOutput;

            Read(rr);
        }

        static async void Read(StreamReader rr)
        {
            StdOut = await rr.ReadToEndAsync();
            UpdateConsole(StdOut);
        }

        private static void UpdateConsole(string text)
        {
            ardOut.ouputTextBox.Text = text;
        }
    }
}