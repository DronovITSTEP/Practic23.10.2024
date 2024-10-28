using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Practic23._10._2024
{
    internal class LogicComputer : Logic
    {
        private Random random = new Random();

        List<List<String>> buttons = new List<List<String>>
            {
                new List<String> {"oneButton","twoButton","threeButton"},
                new List<String> { "fourButton","fiveButton", "sixButton"},
                new List<String> { "sevenButton", "eightButton", "nineButton" },
                new List<String> { "oneButton", "fourButton", "sevenButton" },
                new List<String> { "twoButton", "fiveButton", "eightButton" },
                new List<String> { "threeButton", "sixButton", "nineButton" },
                new List<String> { "oneButton", "fiveButton", "nineButton" },
                new List<String> { "threeButton", "fiveButton", "sevenButton" }
            };
        public LogicComputer(List<List<Button>> buttons,
                    int turnToMove,
                    string imageSource) :
                    base(buttons, turnToMove, imageSource)
        { }
        public override void Move(Button button)
        {
            int randomRow = random.Next(Buttons.Count);
            int randomCol = random.Next(Buttons[randomRow].Count);

            Buttons[randomRow][randomCol].Content = GetImage();
            DeleteButton(Buttons[randomRow][randomCol]);
        }
    }
}
