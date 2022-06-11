using House23.Logic.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using static House23.Logic.Utils.StringUtil;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryViewPage.xaml
    /// </summary>
    public partial class HistoryViewPage : Page
    {
        public HistoryViewPage()
        {
            InitializeComponent();
            (DgLoginHistory.Columns[1] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy H:mm:ss";
            DgLoginHistory.ItemsSource = ContextManager.GetContext().LoginHistories.ToList();


            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(DgLoginHistory.ItemsSource);
            if (cvTasks != null && cvTasks.CanSort == true)
            {
                cvTasks.SortDescriptions.Clear();
                cvTasks.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
            }
            UpdateLoginHistory();
        }

        private string lastText;
        private void UpdateLoginHistory()
        {
            bool flag = lastText == null || lastText.Length < TbSearch.Text.Length;
            lastText = TbSearch.Text;

            var currentShearchRequest = ContextManager.GetContext().LoginHistories.ToList();
            currentShearchRequest = currentShearchRequest.Where(p => ContainsText(p.Employee.FullName.ToString(), TbSearch.Text)).ToList();
            DgLoginHistory.ItemsSource = currentShearchRequest;

            if (flag && currentShearchRequest.Count == 0)
            {
                MessageBox.Show("Сотрудник не найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLoginHistory();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("fjh");
        }
    }
}
