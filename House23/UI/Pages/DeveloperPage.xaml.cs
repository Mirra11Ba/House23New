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
    /// Логика взаимодействия для DeveloperPage.xaml
    /// </summary>
    public partial class DeveloperPage : Page
    {
        public DeveloperPage()
        {
            InitializeComponent();
            UpdateDeveloper();
        }
        private void BtnADgDeveloper_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.RealtorContentFrame.Navigate(new EditDeveloperPage(null));
        }

        private void BtnEditDeveloper_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.RealtorContentFrame.Navigate(new EditDeveloperPage((sender as Button).DataContext as Developer));
        }

        private void BtnDeleteDeveloper_Click(object sender, RoutedEventArgs e)
        {
            var developersForRemoving = DgDeveloper.SelectedItems.Cast<Developer>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {developersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Developers.RemoveRange(developersForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DgDeveloper.ItemsSource = ContextManager.GetContext().Developers.ToList();
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
                ContextManager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgDeveloper.ItemsSource = ContextManager.GetContext().Developers.ToList();
            }
        }


        private string lastText;
        private void UpdateDeveloper()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchDeveloper = ContextManager.GetContext().Developers.ToList();
            currentShearchDeveloper = currentShearchDeveloper.Where(p => ContainsText(p.Name, TbSearch.Text)).ToList();
            DgDeveloper.ItemsSource = currentShearchDeveloper;

            if (flag && currentShearchDeveloper.Count == 0)
            {
                MessageBox.Show("Застройщик не найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDeveloper();
        }

    }
}
