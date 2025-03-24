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

namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Student student;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnShowInfo_Click(object sender, RoutedEventArgs e)
    {
        string name = txtName.Text;
        int course = int.Parse(txtCourse.Text);
        int grade = int.Parse(txtGrade.Text);

        // Створення студента
        if (cmbStudentType.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content.ToString() == "Аспірант")
        {
            string supervisor = txtSupervisor.Text;
            student = new Aspirant(name, course, grade, supervisor);
        }
        else if (cmbStudentType.SelectedItem is ComboBoxItem selectedContractItem && selectedContractItem.Content.ToString() == "Студент-контрактник")
        {
            bool isPaid = chkPaidContract.IsChecked == true;
            student = new StudentContract(name, course, grade, isPaid);
        }
        else
        {
            student = new Student(name, course, grade);
        }

        txtInfo.Text = student.GetInfo();
    }

    private void btnNextCourse_Click(object sender, RoutedEventArgs e)
    {
        student.NextCourse();
        txtInfo.Text = student.GetInfo();
    }

    private void btnShowScholarship_Click(object sender, RoutedEventArgs e)
    {
        txtInfo.Text = $"Стипендія: {student.Scholarship()} грн";
    }
}

