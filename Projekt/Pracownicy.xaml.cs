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
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Window
    {
        public Pracownicy()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var wypo = from f in db.Wypozyczenia
                       select f;
            this.wypo.ItemsSource = wypo.ToList();
        }
        private void wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
