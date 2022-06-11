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
    /// Логика взаимодействия для MenuHRManagerPage.xaml
    /// </summary>
    public partial class MenuHRManagerPage : Page
    {
        public MenuHRManagerPage()
        {
            InitializeComponent();
            FrameHandler.HRManagerContentFrame = HRManagerContentFrame;
            HRManagerContentFrame.Navigate(new RealtorPage()); 
        }
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.HRManagerContentFrame.Navigate(new RealtorPage());
        }
        private void BtnHistoryView_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.HRManagerContentFrame.Navigate(new HistoryViewPage());
        }

        private void BtnChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new AuthorizationPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
