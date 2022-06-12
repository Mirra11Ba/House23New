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
    /// Логика взаимодействия для SkyscraperPage.xaml
    /// </summary>
    public partial class SkyscraperPage : Page
    {
        public SkyscraperPage()
        {
            InitializeComponent();
        }
        private void BtnAddSkyscraper_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditSkyscraperPage(null));
        }
        private void BtnEditSkyscraper_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditSkyscraperPage((sender as Button).DataContext as Skyscraper));
        }
        private void BtnDeleteSkyscraper_Click(object sender, RoutedEventArgs e)
        {
            var skyscraperForRemoving = DgSkyscraper.SelectedItems.Cast<Skyscraper>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {skyscraperForRemoving.Count()} элементов?\n\nЕсли вы удалите высотный дом, все квартиры, котрые с ним связаны будут также удалены.", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Skyscrapers.RemoveRange(skyscraperForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DgSkyscraper.ItemsSource = ContextManager.GetContext().Skyscrapers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private string lastText;
        private void UpdateSkyscraper()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchSkyscraper = ContextManager.GetContext().Skyscrapers.ToList();
            currentShearchSkyscraper = currentShearchSkyscraper.Where(p => ContainsText(p.Name.ToString(), TbSearch.Text)).ToList();
            DgSkyscraper.ItemsSource = currentShearchSkyscraper;

            if (flag && currentShearchSkyscraper.Count == 0)
            {
                MessageBox.Show("Высотный дом не найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSkyscraper();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ContextManager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgSkyscraper.ItemsSource = ContextManager.GetContext().Skyscrapers.ToList();
            }
        }



    }
}
