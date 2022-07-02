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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy logowanie.xaml
    /// </summary>
    public partial class logowanie : Window
    {
        public logowanie()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }

        private void klient_Click(object sender, RoutedEventArgs e)
        {
            logowanie_klient win = new logowanie_klient();
            this.Close();
            win.Show();
        }

        private void pracownicy_Click(object sender, RoutedEventArgs e)
        {
            logowanie_pracownik win = new logowanie_pracownik();
            this.Close();
            win.Show();
        }
        private void kurier_click(object sender, RoutedEventArgs e)
        {
            logowanie_Kurkier win = new logowanie_Kurkier();
            this.Close();
            win.Show();
        }
    }
}
