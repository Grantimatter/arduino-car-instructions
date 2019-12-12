using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace InstructionSoftware.Models
{
    class SaveProgram
    {
        public static void SaveProgramToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Program";
            sfd.Filter = "Carduino Program (*.car)|*.car";
            sfd.RestoreDirectory = true;
            sfd.InitialDirectory = Directory.GetCurrentDirectory() + @"..\..\";

            string filePath = "", programName = "";

            if(sfd.ShowDialog() == true)
            {
                programName = Path.GetFileName(sfd.FileName);
                filePath = sfd.FileName;

                SaveFile(filePath);
            }
        }

        private static void SaveFile(string filePath)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Instruction> instructions = Instruction.GetInstructionsFromBlocks();

                Program program = new Program(filePath, "New Program", DateTime.Now, DateTime.Now, instructions);

                // Serialize object directly into file stream

                serializer.Serialize(file, program);
            }
        }
    }
}
