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
    /// Logika interakcji dla klasy tworzeniakonta.xaml
    /// </summary>
    public partial class tworzeniakonta : Window
    {
        public tworzeniakonta()
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

        private void dodawanikonta_Click(object sender, RoutedEventArgs e)
        {
            int nrdomu = 0;
            if (Imietxt.Text == "" || Nazwiskotxt.Text == "" || Miejscowosctxt.Text == "" || Ulicatxt.Text == "" || NrDomunr.Text == "" || NrTelefonutxt.Text == "" || Emailtxt.Text == "" || Hasłotxt.Password.ToString() == "")
            {
                wynik.Content = "Brak potrzebnych danych";
            }
            else
            {
                if (int.TryParse(NrDomunr.Text, out nrdomu))
                {
                    Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();

                    Klienci klienci = new Klienci()
                    {
                        Imie = Imietxt.Text,
                        Nazwisko = Nazwiskotxt.Text,
                        Miejscowosc = Miejscowosctxt.Text,
                        Ulica = Ulicatxt.Text,
                        NrDomu = nrdomu,
                        NrTelefonu = NrTelefonutxt.Text,
                        Email = Emailtxt.Text,
                        Hasło = Hasłotxt.Password.ToString()
                    };
                    db.Klienci.Add(klienci);
                    db.SaveChanges();

                    MessageBox.Show("Konto zostało utworzone");
                    MainWindow win = new MainWindow();
                    win.Show();
                    this.Close();
                }
                else
                {
                    wynik.Content = "Błedne dane";
                }
            }               
            
        }
    }
}
