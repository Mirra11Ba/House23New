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

//using House23.UI.Views;
using House23.Logic.Handlers;
using House23.Logic.DataBase;

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для RealtorPage.xaml
    /// </summary>
    public partial class RealtorPage : Page
    {
        public RealtorPage()
        {
            InitializeComponent();
            UpdateEmloyee();
        }

        private void BtnAddRealtor_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.HRManagerContentFrame.Navigate(new EditRealtorPage(null));
        }

        private void BtnEditRealtor_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.HRManagerContentFrame.Navigate(new EditRealtorPage((sender as Button).DataContext as Employee));
        }

        private void BtnDeleteRealtor_Click(object sender, RoutedEventArgs e)
        {
            var emloyeesForRemoving = DdEmployee.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {emloyeesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    House23Entities.GetContext().Employees.RemoveRange(emloyeesForRemoving);
                    House23Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DdEmployee.ItemsSource = House23Entities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                House23Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DdEmployee.ItemsSource = House23Entities.GetContext().Employees.ToList();
            }
        }
        //метод для мгновенного обновления списка сотрудников в соответсвии с поиском в tb
        private void UpdateEmloyee()
        {
            var currentShearchEmployee = House23Entities.GetContext().Employees.ToList();
            string[] nameList = TbSearch.Text.Split(' ');

            switch (nameList.Length)
            {
                case 1:
                    currentShearchEmployee = currentShearchEmployee.Where(p => p.LastName.Contains(nameList[0])).ToList();
                    DdEmployee.ItemsSource = currentShearchEmployee;
                    break;
                case 2:
                    currentShearchEmployee = currentShearchEmployee.
                        Where(p => p.LastName.Contains(nameList[0])).
                            Where(p => p.FirstName.Contains(nameList[1])).ToList();
                    DdEmployee.ItemsSource = currentShearchEmployee;
                    break;
                case 3:
                    currentShearchEmployee = currentShearchEmployee.
                        Where(p => p.LastName.Contains(nameList[0])).
                            Where(p => p.FirstName.Contains(nameList[1])).
                                Where(p => p.Patronymic.Contains(nameList[2])).ToList();
                    DdEmployee.ItemsSource = currentShearchEmployee;
                    break;
                default:
                    DdEmployee.ItemsSource = currentShearchEmployee;
                    break;
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEmloyee();
        }
    }
}
