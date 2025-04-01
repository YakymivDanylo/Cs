using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PostalRoutesApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
   private List<Route> routes = new List<Route>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRouteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int routeNumber = int.Parse(RouteNumberTextBox.Text);
                string destination = DestinationTextBox.Text;
                TimeSpan departureTime = TimeSpan.Parse(DepartureTextBox.Text);
                TimeSpan arrivalTime = TimeSpan.Parse(ArrivalTextBox.Text);
                int exchangeDuration = int.Parse(ExchangeDurationTextBox.Text);

                routes.Add(new Route(routeNumber, destination, departureTime, arrivalTime, exchangeDuration));
                MessageBox.Show("Маршрут додано успішно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення даних: " + ex.Message);
            }
        }

        private void ShowRoutesButton_Click(object sender, RoutedEventArgs e)
        {
            var result = "Маршрути:\n";
            foreach (var route in routes)
            {
                int travelTime = (int)(route.ArrivalTime - route.DepartureTime).TotalMinutes;
                result += $"№{route.RouteNumber} - {route.Destination}, Час у дорозі: {travelTime} хв.\n";
            }
            MessageBox.Show(result);
        }

        private void FilterRoutesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan startTime = TimeSpan.Parse(StartTimeTextBox.Text);
                TimeSpan endTime = TimeSpan.Parse(EndTimeTextBox.Text);
                var filteredRoutes = routes.Where(r => r.DepartureTime >= startTime && r.DepartureTime <= endTime && r.ExchangeDuration <= 10).ToList();
                
                var result = "Відібрані маршрути:\n";
                foreach (var route in filteredRoutes)
                {
                    result += $"№{route.RouteNumber} - {route.Destination}, Час виїзду: {route.DepartureTime}\n";
                }
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення даних: " + ex.Message);
            }
        }

        private void CountAfternoonArrivalsButton_Click(object sender, RoutedEventArgs e)
        {
            var afternoonRoutes = routes.Where(r => r.ArrivalTime >= new TimeSpan(12, 0, 0)).ToList();
            var result = $"Кількість маршрутів після 12:00: {afternoonRoutes.Count}\n";
            foreach (var route in afternoonRoutes)
            {
                result += $"№{route.RouteNumber} - {route.Destination}, Час прибуття: {route.ArrivalTime}\n";
            }
            MessageBox.Show(result);
        }

        private void LongestRouteButton_Click(object sender, RoutedEventArgs e)
        {
            var longestRoute = routes.OrderByDescending(r => (r.ArrivalTime - r.DepartureTime).TotalMinutes).FirstOrDefault();
            if (longestRoute != null)
            {
                int travelTime = (int)(longestRoute.ArrivalTime - longestRoute.DepartureTime).TotalMinutes;
                MessageBox.Show($"Найдовший маршрут: №{longestRoute.RouteNumber} - {longestRoute.Destination}, Час у дорозі: {travelTime} хв.");
            }
        }
    }

    public class Route
    {
        public int RouteNumber { get; set; }
        public string Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int ExchangeDuration { get; set; }

        public Route(int routeNumber, string destination, TimeSpan departureTime, TimeSpan arrivalTime, int exchangeDuration)
        {
            RouteNumber = routeNumber;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            ExchangeDuration = exchangeDuration;
        }
}