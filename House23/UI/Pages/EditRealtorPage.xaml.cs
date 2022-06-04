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
using System.Text.RegularExpressions;

using House23.Logic.Handlers;
using House23.Logic.DataBase;
using House23.Logic.Utils;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditRealtorPage.xaml
    /// </summary>
    public partial class EditRealtorPage : Page
    {
        private Employee currentEmployee = new Employee(); // создание объекта класса
        public EditRealtorPage(Employee selectedEmployee)//передача экземпляра выбранного сотрудника
        {
            InitializeComponent();
            if (selectedEmployee != null)
                currentEmployee = selectedEmployee;
            DataContext = currentEmployee;
            CbRole.ItemsSource = ContextManager.GetContext().Roles.ToList();
        }
        private void BtnGeneratePasswd_Click(object sender, RoutedEventArgs e)
        {
            GetPass();
            string generatePass = GetPass();
            tbPass.Text = generatePass;
            tbPass.Focus();
        }
        private static string GetPass()
        {
            int passLenth = 10;
            string generatePass = "";
            var r = new Random();
            while (generatePass.Length < passLenth)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    generatePass += c;
            }
            return generatePass;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentEmployee.FirstName))
                errors.AppendLine("Укажите имя сотрудника");
            if (string.IsNullOrWhiteSpace(currentEmployee.LastName))
                errors.AppendLine("Укажите фамилию сотрудника");
            if (string.IsNullOrWhiteSpace(currentEmployee.Phone))
                errors.AppendLine("Укажите телефон");
            if (string.IsNullOrWhiteSpace(currentEmployee.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(currentEmployee.Password))
                errors.AppendLine("Укажите пароль");
            if (currentEmployee.Role == null)
                errors.AppendLine("Выберите роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentEmployee.IdEmployee == 0)
                ContextManager.GetContext().Employees.Add(currentEmployee);
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

        private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            string pattern = "^[0-9]*$";
            Regex regexNumber = new Regex(pattern);

            if (!regexNumber.IsMatch(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Можно вводить только 11 цифр в формате\n7XXXXXXXXXX\n8XXXXXXXXXX", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
