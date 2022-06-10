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
    /// Логика взаимодействия для EditSkyscraperPage.xaml
    /// </summary>
    public partial class EditSkyscraperPage : Page
    {
        private Skyscraper currentSkyscraper = new Skyscraper();
        public EditSkyscraperPage(Skyscraper selectedSkyscraper)
        {
            InitializeComponent();
            if (selectedSkyscraper != null)
                currentSkyscraper = selectedSkyscraper;
            DataContext = currentSkyscraper;
            CbDistrict.ItemsSource = ContextManager.GetContext().Districts.ToList();
            CbMaterial.ItemsSource = ContextManager.GetContext().Materials.ToList();
            CbDeveloper.ItemsSource = ContextManager.GetContext().Developers.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentSkyscraper.Name))
                errors.AppendLine("Укажите название ЖК");
            if (string.IsNullOrWhiteSpace(currentSkyscraper.Address))
                errors.AppendLine("Укажите адресс высотного дома");
            if (currentSkyscraper.NumberOfFloors == 0)
                errors.AppendLine("Укажите количество этажей");
            if (currentSkyscraper.NumberOfEntrances == 0)
                errors.AppendLine("Укажите количество подъездов");
            if (currentSkyscraper.NumberOfApartments == 0)
                errors.AppendLine("Укажите количество квартир");
            if (currentSkyscraper.District == null)
                errors.AppendLine("Выберите район");
            if (currentSkyscraper.Material == null)
                errors.AppendLine("Выберите материал");
            if (currentSkyscraper.Developer == null)
                errors.AppendLine("Выберите застройщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentSkyscraper.IdSkyscraper == 0)
                ContextManager.GetContext().Skyscrapers.Add(currentSkyscraper);
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

        private void TbNumberOfFloors_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbNumberOfEntrances_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbNumberOfApartments_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }
    }
}
