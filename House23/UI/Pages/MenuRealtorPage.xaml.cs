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

namespace House23.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuRealtorPage.xaml
    /// </summary>
    public partial class MenuRealtorPage : Page
    {
        public MenuRealtorPage()
        {
            InitializeComponent();
            FrameHandler.RealtorContentFrame = RealtorContentFrame;
            RealtorContentFrame.Navigate(new DeveloperPage());
        }

        private void BtnChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.MainFrame.Navigate(new AuthorizationPage());
        }

        private void BtnDevelopers_Click(object sender, RoutedEventArgs e)
        {
            FrameHandler.RealtorContentFrame.Navigate(new DeveloperPage());
        }
    }
}
