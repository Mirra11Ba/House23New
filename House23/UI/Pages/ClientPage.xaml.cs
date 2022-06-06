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
using static House23.Logic.Utils.StringUtil;


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
            UpdateClient();
        }
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditClientPage(null));
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditClientPage((sender as Button).DataContext as Client));
        }
        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var emloyeesForRemoving = DdClient.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {emloyeesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Employees.RemoveRange(emloyeesForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DdClient.ItemsSource = ContextManager.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DdClient.ItemsSource = EmployeeHandler.EmployeeActive.Clients;
            }
        }


        private void UpdateClient()
        {
            var currentShearchClient = EmployeeHandler.EmployeeActive.Clients;
            string[] nameList = TbSearch.Text.Split(' ');

            switch (nameList.Length)
            {
                case 1:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).ToList();
                    DdClient.ItemsSource = currentShearchClient;
                    break;
                case 2:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).
                        Where(p => ContainsText(p.FirstName, nameList[1])).ToList();
                    DdClient.ItemsSource = currentShearchClient;
                    break;
                case 3:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).
                        Where(p => ContainsText(p.FirstName, nameList[1])).
                            Where(p => ContainsText(p.Patronymic, nameList[2])).ToList();
                    DdClient.ItemsSource = currentShearchClient;
                    break;
                default:
                    DdClient.ItemsSource = currentShearchClient;
                    break;
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClient();
        }
    }
}
