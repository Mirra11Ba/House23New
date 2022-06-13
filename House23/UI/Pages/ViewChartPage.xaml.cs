using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
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
    /// Логика взаимодействия для ViewChartPage.xaml
    /// </summary>
    public partial class ViewChartPage : Page
    {
        public ViewChartPage()
        {
            InitializeComponent();

            ChartEmployeeClients.ChartAreas.Add(new ChartArea("Main"));

            var currentSeries = new Series("ChartEmployeeClients")
            {
                IsValueShownAsLabel = true
            };
            ChartEmployeeClients.Series.Add(currentSeries);

            CbCharTypes.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
            CbCharTypes.SelectedIndex = 1;
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if (CbCharTypes.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = ChartEmployeeClients.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();
                var employees = ContextManager.GetContext().Employees.ToList();
                foreach (var employee in employees)
                {
                    currentSeries.Points.AddXY(employee.FullName,
                        employee.Clients.Count);
                }
            }
        }
    }
}
