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
    /// Логика взаимодействия для FlatPage.xaml
    /// </summary>
    public partial class FlatPage : Page
    {
        public FlatPage()
        {
            InitializeComponent();
        }
        private void BtnAddFlat_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditFlatPage(null));
        }

        private void BtnEditFlat_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new EditFlatPage((sender as Button).DataContext as Flat));
        }
        private void BtnDeleteFlat_Click(object sender, RoutedEventArgs e)
        {
            var flatsForRemoving = DdFlat.SelectedItems.Cast<Flat>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {flatsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ContextManager.GetContext().Flats.RemoveRange(flatsForRemoving);
                    ContextManager.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DdFlat.ItemsSource = ContextManager.GetContext().Flats.ToList();
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
                DdFlat.ItemsSource = ContextManager.GetContext().Flats.ToList();
            }
        }


        private string lastText;
        private void UpdateFlat()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchFlat = ContextManager.GetContext().Flats.ToList();
            currentShearchFlat = currentShearchFlat.Where(p => ContainsText(p.BuildingNumberOfRoom.ToString(), TbSearch.Text)).ToList();
            DdFlat.ItemsSource = currentShearchFlat;

            if (flag && currentShearchFlat.Count == 0)
            {
                MessageBox.Show("Кварнтира не найдена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlat();
        }

    }
}
