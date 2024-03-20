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
using System.Windows.Shapes;
using PRAKTIKA4.DataSet1TableAdapters;

namespace PRAKTIKA4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        TicketsTableAdapter ticket = new TicketsTableAdapter();
        public Window1()
        {
            InitializeComponent();
            TicketGrid.ItemsSource = ticket.GetData();
            FiltrClass.ItemsSource = ticket.GetData();
            FiltrClass.DisplayMemberPath = "Class";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            
            this.Close();
        }

        private void SearchClick_Click(object sender, RoutedEventArgs e)
        {
            TicketGrid.ItemsSource = ticket.GetClass(SearchClass.Text);
        }

        private void ClearClick_Click(object sender, RoutedEventArgs e)
        {
            TicketGrid.ItemsSource =ticket.GetData();
        }

        private void FiltrClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrClass.SelectedItem != null)
            {
                var id = (int)(FiltrClass.SelectedItem as DataRowView).Row[0];
                TicketGrid.ItemsSource = ticket.FiltrClass(id.ToString());
            }
        }
    }
}
