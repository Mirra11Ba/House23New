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

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditDeveloperPage.xaml
    /// </summary>
    public partial class EditDeveloperPage : Page
    {
        private Developer currentDeveloper = new Developer(); // создание объекта класса
        public EditDeveloperPage(Developer selectedDeveloper)//передача экземпляра выбранного застройщика
        {
            InitializeComponent();
            if (selectedDeveloper != null)
                currentDeveloper = selectedDeveloper;
            DataContext = currentDeveloper;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentDeveloper.Name))
                errors.AppendLine("Укажите название застройщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentDeveloper.IdDeveloper == 0)
                House23Entities.GetContext().Developers.Add(currentDeveloper);
            try
            {
                House23Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameHandler.MainFrame.GoBack(); //мб hrmanager
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
