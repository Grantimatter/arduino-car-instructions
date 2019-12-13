using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using InstructionSoftware.Models;

namespace InstructionSoftware.ViewModels.Commands
{
    public class LoadProgram
    {
        public static void LoadProgramFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = SaveProgram.fileFilter;
            if(openFileDialog.ShowDialog() == true)
            {

            }
        }
    }
}
