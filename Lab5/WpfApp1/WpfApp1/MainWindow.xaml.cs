using System.IO;
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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Country country;
    public MainWindow()
    {
        InitializeComponent();
        country = new Country();
    }
    private void SaveData_Click(object sender, RoutedEventArgs e)
    {
        country.Name = txtName.Text;
        country.Capital = txtCapital.Text;
        country.Population = int.Parse(txtPopulation.Text);
        country.Area = double.Parse(txtArea.Text);
        country.OfficialLanguage = txtLanguage.Text;
        country.Currency = txtCurrency.Text;
        country.Continent = txtContinent.Text;

        File.WriteAllText("country.txt", country.ToString());
        MessageBox.Show("Дані збережено у файл country.txt", "Збереження", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    private void ShowInfo_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(country.GetCountryInfo(), "Інформація про країну", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void EstimateDensity_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"Густота населення: {country.CalculatePopulationDensity():F2} осіб/км²", "Розрахунок густоти", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}