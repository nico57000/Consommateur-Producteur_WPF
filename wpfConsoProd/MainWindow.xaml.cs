using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace wpfConsoProd
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Producteur> ListeProd;
        public ObservableCollection<Consommateur> ListeConso;
        public MainWindow()
        {
            InitializeComponent();
            ListeProd = new ObservableCollection<Producteur>();
            ListeConso = new ObservableCollection<Consommateur>();
            ListeViewProd.ItemsSource = ListeProd;
            ListeViewConso.ItemsSource = ListeConso;
            
        }

        private void AddProd_Click(object sender, RoutedEventArgs e)
        {
            Producteur p = new Producteur(nomProd.Text, this);
            ListeProd.Add(p);
            p.workerProd.RunWorkerAsync();
        }

        private void PauseProd_Click(object sender, RoutedEventArgs e)
        {
            ((Producteur)ListeViewProd.SelectedItems[0]).pause = true;
        }

        private void Addconso_Click(object sender, RoutedEventArgs e)
        {
            Consommateur c = new Consommateur(nomConso.Text,this);
            ListeConso.Add(c);
            c.workerConso.RunWorkerAsync();
        }

        private void PauseConso_Click(object sender, RoutedEventArgs e)
        {
            ((Consommateur)ListeViewConso.SelectedItems[0]).pause = true;
        }
    }
}
