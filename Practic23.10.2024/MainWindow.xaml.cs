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
using System.Windows.Threading;

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

        List<Image> lines;
        DispatcherTimer sleepTimer = new DispatcherTimer();
        DispatcherTimer gameTimer = new DispatcherTimer();

        DateTime currentTimer = new DateTime(1, 1, 1, 0, 0, 0);
       
        public MainWindow()
        {
            InitializeComponent();

            turnToMove = new Random().Next(2);

            buttons = new Button[3, 3] {
                 { oneButton, twoButton, threeButton},
                { fourButton, fiveButton, sixButton},
                { sevenButton, eightButton, nineButton}
            };
            lines = new List<Image>
            {
                oneLineVert,
                twoLineVert,
                threeLineVert,
                oneLineHor,
                twoLineHor,
                threeLineHor,
                oneLineDiag,
                twoLineDiag
            };

            if (turnToMove == 0)
            {
                comp = new LogicComputer(buttons, 0, "images/nol.png");
                user = new LogicUser(1, "images/krest.png");
                moveText.Text = "ход игрока";
            }
            else
            {
                comp = new LogicComputer(buttons, 0, "images/krest.png");
                user = new LogicUser(1, "images/nol.png");
                moveText.Text = "ход компьютера";
                comp.Move(oneButton);
                moveText.Text = "ход игрока";
            }

            sleepTimer.Interval = TimeSpan.FromSeconds(2);
            sleepTimer.Tick += TimerTick;

            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += TimeText;
            gameTimer.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {             
            user.Move(sender as Button);
            sleepTimer.Start();
            if (user.IsWin())
            {
                FinishedGame("Победа юзера");                
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            moveText.Text = "ход компьютера";


            comp.Move(sender as Button);
            if (comp.IsWin())
            {
                FinishedGame("Победа компа");
            }
            moveText.Text = "ход игрока";
            sleepTimer.Stop();
        }
        private void TimeText(object sender, EventArgs e)
        {
            currentTimer = currentTimer.AddSeconds(1);
            timeText.Text = currentTimer.ToLongTimeString();
        }

        private void FinishedGame(string winner)
        {
            lines[Logic.LineNumber].Visibility = Visibility.Visible;
            gameTimer.Stop();
            sleepTimer.Stop();
            new FinishGame(winner).Show();
            Close();
        }
    }
}