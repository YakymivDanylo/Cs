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

namespace OSQuizApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Dictionary<string, Tuple<string, int>> operatingSystems = new Dictionary<string, Tuple<string, int>>()
        {
            {"windows", Tuple.Create("Microsoft", 1985)},
            {"linux", Tuple.Create("Linus Benedict Torvalds", 1991)},
            {"macos", Tuple.Create("Apple", 1984)},
            {"android", Tuple.Create("Open Handset Alliance & Google", 2008)},
            {"ios", Tuple.Create("Apple Inc.", 2007)}
        };

        public MainWindow()
        {
            InitializeComponent();
            InputTextBox.Focus();
            OutputTextBlock.Text = "Введіть назву операційної системи або '0' для виходу.";
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputTextBox.Text.Trim().ToLower(); // Отримуємо введений текст, видаляємо пробіли та переводимо до нижнього регістру

            if (userInput == "0")
            {
                Application.Current.Shutdown();
                return;
            }

            // Перевіряємо, чи введена ОС є в нашому словнику (ключі вже в нижньому регістрі)
            if (operatingSystems.ContainsKey(userInput))
            {
                Tuple<string, int> osInfo = operatingSystems[userInput];
                // Виводимо назву ОС з правильним регістром (перша літера велика)
                string displayedOSName = operatingSystems.First(x => x.Key == userInput).Key.First().ToString().ToUpper() + operatingSystems.First(x => x.Key == userInput).Key.Substring(1);
                OutputTextBlock.Text = $"Операційна система: {displayedOSName}\nРозробник: {osInfo.Item1}\nПерший рік випуску: {osInfo.Item2}\n\nВведіть іншу назву ОС або '0' для виходу.";
            }
            else
            {
                OutputTextBlock.Text = $"Операційна система '{InputTextBox.Text.Trim()}' не знайдена.\nБудь ласка, введіть існуючу назву ОС або '0' для виходу.";
            }

            InputTextBox.Clear();
            InputTextBox.Focus();
        }
}