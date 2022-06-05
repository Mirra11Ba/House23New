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
    /// Логика взаимодействия для ViewFlatPage.xaml
    /// </summary>
    public partial class ViewFlatPage : Page
    {
        public ViewFlatPage()
        {
            InitializeComponent();
        }

        private void TbSearchNumberOfRooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchMaxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchMinArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchMaxArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void CbxDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void CbxSkyscraper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchRoomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void BtnSelectFlat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void BtnSaveListOfFlat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }
    }
}
