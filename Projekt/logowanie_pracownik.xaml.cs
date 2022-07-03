﻿using System;
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
    /// Logika interakcji dla klasy logowanie_pracownik.xaml
    /// </summary>
    public partial class logowanie_pracownik : Window
    {
        public logowanie_pracownik()
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
            Wypozyczalnia_filmowEntities1 db = new Wypozyczalnia_filmowEntities1();
            var password = from Pracownicy in db.Pracownicy
                           select Pracownicy;
            foreach(var pw in password)
            {
                if(pw.Email == emaillog.Text)
                {
                    if(pw.Hasło == haslolog.Password.ToString())
                        MessageBox.Show("zalogowany");
                }
            }
        }
    }

}
