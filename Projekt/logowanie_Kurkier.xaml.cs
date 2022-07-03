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
    /// Logika interakcji dla klasy logowanie_Kurkier.xaml
    /// </summary>
    public partial class logowanie_Kurkier : Window
    {
        public logowanie_Kurkier()
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

        private void logowanie_Click(object sender, RoutedEventArgs e)
        {
            int idnr = 0;
            if (int.TryParse(idlog.Text, out idnr))
            {
                Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
                var password = from Kurier in db.Kurier
                               select Kurier;
                foreach (var pw in password)
                {
                    if (pw.ID_Kuriera == idnr)
                    {
                        if (pw.Hasło == haslolog.Password.ToString())
                        {
                            Kurierzy kurierzy = new Kurierzy();
                            this.Close();
                            kurierzy.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("bledne dane");
            }
        }
    }

}
