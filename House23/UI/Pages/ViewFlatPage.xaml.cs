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
        private bool constructorFinal = false;

        public ViewFlatPage()
        {
            InitializeComponent();
            try
            {
                var allDistricts = ContextManager.GetContext().Districts.ToList();
                var allSkyscrapers = ContextManager.GetContext().Skyscrapers.ToList();
                
                allDistricts.Insert(0, new District
                {
                    Name = "Все Районы"
                });
                allSkyscrapers.Insert(0, new Skyscraper
                {
                    Name = "Все ЖК"
                });

                CbDistrict.ItemsSource = allDistricts;
                CbSkyscraper.ItemsSource = allSkyscrapers;

                CbDistrict.SelectedIndex = 0;
                CbSkyscraper.SelectedIndex = 0;
                constructorFinal = true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }

            UpdateFlats();
        }
        private void UpdateFlats()
        {
            if (!constructorFinal)
            {
                return;
            }
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

            currentFlats = currentFlats.Where(p =>
                {
                    var textMinArea = TbSearchMinArea.Text;
                    var textMaxArea = TbSearchMaxArea.Text;
                    var minArea = 0m;
                    var maxArea = decimal.MaxValue;
                    if (textMinArea.Length != 0)
                    {
                        if (decimal.TryParse(TbSearchMinArea.Text, out decimal minAreaTemp))
                        {
                            minArea = minAreaTemp;
                        }
                    }
                    if (textMaxArea.Length != 0)
                    {
                        if (decimal.TryParse(TbSearchMaxArea.Text, out decimal maxAreaTemp))
                        {
                            maxArea = maxAreaTemp;
                        }
                    }

                    return p.Area >= minArea && p.Area <= maxArea;

                }
            ).ToList();

            currentFlats = currentFlats.Where(p =>
            {
                var skyscraper = CbSkyscraper.SelectedItem as Skyscraper;
                if (skyscraper.Name == "Все ЖК") return true;
                return p.Skyscraper.IdSkyscraper == skyscraper.IdSkyscraper;
            }).ToList();

            currentFlats = currentFlats.Where(p =>
            {
                var district = CbDistrict.SelectedItem as District;
                if (district.Name == "Все Районы") return true;
                return p.Skyscraper.District.IdDistrict == district.IdDistrict;
            }).ToList();

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
