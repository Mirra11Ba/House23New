using House23.Logic.DataBase;
using House23.Logic.Handlers;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private void BtnADgClient_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditClientPage(null, RefreshContent));
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditClientPage((sender as Button).DataContext as Client, RefreshContent));
        }
        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var emloyeesForRemoving = DgClient.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {emloyeesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Employees.RemoveRange(emloyeesForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DgClient.ItemsSource = ContextManager.GetContext().Clients.ToList();
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
                DgClient.ItemsSource = EmployeeHandler.EmployeeActive.Clients;
            }
        }

        private string lastText;
        private void UpdateClient()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchClient = EmployeeHandler.EmployeeActive.Clients;
            string[] nameList = TbSearch.Text.Split(' ');

            switch (nameList.Length)
            {
                case 1:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).ToList();
                    DgClient.ItemsSource = currentShearchClient;
                    break;
                case 2:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).
                        Where(p => ContainsText(p.FirstName, nameList[1])).ToList();
                    DgClient.ItemsSource = currentShearchClient;
                    break;
                case 3:
                    currentShearchClient = currentShearchClient.Where(p => ContainsText(p.LastName, nameList[0])).
                        Where(p => ContainsText(p.FirstName, nameList[1])).
                            Where(p => ContainsText(p.Patronymic, nameList[2])).ToList();
                    DgClient.ItemsSource = currentShearchClient;
                    break;
                default:
                    DgClient.ItemsSource = currentShearchClient;
                    break;
            }
            if (flag && currentShearchClient.Count == 0)
            {
                MessageBox.Show("Клиент не найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClient();
        }

        private void RefreshContent()
        {
            UpdateClient();
        }
    }
}
