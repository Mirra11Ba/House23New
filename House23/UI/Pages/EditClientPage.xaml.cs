﻿using System;
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
using static House23.Logic.Handlers.EmployeeHandler;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        private Client currentClient = new Client(); // создание объекта класса
        public EditClientPage(Client selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
                currentClient = selectedClient;
            DataContext = currentClient;
          
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentClient.LastName))
                errors.AppendLine("Укажите фамилию клиента");
            if (string.IsNullOrWhiteSpace(currentClient.FirstName))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrWhiteSpace(currentClient.Phone))
                errors.AppendLine("Укажите телефон");
            
            if (true)
            {
                MessageBox.Show("Телефон не может быть меньше 11 цифр","Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentClient.IdClient == 0)
            {
                ContextManager.GetContext().Clients.Add(currentClient);
                //ContextManager.GetContext().Employees.Add(EmployeeActive);
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

        private void TbLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsLetter(e);
        }

        private void TbFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsLetter(e);
        }

        private void TbPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsLetter(e);
        }
        private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string messageText = "Можно вводить только 11 цифр в формате\n7XXXXXXXXXX\n8XXXXXXXXXX";
            string messageTitle = "Внимание";
            CheckIsNumeric(e, messageText, messageTitle);
        }
    }
}
