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
    /// Логика взаимодействия для EditRequestPage.xaml
    /// </summary>
    public partial class EditRequestPage : Page
    {
        public EditRequestPage()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("в разработке");
        }

        private void TbMinimumPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbMaximumPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TbMinimumArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void TbMaximumArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только цифры";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }

        private void CbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedEmployee = CbEmployee.SelectedItem as ContextManager.GetContext().Employee;
        }
    }
}
