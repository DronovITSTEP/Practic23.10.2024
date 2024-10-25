using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Practic23._10._2024
{
    internal abstract class Logic
    {
        public int TurnToMove { get; }
        public List<List<Button>> Buttons { get; set; }
        public string ImageSource {get;}
        public Logic(List<List<Button>> buttons, int turnToMove, string imageSource)
        {
            Buttons = buttons;
            TurnToMove = turnToMove;
            ImageSource = imageSource;
        }
        public abstract int Move();

        public bool IsWin()
        {
            foreach (var listButton in Buttons)
            {
                if (listButton.Count == 0) return true;
            }
            return false;
        }

        public Image GetImage()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(ImageSource, UriKind.Relative));
            return img;
        }
    }
}
