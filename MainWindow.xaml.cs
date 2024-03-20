using System;
using System.Collections.Generic;
using System.Data;
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
using PRAKTIKA4.DataSet1TableAdapters;

namespace PRAKTIKA4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PassengersTableAdapter passenger = new PassengersTableAdapter();
        
        public MainWindow()
        {
            InitializeComponent();
            PassengerGrid.ItemsSource = passenger.GetData();
            FiltrName.ItemsSource = passenger.GetData();
            FiltrName.DisplayMemberPath = "FirstName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();

            // Закройте текущее окно
            this.Close();
        }

        private void SearchClick_Click(object sender, RoutedEventArgs e)
        {
            PassengerGrid.ItemsSource = passenger.GetName(SearchName.Text);
        }

        private void ClearClick_Click(object sender, RoutedEventArgs e)
        {
            PassengerGrid.ItemsSource = passenger.GetData();
        }

        private void FiltrName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrName.SelectedItem != null)
            {
                var id = (int)(FiltrName.SelectedItem as DataRowView).Row[0];
            }
        }
    }
}
