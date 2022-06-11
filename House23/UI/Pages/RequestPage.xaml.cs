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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage()
        {
            InitializeComponent();
            (DgRequest.Columns[6] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
            UpdateRequest();
        }
        private void BtnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditRequestPage(null));
        }
        private void BtnEditRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditRequestPage((sender as Button).DataContext as Request));
        }
        private void BtnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            var requestsForRemoving = DgRequest.SelectedItems.Cast<Flat>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {requestsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Flats.RemoveRange(requestsForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DgRequest.ItemsSource = ContextManager.GetContext().Requests.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRequest();
        }

        private string lastText;
        private void UpdateRequest()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchRequest = ContextManager.GetContext().Requests.ToList();
            currentShearchRequest = currentShearchRequest.Where(p => ContainsText(p.Client.FullName.ToString(), TbSearch.Text)).ToList();
            DgRequest.ItemsSource = currentShearchRequest;

            if (flag && currentShearchRequest.Count == 0)
            {
                MessageBox.Show("Клиент не найдена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }


        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ContextManager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgRequest.ItemsSource = ContextManager.GetContext().Requests.ToList();
            }
        }
    }
}
