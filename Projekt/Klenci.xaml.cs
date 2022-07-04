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
    /// Logika interakcji dla klasy Klenci.xaml
    /// </summary>
    public partial class Klenci : Window
    {

        public Klenci()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var film = from f in db.Filmy
                       where f.Stan == "Na magazynie"
                       select f;
            this.filmy.ItemsSource = film.ToList();
            MessageBox.Show(logowanie_klient.mail);
        }
        private void wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
