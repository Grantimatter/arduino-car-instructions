﻿using InstructionSoftware.User_Controls;
using InstructionSoftware.ViewModels.Commands;
using InstructionSoftware.Models;
using System.Collections.Generic;
using System.Windows;
using System;

namespace InstructionSoftware.ViewModels
{
    public class MainWindowViewModel
    {
        public InstructionBlockModel ibm { get; set; }
        public MessageCommand DisplayMessageCommand { get; private set; }
        public CloseAppCommand CloseAppCommand { get; private set; }
        public AddInstructionCommand AddInstructionCommand { get; private set; }
        public VerifyProgramCommand VerifyProgramCommand { get; private set; }
        public ConsoleInputCommand ConsoleInputCommand { get; private set; }
        public ArduinoHandler ArduinoHandler { get; private set; }
        public SaveFileCommand SaveFileCommand { get; private set; }
        public LoadProgramCommand LoadProgramCommand { get; private set; }

        public static List<InstructionBlock> InstructionBlocks = new List<InstructionBlock>();

        public MainWindowViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
            CloseAppCommand = new CloseAppCommand(ShutdownApp);
            AddInstructionCommand = new AddInstructionCommand(AddInstruction);
            VerifyProgramCommand = new VerifyProgramCommand(VerifyProgram);
            ConsoleInputCommand = new ConsoleInputCommand(ConsoleInput);
            ArduinoHandler = new ArduinoHandler();
            SaveFileCommand = new SaveFileCommand(SaveFile);
            LoadProgramCommand = new LoadProgramCommand(LoadProgramFile);
            ibm = new InstructionBlockModel();
        }

        private void LoadProgramFile()
        {
            LoadProgram.LoadProgramFromFile();
        }

        private void SaveFile(string filePath)
        {
            SaveProgram.SaveProgramToFile();
        }

        private void ConsoleInput(string obj)
        {
            
        }

        private void VerifyProgram()
        {
            Verify.VerifyProgram();
        }

        public void AddInstruction()
        {
            InstructionBlockModel.AddDefaultInstruction();
        }

        public void AddInstruction(InstructionBlock ib)
        {
            InstructionBlockModel.AddInstruction(ib);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShutdownApp()
        {
            Application.Current.Shutdown();
        }
    }
}