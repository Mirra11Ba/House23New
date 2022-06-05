using House23.Logic.DataBase;
using House23.Logic.Handlers;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using House23.UI.Pages;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

        }

        private void BtnLoginIn_Click(object sender, RoutedEventArgs e)
        {

            if (TbLoginName.Text.Length > 0)
            {
                if (PbPassword.Password.Length > 0)
                {
                    string login = TbLoginName.Text.Trim();
                    string password = PbPassword.Password.Trim();
                    UserAuthorization(login, password);
                }
                else MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void UserAuthorization(string login, string password)
        {
            var emloyee = ContextManager.GetContext().Employees;
            var currentEmployee = emloyee.Where(p => p.Login.Equals(login)).ToList();
            if (currentEmployee.Count == 1)
            {
                if (currentEmployee[0].Password.Equals(password))
                {
                    switch (currentEmployee[0].Role.Name)
                    {
                        case "Риелтор":
                            FrameHandler.MainFrame.Navigate(new MenuRealtorPage());
                            break;
                        case "Кадровик":
                            FrameHandler.MainFrame.Navigate(new MenuHRManagerPage());
                            break;
                    }
                    //история входа
                    var context = ContextManager.GetContext();
                    LoginHistory lh = new LoginHistory
                    {
                        Date = DateTime.Now,
                        Employee = currentEmployee[0]
                    };
                    context.LoginHistories.Add(lh);
                    context.SaveChanges();
                }
                else
                    MessageBox.Show("Некорректный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Некорректный логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для авторизации введите свой логин и пароль." +
              "\nПо вопросам о смене пароля обращайтесь к HR-менеджеру",
              "Подсказка", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void BtnShowPassword_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TbPassword.Text = PbPassword.Password;
            PbPassword.Visibility = Visibility.Hidden;
            TbPassword.Visibility = Visibility.Visible;
        }

        private void BtnShowPassword_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PbPassword.Password = TbPassword.Text;
            PbPassword.Visibility = Visibility.Visible;
            TbPassword.Visibility = Visibility.Hidden;
        }
    }
}
