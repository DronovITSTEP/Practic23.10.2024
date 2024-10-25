using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic23._10._2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turnToMove;
        List<List<Button>> buttons;

        Logic user;
        Logic comp;
        public MainWindow()
        {
            InitializeComponent();

            turnToMove = new Random().Next(2);

            buttons = new List<List<Button>>
            {
                new List<Button> {oneButton,twoButton,threeButton},
                new List<Button> { fourButton,fiveButton, sixButton},
                new List<Button> { sevenButton, eightButton, nineButton},
                new List<Button> { oneButton, fourButton, sevenButton },
                new List<Button> { twoButton, fiveButton, eightButton },
                new List<Button> { threeButton, sixButton, nineButton },
                new List<Button> { oneButton, fiveButton, nineButton },
                new List<Button> { threeButton, fiveButton, sevenButton }
            };

            if (turnToMove == 0)
            {
                user = new LogicUser(buttons, 0,"images/krest.png");
                comp = new LogicUser(buttons, 1,"images/nol.png");
            }
            else
            {
                comp = new LogicUser(buttons, 0, "images/krest.png");
                user = new LogicUser(buttons, 1, "images/nol.png");
                comp.Move();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = user.GetImage();
            comp.Move();
        }

    }
}
