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
        List<Tuple<int, int>> positions = new List<Tuple<int, int>>();
        public LogicComputer(Button[,] buttons, int turnToMove, string imageSource) :
                                base(turnToMove, imageSource){
            Logic.buttons = buttons;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    positions.Add(new Tuple<int, int>(i, j));
                }
            }
        }
        public override void Move(Button button)
        {
            int index;
            Tuple<int, int> position;
            do
            {
                index = random.Next(0, positions.Count);
                position = positions[index];
            } while (!buttons[position.Item1, position.Item2].IsEnabled);

            Image img = GetImage();
            pathImages[position.Item1, position.Item2] = img.Source.ToString();

            buttons[position.Item1, position.Item2].Content = img;
            buttons[position.Item1, position.Item2].IsEnabled = false;
            positions.RemoveAt(index);           
        }
    }
}
