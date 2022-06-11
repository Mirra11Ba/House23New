using House23.Logic.DataBase;
using House23.Logic.Handlers;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static House23.Logic.Utils.StringUtil;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditFlatPage.xaml
    /// </summary>
    public partial class EditFlatPage : Page
    {
        private Flat currentFlat = new Flat(); // создание объекта класса
        public EditFlatPage(Flat selectedFlat)
        {
            InitializeComponent();
            if (selectedFlat != null)
                currentFlat = selectedFlat;
            DataContext = currentFlat;
            CbSkyscraper.ItemsSource = ContextManager.GetContext().Skyscrapers.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (currentFlat.BuildingNumberOfRoom == 0)
                errors.AppendLine("Укажите строительный № квартиры");
            if (currentFlat.Price == 0)
                errors.AppendLine("Укажите цену");
            if (currentFlat.NumberOfRooms == 0)
                errors.AppendLine("Укажите количество комант");
            if (currentFlat.Area == 0)
                errors.AppendLine("Укажите площадь");
            if (currentFlat.FloorNumber == 0)
                errors.AppendLine("Укажите этаж");
            if (currentFlat.EntranceNumber == 0)
                errors.AppendLine("Укажите подъезд");
            if (currentFlat.Skyscraper == null)
                errors.AppendLine("Выберите высотное здание");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentFlat.IdFlat == 0)
                ContextManager.GetContext().Flats.Add(currentFlat);
            try
            {
                ContextManager.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameHandler.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                currentFlat.ImagePreview = File.ReadAllBytes(dialog.FileName);

                ImDynamicFlat.Source = LoadImage(currentFlat.ImagePreview);
                MessageBox.Show("Картинка добавлена");
            }
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void TbBuildingNumberOfRoom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbNumberOfRooms_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbFloorNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbEntranceNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        //додклать
        private bool isFocused = false;
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            isFocused = true;
        }
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isFocused)
            {
                isFocused = false;
                (sender as TextBox).SelectAll();
            }
        }
    }
}
