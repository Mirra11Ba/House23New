using House23.Logic.DataBase;
using House23.Logic.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static House23.Logic.Utils.StringUtil;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditRequestPage.xaml
    /// </summary>
    public partial class EditRequestPage : Page
    {

        private Request currentRequest = new Request();
        public EditRequestPage(Request selectedRequest)
        {
            InitializeComponent();
            if (selectedRequest != null)
            {
                currentRequest = selectedRequest;
                DpDateOfRequest.SelectedDate = selectedRequest.RequestDate;
            }
            else
            {
             DpDateOfRequest.SelectedDate = DateTime.Now;

            }            

            DataContext = currentRequest;
            var clients = ContextManager.GetContext().Clients.ToList();
            var clientsFil = new List<Client>();
            foreach (var item in clients)
            {
                var clientAttach = ContextManager.GetContext().Clients.Attach(item);
                Employee[] employeesArray = clientAttach.Employees.ToArray();
                if (employeesArray.Length == 1 && employeesArray[0].IdEmployee == (EmployeeHandler.EmployeeActive.IdEmployee))
                {
                    clientsFil.Add(clientAttach);
                }
            }

            CbClient.ItemsSource = clientsFil;
            if (selectedRequest != null)
            {
                CbClient.SelectedItem = selectedRequest.Client;
            }
            else
                CbClient.SelectedIndex = 0;
            CbDistrict.ItemsSource = ContextManager.GetContext().Districts.ToList();
            CbRequestStatus.ItemsSource = ContextManager.GetContext().RequestStatus.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (currentRequest.Client == null)
                errors.AppendLine("Выберите клиента");
            if (currentRequest.MaximumPrice == 0)
                errors.AppendLine("Укажите max стоимость квартиры");
            if (currentRequest.NumberOfRooms == 0)
                errors.AppendLine("Укажите количество комнат");
            if (currentRequest.MinimumArea == 0)
                errors.AppendLine("Укажите min площадь");
            if (DpDateOfRequest.SelectedDate == null)
                errors.AppendLine("Укажите дату заявки");
            if (currentRequest.District == null)
                errors.AppendLine("Укажите район");
            if (currentRequest.District == null)
                errors.AppendLine("Укажите подъезд");
            if (currentRequest.RequestStatu == null)
                errors.AppendLine("Выберите статус заявки");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            currentRequest.RequestDate = DpDateOfRequest.SelectedDate.Value;

            if (currentRequest.IdRequest == 0)
            {
                currentRequest.Employee = ContextManager.GetContext().Employees.Attach(EmployeeHandler.EmployeeActive);
                ContextManager.GetContext().Requests.Add(currentRequest);
            }
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

        private void CbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentRequest.Client = (Client)CbClient.SelectedItem;
        }

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
