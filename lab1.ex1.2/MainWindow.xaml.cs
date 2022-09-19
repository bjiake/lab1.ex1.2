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

namespace lab1.ex1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int countLengthFraction = 0;
        public static int countRadiusFraction = 0;
        public static int countRadiusInternalFraction = 0;
        public static int countDensityFraction = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TbLength_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            CheckInput.IsOnlyDigit(e, sender);
        }

        private void TbRadius_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckInput.IsOnlyDigit(e, sender);
        }

        private void TbInternalRadius_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckInput.IsOnlyDigit(e, sender);
        }

        private void tbDensity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckInput.IsOnlyDigit(e, sender);
        }

        private void BtResult_Click(object sender, RoutedEventArgs e)
        {
            double volume, weigth;
            bool parseLength = Double.TryParse(TbLength.Text, out double length);
            bool parseRadius = Double.TryParse(TbRadius.Text, out double radius);
            bool parseRadiusInternal = Double.TryParse(TbInternalRadius.Text, out double radiusInternal);
            bool parseDensity = Double.TryParse(tbDensity.Text, out double density);

            if (!parseLength || !parseDensity || !parseRadius || !parseRadiusInternal)
            {
                MessageBox.Show("Введены некорректные данные");
                return;
            }
            if (length == 0 || radius == 0 || radiusInternal == 0 || density == 0 || radius <= radiusInternal)//Не корректные данные
            {
                TbLength.Text = "";
                TbRadius.Text = "";
                TbInternalRadius.Text = "";
                tbDensity.Text = "";
                MessageBox.Show("Введены некорректные данные");
                return;
            }

            volume = length * Math.PI * (Math.Pow(radius, 2) * Math.Pow(radiusInternal, 2));
            weigth = volume * density;
            int round = 6;

            if(Math.Round(weigth, 6) == 0) {
                while(Math.Round(weigth, round) == 0) {
                    round++;
                }
                MessageBox.Show($"Масса трубы:{Math.Round((weigth), round)}\n Объем трубы равен: {Math.Round(( volume ), round + 2)}");
                return;
            }

            MessageBox.Show($"Масса трубы:{Math.Round((weigth), 6)}\n Объем трубы равен: {Math.Round((volume), 6)}");
        }
    }
}
