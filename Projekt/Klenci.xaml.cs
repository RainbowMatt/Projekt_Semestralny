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
            wyswietlanie();
        }
        public void wyswietlanie()
        {
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var film = from f in db.Filmy
                       where f.Stan == "Na magazynie"
                       select new
                       {
                           f.ID_Filmu,
                           f.Tytul,
                           f.Gatunek,
                           f.Czas_trwania
                       };
            var wypozycznia = from w in db.Wypozyczenia
                              join k in db.Klienci
                                on w.ID_Klienta equals k.ID_Klienta
                              where k.ID_Klienta == logowanie_klient.idklient
                              join fi in db.Filmy
                                on w.ID_Filmu equals fi.ID_Filmu
                              select new
                              {
                                  fi.Tytul,
                                  fi.Gatunek,
                                  w.DataWypozyczenia,
                                  w.DataZwtotu
                              };
            this.filmy.ItemsSource = film.ToList();
            this.wypożyczenia.ItemsSource = wypozycznia.ToList();
        }
        private void wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }

        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var film1 = from f in db.Filmy
                        where f.Stan == "Na magazynie"
                        select new
                        {
                            f.ID_Filmu
                        };
            var values = film1.ToArray();
            int id;
            DateTime thisDay = DateTime.Today;
            Random rnd = new Random();
            int kurier = rnd.Next(0, 2);
            var idkurier = from ku in db.Kurier
                           where ku.ID_Kuriera == kurier
                           select new
                           {
                               ku.ID_Kuriera
                           };
            bool czy_dodano = false;
            if (int.TryParse(idfilm.Text, out id))
            {
                foreach (var v in values)
                {
                    if (id == v.ID_Filmu)
                    {
                        czy_dodano = true;
                        Wypozyczenia wypozyczenia = new Wypozyczenia()
                        {
                            ID_Filmu = id,
                            ID_Klienta = logowanie_klient.idklient,
                            ID_Kuriera = kurier,
                            DataWypozyczenia = thisDay
                        };

                        db.Wypozyczenia.Add(wypozyczenia);
                        

                        var user = db.Filmy.Where(u => u.ID_Filmu == id).FirstOrDefault();
                        user.Stan = "W drodze";
                        wyswietlanie();
                        db.SaveChanges();
                    }
                }
                if (!czy_dodano)
                    MessageBox.Show("Nie ma filmu o takim ID na stanie");
            }
            else
            {
                MessageBox.Show("Błędne ID");
            }
        }
    }
}
