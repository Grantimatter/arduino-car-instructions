using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace InstructionSoftware.Models
{
    public static class Verify
    {
        private static ArduinoOutputWindow ardOut;
        private static StringBuilder sortOuput = null;
        private static int numOutputLines = 0;

        public static void VerifyProgram()
        {
            //ardOut = new ArduinoOutputWindow();
            //ardOut.Show();

            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            //sortOuput = new StringBuilder();
            //pProcess.OutputDataReceived += sortOutputHandler;
            pProcess.StartInfo.FileName = "cmd";
            pProcess.StartInfo.WorkingDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            pProcess.StartInfo.Arguments = "/k arduino compile -b arduino:avr:uno CarSketch";
            pProcess.StartInfo.UseShellExecute = false;
            //pProcess.StartInfo.RedirectStandardOutput = true;
            //pProcess.StartInfo.RedirectStandardInput = true;
            //pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();

            //StreamWriter wr = pProcess.StandardInput;
            //StreamReader rr = pProcess.StandardOutput;

            //wr.WriteLine("arduino compile -b arduino:avr:uno CarSketch");
            //wr.WriteLine("exit");

            //pProcess.BeginOutputReadLine();

            //string strOutput = rr.ReadToEndAsync().Result;
            //ardOut.ouputTextBox.Text = strOutput;
            //wr.Flush();
            pProcess.WaitForExit();
        }

        private static void sortOutputHandler(object sendingProcess, DataReceivedEventArgs outline)
        {
            if(!String.IsNullOrEmpty(outline.Data))
            {
                numOutputLines++;
                sortOuput.Append(Environment.NewLine + $"[{numOutputLines}] - {outline.Data}");
            }
        }

        private static void UpdateConsole(string text)
        {
            ardOut.ouputTextBox.Text += "\n" + text;
        }
    }
}
