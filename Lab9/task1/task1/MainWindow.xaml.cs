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
using Microsoft.Win32;

namespace task1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
     private List<int> originalList = new List<int>();
        private List<int> processedList = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    originalList = fileContent.Split(new char[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToList();
                    lbOriginalList.ItemsSource = originalList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при читанні файлу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnProcessList_Click(object sender, RoutedEventArgs e)
        {
            if (originalList.Count == 0)
            {
                MessageBox.Show("Будь ласка, спочатку оберіть файл зі списком.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtE1.Text, out int e1))
            {
                MessageBox.Show("Будь ласка, введіть ціле число для E1.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtE2.Text, out int e2))
            {
                MessageBox.Show("Будь ласка, введіть ціле число для E2.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            processedList = new List<int>(originalList);
            for (int i = processedList.Count - 1; i >= 0; i--)
            {
                if (processedList[i] == e1)
                {
                    processedList.Insert(i, e2);
                }
            }

            lbProcessedList.ItemsSource = processedList;
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (processedList.Count == 0)
            {
                MessageBox.Show("Немає обробленого списку для збереження.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < processedList.Count; i++)
                        {
                            writer.Write(processedList[i]);
                            if ((i + 1) % 9 == 0 || i == processedList.Count - 1)
                            {
                                writer.WriteLine();
                            }
                            else
                            {
                                writer.Write(" ");
                            }
                        }
                    }
                    MessageBox.Show($"Список успішно збережено у файл: {filePath}", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
}