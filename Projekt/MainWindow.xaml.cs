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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logowanie_Click(object sender, RoutedEventArgs e)
        {
            logowanie win = new logowanie();
            this.Close();
            win.Show();
        }

        private void tworzenie_Click(object sender, RoutedEventArgs e)
        {
            tworzeniakonta win = new tworzeniakonta();
            this.Close();
            win.Show();
        }
    }
}
