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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Practic23._10._2024
{
    /// <summary>
    /// Логика взаимодействия для FinishGame.xaml
    /// </summary>
    public partial class FinishGame : Window
    {
            DispatcherTimer timer = new DispatcherTimer();
        public FinishGame(string winner)
        {
            InitializeComponent();
            winnerText.Text = winner;
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += CloseTimer;
            timer.Start();
        }

        private void CloseTimer(object sender, EventArgs e)
        {
            new StartGame().Show();
            timer.Stop();
            Close();
        }

    }
}
