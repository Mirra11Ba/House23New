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
            MessageBox.Show("В разработке");
        }
        private void BtnEditSkyscraper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
        private void BtnDeleteSkyscraper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ContextManager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DdSkyscraper.ItemsSource = ContextManager.GetContext().Skyscrapers.ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

    }
}
