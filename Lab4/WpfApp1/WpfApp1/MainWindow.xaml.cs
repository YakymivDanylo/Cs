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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
   
    private void ProcessDataButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var workers = ReadWorkersFromFile(@"C:\Labs\C#Labs\Lab4\WpfApp1\WpfApp1\Input.txt");
            var filteredWorkers = FilterWorkersByHireYear(workers, 2010);

            // Вивести результат у ListView
            workersListView.ItemsSource = filteredWorkers;

            // Записати результат у файл Output Data.txt
            WriteWorkersToFile(@"C:\Labs\C#Labs\Lab4\WpfApp1\WpfApp1\Output.txt", filteredWorkers);

            // Вивести повідомлення в Label
            ResultLabel.Content = "Результати успішно записано в Output Data.txt";
        }
        catch (Exception ex)
        {
            // Вивести повідомлення про помилку
            ResultLabel.Content = "Сталася помилка: " + ex.Message;
            ResultLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
        }
    }


    private List<Worker> ReadWorkersFromFile(string filePath)
    {
        var workers = new List<Worker>();
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 9)
            {
                var worker = new Worker
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    Patronymic = parts[2],
                    Address = parts[3],
                    Nationality = parts[4],
                    DateOfBirth = DateTime.Parse(parts[5]),
                    ShopNumber = int.Parse(parts[6]),
                    EmployeeNumber = parts[7],
                    HireYear = DateTime.Parse(parts[8])
                };
                workers.Add(worker);
            }
        }
        return workers;
    }


    private List<Worker> FilterWorkersByHireYear(List<Worker> workers, int year)
    {
        return workers.Where(w => w.HireYear.Year == year).ToList();
    }

    // Запис результатів у файл
    private void WriteWorkersToFile(string filePath, List<Worker> workers)
    {
        var lines = workers.Select(w => $"{w.LastName};{w.FirstName};{w.Patronymic};{w.Address};{w.Nationality};{w.DateOfBirth:yyyy-MM-dd};{w.ShopNumber};{w.EmployeeNumber};{w.HireYear:yyyy-MM-dd}").ToList();
        File.WriteAllLines(filePath, lines);
    }
}
