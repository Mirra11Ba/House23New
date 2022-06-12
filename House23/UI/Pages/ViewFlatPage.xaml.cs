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
using House23.Logic.Utils;
using System.IO;
using CsvHelper;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewFlatPage.xaml
    /// </summary>
    public partial class ViewFlatPage : Page
    {
        private bool constructorFinal = false;
        private List<Flat> flats;

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

            flats = currentFlats;
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

        private void BtnSaveListOfFlat_Click(object sender, RoutedEventArgs e)
        {
            var flatConverts = new List<FlatConvert>();

            foreach (var flat in flats)
            {
                flatConverts.Add(new FlatConvert(flat));
            }

            try
            {
                //csv
                using (var writer = new StreamWriter("Подбор квартир.csv", false, Encoding.GetEncoding(1251)))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(flatConverts);
                }

                //pdf
                Document doc = new Document();

                PdfWriter.GetInstance(doc, new FileStream("Подбор квартир.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H,
                    BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);


                string[] headers = new[]
                {
                   "Цена", "Количество комнат", "Площадь", "Этаж", "Подъезд", "Здание"
                };
                var columnsCount = headers.Length;
                PdfPTable table = new PdfPTable(columnsCount);
                var cell = new PdfPCell(new Phrase("ABC анализ", font))
                {
                    Colspan = columnsCount,
                    HorizontalAlignment = 1,
                    Border = 0
                };
                table.AddCell(cell);


                for (int j = 0; j < columnsCount; j++)
                {
                    cell = new PdfPCell(new Phrase(headers[j], font))
                    {
                        NoWrap = false,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    };
                    table.AddCell(cell);
                }

                foreach (var flat in flatConverts)
                {
                    table.AddCell(new Phrase(flat.Price.ToString("#.##"), font));
                    table.AddCell(new Phrase(flat.NumberOfRooms.ToString("#.##"), font));
                    table.AddCell(new Phrase(flat.Area.ToString("#.##"), font));
                    table.AddCell(new Phrase(flat.FloorNumber.ToString("#.##"), font));
                    table.AddCell(new Phrase(flat.EntranceNumber.ToString("#.##"), font));
                    table.AddCell(new Phrase(flat.SkyscraperName, font));
                }

                doc.Add(table);
                doc.Close();
                MessageBox.Show("Файлы сохранены в формате pdf и csv\nОни находятся в папке с .exe", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Есть шанс что выгруженные файлы открыты, но я точно не знаю", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
