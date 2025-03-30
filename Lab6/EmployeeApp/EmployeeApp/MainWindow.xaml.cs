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

namespace EmployeeApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private EmployeeCollection employees = new EmployeeCollection();

    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        employees.Add(new Employee("Олександр", 45, 20));
        employees.Add(new Employee("Марія", 32, 10));
        employees.Add(new Employee("Іван", 28, 5));
        employees.Add(new Employee("Наталія", 50, 25));

        // Сортуємо за стажем
        List<Employee> sortedEmployees = new List<Employee>(employees);
        sortedEmployees.Sort(new EmployeeComparer());

        UpdateList(sortedEmployees);
    }

    private void UpdateList(IEnumerable<Employee> sortedEmployees)
    {
        listBoxEmployees.Items.Clear();
        foreach (var employee in sortedEmployees)
        {
            listBoxEmployees.Items.Add(employee);
        }
    }
}