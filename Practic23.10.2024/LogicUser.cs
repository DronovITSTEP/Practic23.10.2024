using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Practic23._10._2024
{
    internal class LogicUser : Logic
    {
        public LogicUser(int turnToMove, string imageSource) : 
                            base (turnToMove, imageSource) { }

        public override void Move(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            Image img = GetImage();
            pathImages[row, col] = img.Source.ToString();

            button.Content = img;
            button.IsEnabled = false;
          
        }
    }
}
