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
        private List<Button> buttons;
        public MainWindow()
        {
            InitializeComponent();

            buttons = new List<Button>
            {
                oneButton, 
                twoButton, 
                threeButton, 
                fourButton, 
                fiveButton, 
                sixButton, 
                sevenButton, 
                eightButton,
                nineButton
            };

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = GetImage();
            button.IsEnabled = false;
            button.Background = Brushes.Transparent;
        }

        private Image GetImage() 
        { 
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("images/nol.png", UriKind.Relative));
            return img;
        }
    }
}
