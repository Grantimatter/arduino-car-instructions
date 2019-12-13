using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace InstructionSoftware.Models
{
    public class SaveProgram
    {
        public const string fileFilter = "Carduino Program (*.car)|*.car";
        public static void SaveProgramToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = fileFilter;
            sfd.Title = "Save Program";
            sfd.RestoreDirectory = true;
            //sfd.InitialDirectory = Directory.GetCurrentDirectory() + @"..\";

            string filePath, programName;

            if(sfd.ShowDialog() == true)
            {
                filePath = sfd.FileName;
                programName = Path.GetFileName(filePath);

                CheckIfFileExists(filePath);
            }
        }

        private static void CheckIfFileExists(string filePath)
        {
            Program program;

            if (File.Exists(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                using (var fileStream = File.Open(filePath, FileMode.Open))
                {
                    program = (Program)binaryFormatter.Deserialize(fileStream);
                    program.instructions = Instruction.GetInstructionsFromBlocks();
                }

                /*
                using (StreamReader file = File.OpenText(filePath))

                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    program = o2.ToObject<Program>();

                    program.instructions = Instruction.GetInstructionsFromBlocks();
                    SaveFile(program);
                }
                */
            }
            else
            {
                SaveFile(filePath, Path.GetFileName(filePath), DateTime.Now);
            }
        }

        private static void SaveFile(string filePath, string programName, DateTime dateCreated)
        {
            Program newProgram = new Program(filePath, programName, dateCreated, DateTime.Now, Instruction.GetInstructionsFromBlocks());

            SaveFile(newProgram);
        }

        private static void SaveFile(Program saveProgram)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (var fileStream = File.Create(saveProgram.filePath))
            {
                saveProgram.lastModified = DateTime.Now;

                binaryFormatter.Serialize(fileStream, saveProgram);

                MainWindow.Instance.fileNameLabel.Content = saveProgram.programName;
                MainWindow.Instance.lastSavedLabel.Content = "Last Saved: Just now";

                // Serialize object directly into file stream
                //serializer.Serialize(file, saveProgram);
            }
        }
    }
}
