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

using House23.Logic.Handlers;
using House23.Logic.DataBase;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                House23Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DdClient.ItemsSource = House23Entities.GetContext().Clients.ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
    }
}
