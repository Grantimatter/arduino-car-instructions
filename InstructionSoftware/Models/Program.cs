using System;
using System.Collections.Generic;
using System.Text;

namespace InstructionSoftware.Models
{
    [Serializable]
    public class Program
    {
        public string programName, filePath;
        public DateTime dateCreated, lastModified;
        public List<Instruction> instructions;

        public Program(string fp, string pn, DateTime dc, DateTime lm, List<Instruction> ins)
        {
            programName = pn;
            filePath = fp;
            dateCreated = dc;
            lastModified = lm;
            instructions = ins;
        }
    }
}