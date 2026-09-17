using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Kosci
{
    public partial class MainWindow : Window
    {
        private Image[] kosci;
        private bool[] dostepneKosci;
        private int[] wynikiKosci;

        private Random losowanie = new Random();

        public MainWindow()
        {
            InitializeComponent();

            kosci = new Image[]
            {
                Kosc1,
                Kosc2,
                Kosc3,
                Kosc4,
                Kosc5
            };

            dostepneKosci = new bool[]
            {
                true,
                true,
                true,
                true,
                true
            };

            wynikiKosci = new int[]
            {
                0,
                0,
                0,
                0,
                0
            };
        }

        private void PrzyciskRzut_Click(object sender, RoutedEventArgs e)
        {
            int suma = 0;

            for (int i = 0; i < kosci.Length; i++)
            {
                if (dostepneKosci[i])
                {
                    int wynik = losowanie.Next(1, 7);

                    wynikiKosci[i] = wynik;

                    WyswietlKosci(i, wynik);
                }

                suma += wynikiKosci[i];
            }

            Wynik.Text = suma.ToString();
        }

        private void WyswietlKosci(int numerKosci, int wynik)
        {
            string sciezka = $"Images/kosc{wynik}.png";

            kosci[numerKosci].Source = new BitmapImage(
                new Uri(sciezka, UriKind.Relative));
        }

        private void Kosc_Click(object sender, MouseButtonEventArgs e)
        {
            Image kliknietaKosc = (Image)sender;

            int numerKosci = Array.IndexOf(kosci, kliknietaKosc);

            if (dostepneKosci[numerKosci])
            {
                dostepneKosci[numerKosci] = false;
                kliknietaKosc.Opacity = 0.5;
            }
            else
            {
                dostepneKosci[numerKosci] = true;
                kliknietaKosc.Opacity = 1.0;
            }
        }
    }
}
