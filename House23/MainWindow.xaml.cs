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

using House23.UI.Pages;
using House23.Logic.Handlers;
using House23.Logic.DataBase;


namespace House23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthorizationPage());
            FrameHandler.MainFrame = MainFrame;
        }
        /// <summary>
        /// Метод очистки журнала переходов для MainFrame
        /// </summary>
        private void RefreshHistory()
        {
            if (!MainFrame.CanGoBack && !MainFrame.CanGoForward)
            {
                return;
            }

            var entry = MainFrame.RemoveBackEntry();
            while (entry != null)
            {
                entry = MainFrame.RemoveBackEntry();
            }

        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.Content is AuthorizationPage)
            {

                RefreshHistory();
            }
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.GoBack();
        }
    }
}
