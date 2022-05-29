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
using System.Windows.Shapes;

namespace House23.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для EditRealtorWindow.xaml
    /// </summary>
    public partial class EditRealtorWindow : Window
    {
        public EditRealtorWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("бла");
        }
    }
}
