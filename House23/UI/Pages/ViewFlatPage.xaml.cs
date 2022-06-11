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
using House23.Logic.Utils.Linq;

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
            var allSkyscrapers = ContextManager.GetContext().Skyscrapers.ToList();
            allSkyscrapers.Insert(0, new Skyscraper
            {
                Name = "Все ЖК"
            });
            CbSkyscraper.ItemsSource = allSkyscrapers;
            CbSkyscraper.SelectedIndex = 0;

            UpdateFlats();
        }
        private void UpdateFlats()
        {
            var currentFlats = ContextManager.GetContext().Flats.ToList();

            if (CbSkyscraper.SelectedIndex > 0)
            {
                //currentFlats = currentFlats.Where(p => p.Skyscrapers.Contains(CbSkyscraper.SelectedItem as Skyscraper)).ToList();
            }

            currentFlats = currentFlats.Where(p => p.BuildingNumberOfRoom.ToString().Contains(TbSearchRoomNumber.Text.ToLower())).ToList();
            currentFlats = currentFlats.Where(p => p.NumberOfRooms.ToString().Contains(TbSearchNumberOfRooms.Text.ToLower())).ToList();
            currentFlats = currentFlats.Where(p =>
                {
                    var textMinPrice = TbSearchMinPrice.Text;
                    var textMaxPrice = TbSearchMaxPrice.Text;
                    var minPrice = 0m;
                    var maxPrice = decimal.MaxValue;
                    if (textMinPrice.Length != 0)
                    {
                        if (decimal.TryParse(TbSearchMinPrice.Text, out decimal minPriceTemp))
                        {
                            minPrice = minPriceTemp;
                        }
                    }
                    if (textMaxPrice.Length != 0)
                    {
                        if (decimal.TryParse(TbSearchMaxPrice.Text, out decimal maxPriceTemp))
                        {
                            maxPrice = maxPriceTemp;
                        }
                    }
                    return p.Price >= minPrice && p.Price <= maxPrice;
                
                } 
             ).ToList();
            currentFlats = currentFlats.Where(p => p.Price.ToString().Contains(TbSearchMaxPrice.Text.ToLower())).ToList();
            currentFlats = currentFlats.Where(p => p.Area.ToString().Contains(TbSearchMinArea.Text.ToLower())).ToList();
            currentFlats = currentFlats.Where(p => p.Area.ToString().Contains(TbSearchMaxArea.Text.ToLower())).ToList();

            LvFlats.ItemsSource = currentFlats.OrderByDescending(p => p.Price).ToList();
            LvFlats.SelectedIndex = 0;
        }

        private void TbSearchNumberOfRooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void TbSearchMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void TbSearchMaxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats(); 
        }

        private void TbSearchMinArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void TbSearchMaxArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void CbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void CbSkyscraper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void TbSearchRoomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFlats();
        }

        private void BtnSelectFlat_Click(object sender, RoutedEventArgs e)
        {
            var currentFlats = ContextManager.GetContext().Flats.ToList();
            var selectedFlat = currentFlats.Where(p => p == LvFlats.SelectedItem).ToList();
        }

        private void BtnSaveListOfFlat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbSearchRoomNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbSearchNumberOfRooms_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbSearchMinPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbSearchMaxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbSearchMinArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbSearchMaxArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }
    }
}
