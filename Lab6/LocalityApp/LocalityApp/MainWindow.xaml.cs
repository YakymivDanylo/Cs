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

namespace LocalityApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<ILocality> localities = new List<ILocality>();
    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }
    private void LoadData()
    {
        localities.Add(new Village("Малинівка", 500, 10));
        localities.Add(new City("Київ", 2800000, 839, true));
        localities.Add(new City("Львів", 720000, 182, false));

        UpdateList();
    }

    private void UpdateList()
    {
        listBoxItems.Items.Clear();
        foreach (var locality in localities)
        {
            if (locality is Village village)
                listBoxItems.Items.Add(village.GetVillageInfo());
            else if (locality is City city)
                listBoxItems.Items.Add(city.GetCityInfo());
        }
    }
}