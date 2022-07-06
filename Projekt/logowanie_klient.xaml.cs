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
    /// Logika interakcji dla klasy logowanie_klient.xaml
    /// </summary>
    
        public partial class logowanie_klient : Window
    {
        public static int mail { get; private set; }
        public logowanie_klient()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            logowanie win = new logowanie();
            this.Close();
            win.Show();
        }

        private void utworz_Click(object sender, RoutedEventArgs e)
        {
            tworzeniakonta win = new tworzeniakonta();
            this.Close();
            win.Show();
        }
        private void logowanie_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var password = from klienci in db.Klienci
                           select klienci;
            foreach (var pw in password)
            {
                if (pw.Email == emaillog.Text)
                {
                    if (pw.Hasło == haslolog.Password.ToString())
                    {
                        mail = pw.ID_Klienta;
                        Klenci klenci = new Klenci();
                        klenci.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
