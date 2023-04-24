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

namespace Kapcha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random rnd = new Random();
        public string KaptchaText = "";
        public MainWindow()
        {
            InitializeComponent();
            UpdateCaptcha();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghilklomnpqrstuwxyz0123456789";
            KaptchaText = "";

            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(rnd.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();
                lbl.Text = symbol;
                lbl.FontSize = rnd.Next(35, 85);
                lbl.RenderTransform = new RotateTransform(rnd.Next(-45, 45));
                lbl.Margin = new Thickness(10, 10, 10, 10);
                //lbl.Foreground = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                KaptchaText += symbol;
                SPanelSymbols.Children.Add(lbl);
            }
        }

        private void GenerateNoise(int volumeNoise)
        {
            CanvasNoise.Children.Clear();
            for (int i = 0; i < volumeNoise; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                rectangle.Width = rnd.Next(5, 50);
                rectangle.Height = rnd.Next(5, 50);
                CanvasNoise.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, rnd.Next(0, 350));
                Canvas.SetTop(rectangle, rnd.Next(0, 250));

            }
            
            for (int i = 0; i < volumeNoise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                ellipse.Width = rnd.Next(5, 50);
                ellipse.Height = rnd.Next(5, 50);
                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(0, 350));
                Canvas.SetTop(ellipse, rnd.Next(0, 250));
            }
        }

        private void UpdateCaptcha()
        {
            //SPanelSymbols.Children.Clear();
            //CanvasNoise.Children.Clear();
            GenerateSymbols(rnd.Next(4, 8));
            GenerateNoise(rnd.Next(10, 15));
            
        }

        private void btnChek_Click(object sender, RoutedEventArgs e)
        {
            string kaptch = tbKaptcha.Text.Trim();
            if (KaptchaText.Length != 0)
            {
                if (kaptch == KaptchaText)
                {
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
    }
}
