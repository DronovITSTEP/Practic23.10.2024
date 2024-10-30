using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        Button[,] buttons;

        Logic user;
        Logic comp;

        public MainWindow()
        {
            InitializeComponent();

            turnToMove = new Random().Next(2);

            buttons = new Button[3, 3] {
                 { oneButton, twoButton, threeButton},
                { fourButton, fiveButton, sixButton},
                { sevenButton, eightButton, nineButton}
            };

            if (turnToMove == 0)
            {
                user = new LogicComputer(buttons, 0,"images/nol.png");
                comp = new LogicUser(1,"images/krest.png");
            }
            else
            {
                comp = new LogicComputer(buttons, 0, "images/krest.png");
                user = new LogicUser(1, "images/nol.png");
                comp.Move(oneButton);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {           
            user.Move(sender as Button);
            if (user.IsWin()) MessageBox.Show("Победа юзера");
            comp.Move(sender as Button);
            if (comp.IsWin()) MessageBox.Show("Победа компа");
        }

    }
}
