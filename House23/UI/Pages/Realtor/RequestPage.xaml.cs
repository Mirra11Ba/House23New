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
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnEditRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ContextManager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DdRequest.ItemsSource = ContextManager.GetContext().Requests.ToList();
            }
        }
    }
}
