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

namespace task3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                CheckBracketBalance(fileContent);
            }
        }

        private void CheckBracketBalance(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                ResultTextBox.Text = "Файл порожній.";
                return;
            }

            int stackSize = expression.Length; // Максимальний можливий розмір стеку
            int[] stack = new int[stackSize];
            int top = -1;
            List<Tuple<int, int>> balancedPairs = new List<Tuple<int, int>>();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '(')
                {
                    if (top < stackSize - 1)
                    {
                        stack[++top] = i;
                    }
                    else
                    {
                        ResultTextBox.Text = "Сталася помилка: переповнення стеку (занадто багато відкритих дужок).";
                        return;
                    }
                }
                else if (currentChar == ')')
                {
                    if (top >= 0)
                    {
                        balancedPairs.Add(new Tuple<int, int>(stack[top--], i));
                    }
                    else
                    {
                        ResultTextBox.Text = "Дужки не збалансовані: знайдено закриваючу дужку без відповідної відкриваючої.";
                        return;
                    }
                }
            }

            if (top == -1)
            {
                if (balancedPairs.Count > 0)
                {
                    balancedPairs = balancedPairs.OrderBy(pair => pair.Item2).ToList();
                    ResultTextBox.Text = "Дужки збалансовані.\n";
                    foreach (var pair in balancedPairs)
                    {
                        ResultTextBox.Text += $"Відкриваюча дужка на позиції {pair.Item1}, закриваюча на позиції {pair.Item2}\n";
                    }
                }
                else
                {
                    ResultTextBox.Text = "Дужки збалансовані (дужок не знайдено).";
                }
            }
            else
            {
                ResultTextBox.Text = "Дужки не збалансовані: є незакриті відкриваючі дужки.";
            }
        }
}