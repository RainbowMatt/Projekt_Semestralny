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
    /// Logika interakcji dla klasy Kurierzy.xaml
    /// </summary>
    public partial class Kurierzy : Window
    {
        public Kurierzy()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var dostawa = from w in db.Wypozyczenia
                          where w.ID_Kuriera == logowanie_Kurkier.id_kurk
                          join f in db.Filmy
                            on w.ID_Filmu equals f.ID_Filmu
                          where f.Stan == "W drodze"
                          join k in db.Klienci
                            on w.ID_Klienta equals k.ID_Klienta

                          select new
                          {
                              w.ID_Filmu,
                              k.Imie,
                              k.Nazwisko,
                              k.Miejscowosc,
                              k.Ulica,
                              k.NrDomu,
                              k.NrTelefonu
                          };
            this.dostawa.ItemsSource = dostawa.ToList();
        }

        private void wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
