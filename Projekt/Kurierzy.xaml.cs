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
            var wypozyczenia = from w in db.Wypozyczenia
                         select w;
            var klient = from k in db.Klienci
                         select k;
            var filmy = from f in db.Filmy
                        select f;
            foreach(var x in filmy)
            {
                if(x.Stan == "W drodze")
                {
                    foreach(var z in wypozyczenia)
                    {
                        if(x.ID_Filmu == z.ID_Filmu)
                        {
                            foreach(var y in klient)
                            {
                                if(y.ID_Klienta == z.ID_Klienta)
                                {
                                    var ku = z.ID_Kuriera;
                                    var kl = z.ID_Klienta;
                                    var fl = z.ID_Filmu;
                                    var mi = y.Miejscowosc;
                                    var ul = y.Ulica;
                                    var dm = y.NrDomu;
                                    var tel = y.NrTelefonu;
                                    this.kur1.Content = ku;
                                    this.kli1.Content = kl;
                                    this.fil1.Content = fl;
                                    this.mie1.Content = mi;
                                    this.ul1.Content = ul;
                                    this.nrd1.Content = dm;
                                    this.nrt1.Content = tel;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
