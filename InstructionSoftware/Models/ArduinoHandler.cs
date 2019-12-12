using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Controls;
using System.Windows;

namespace InstructionSoftware.Models
{
    public class ArduinoHandler
    {
        public static Dictionary<string, string> boardList = new Dictionary<string, string>();
        public static List<string> ports = new List<string>();

        public ArduinoHandler()
        {
            boardList.Add("Adafruit Circuit Playground",        "arduino:avr:circuitplay32u4cat");
            boardList.Add("Arduino BT",                         "arduino:avr:bt");
            boardList.Add("Arduino Duemilanove or Diecimila",   "arduino:avr:diecimila");
            boardList.Add("Arduino Esplora",                    "arduino:avr:esplora");
            boardList.Add("Arduino Ethernet",                   "arduino:avr:ethernet");
            boardList.Add("Arduino Fio",                        "arduino:avr:fio");
            boardList.Add("Arduino Gemma",                      "arduino:avr:gemma");
            boardList.Add("Arduino Industrial 101",             "arduino:avr:chiwawa");
            boardList.Add("Arduino Leonardo",                   "arduino:avr:leonardo");
            boardList.Add("Arduino Leonardo ETH",               "arduino:avr:leonardoeth");
            boardList.Add("Arduino Mega ADK",                   "arduino:avr:megaADK");
            boardList.Add("Arduino Mega or Mega 2560",          "arduino:avr:mega");
            boardList.Add("Arduino Micro",                      "arduino:avr:micro");
            boardList.Add("Arduino Mini",                       "arduino:avr:mini");
            boardList.Add("Arduino NG or older",                "arduino:avr:atmegang");
            boardList.Add("Arduino Nano",                       "arduino:avr:nano");
            boardList.Add("Arduino Pro or Pro Mini",            "arduino:avr:pro");
            boardList.Add("Arduino Robot Control",              "arduino:avr:robotControl");
            boardList.Add("Arduino Robot Motor",                "arduino:avr:robotMotor");
            boardList.Add("Arduino Uno",                        "arduino:avr:uno");
            boardList.Add("Arduino Uno WiFi",                   "arduino:avr:unowifi");
            boardList.Add("Arduino Yún",                        "arduino:avr:yun");
            boardList.Add("Arduino Yún Mini",                   "arduino:avr:yunmini");
            boardList.Add("LilyPad Arduino",                    "arduino:avr:lilypad");
            boardList.Add("LilyPad Arduino USB",                "arduino:avr:LilyPadUSB");
            boardList.Add("Linino One",                         "arduino:avr:one");

            PopulateComboBoxes();
        }

        private static void PopulateComboBoxes()
        {
            FillBoardComboBox();
            GetPorts();
        }

        public static void FillBoardComboBox()
        {
            ComboBox boardBox = MainWindow.Instance.boardComboBox;
            SerialPort serialPort = new SerialPort();
            //serialPort.
            //boardBox.
            boardBox.Items.Clear();
            boardBox.ItemsSource = boardList.Keys;

            /*
            foreach (var s in boardList)
            {
                ComboBoxItem board = new ComboBoxItem();
                board.Content = s.Key;
                boardBox.Items.Add(board.Content);
            }
            */
        }

        public static void GetPorts()
        {
            ComboBox portsComboBox = MainWindow.Instance.serialComboBox;
            string[] ports = SerialPort.GetPortNames();

            portsComboBox.Items.Clear();
            //portsComboBox.ItemsSource = ports;

            
            foreach (string port in ports)
            {
                portsComboBox.Items.Add(port);
            }
        }

        public static string GetBoard(string ardBoardName)
        {
            return boardList[ardBoardName];
        }
    }
}
