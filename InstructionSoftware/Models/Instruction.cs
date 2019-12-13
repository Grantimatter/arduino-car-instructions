using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using InstructionSoftware.ViewModels;

namespace InstructionSoftware.Models
{
    [Serializable]
    public class Instruction
    {
        int t, dmp, pmp, das;
        DriveType dt;

        Instruction() { }

        Instruction(DriveType driveType, int time, int drivMotorPower, int passMotorPower, int delayAfterStop)
        {
            dt = driveType;
            t = time;
            dmp = drivMotorPower;
            pmp = passMotorPower;
            das = delayAfterStop;
        }

        public static List<Instruction> GetInstructionsFromBlocks()
        {
            List<Instruction> ins = new List<Instruction>();

            foreach (var insBlock in MainWindowViewModel.InstructionBlocks)
            {
                Instruction newIns = new Instruction(
                    (DriveType)insBlock.dtComboBox.SelectedIndex,
                    (int)insBlock.tSlider.Value,
                    (int)insBlock.DSlider.Value,
                    (int)insBlock.PSlider.Value,
                    (int)insBlock.dasSlider.Value
                    );
                ins.Add(newIns);
            }

            MessageBox.Show("Instruction 1: " + ins[0]);

            return ins;
        }

        [Serializable]
        public enum DriveType
        {
            forward,
            backward,
            left,
            right
        };
    }
}
