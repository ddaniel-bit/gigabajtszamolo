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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sldSebesseg.ValueChanged += SldSebesseg_ValueChanged;
        }

        private void SldSebesseg_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblSebesseg.Content = sldSebesseg.Value.ToString();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Szamol_Click(object sender, RoutedEventArgs e)
        {
            double kapacitas = int.Parse(txtKapacitas.Text);
            double sebesseg = sldSebesseg.Value;
            if (cbMertekegyseg1.SelectionBoxItem.ToString() == "MB")
            {
                kapacitas *= 1000;
            }
            else if (cbMertekegyseg1.SelectionBoxItem.ToString() == "GB")
            {
                kapacitas *= 1000 * 1000;
            }
            else if (cbMertekegyseg1.SelectionBoxItem.ToString() == "TB")
            {
                kapacitas *= 1000 * 1000 * 1000;
            }

            if (cbMertekegyseg2.SelectionBoxItem.ToString() == "MBps")
            {
                sebesseg *= 1000;
            }
            else if (cbMertekegyseg2.SelectionBoxItem.ToString() == "GBps")
            {
                sebesseg *= 1000 * 1000;
            }
            else if (cbMertekegyseg2.SelectionBoxItem.ToString() == "TBps")
            {
                sebesseg *= 1000 * 1000 * 1000;
            }

            double eredmeny = kapacitas / sebesseg;
            TimeSpan ts = TimeSpan.FromSeconds(eredmeny);

            string orapercmasodperc = string.Format("{0:D2} óra {1:D2} perc {2:D2} másodperc",
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds);

            lblEredmeny.Content = orapercmasodperc;


        }
    }
}
