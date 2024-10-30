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
        public string ImageSource { get; }
        protected static Button[,] buttons;
        public static string[,] pathImages;
        public Logic(int turnToMove, string imageSource)
        {
            TurnToMove = turnToMove;
            ImageSource = imageSource;
            pathImages = new string[3, 3];
        }
        public abstract void Move(Button button);

        public bool IsWin()
        {
            if (buttons != null)
            {              
                for (int i = 0; i < 3; i++)
                {
          
                    if (pathImages[i, 0] == pathImages[i, 1] && 
                        pathImages[i, 1] == pathImages[i, 2] &&
                        pathImages[i, 0] != null)
                        return true;
                    if (pathImages[0, i] == pathImages[1, i] && 
                        pathImages[1, i] == pathImages[2, i] &&
                        pathImages[0, i] != null)
                        return true;
                }

                if (pathImages[0,0] == pathImages[1, 1] && 
                    pathImages[0, 0] == pathImages[2, 2] && 
                    pathImages[0,0] != null)
                    return true;

                if (pathImages[0, 2] == pathImages[1, 1] && 
                    pathImages[0, 2] == pathImages[2, 0] &&
                    pathImages[0,2] != null)
                    return true;
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
