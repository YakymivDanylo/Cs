using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Sequence;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Windows.Controls;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _filePath = string.Empty;
    private readonly List<DataResult> _results = new();
    private readonly Dictionary<string, int> _stats = new();

    public MainWindow()
    {
        InitializeComponent();
        InitStats();
    }

    private void InitStats()
    {
        _stats.Add("Валюти", 0);
        _stats.Add("Розміри", 0);
        _stats.Add("Температура", 0);
        _stats.Add("Дата/час", 0);
        _stats.Add("Телефони", 0);
        _stats.Add("Email", 0);
        _stats.Add("URL", 0);
        _stats.Add("IP-адреси", 0);
    }

    private void Browse_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Текстові файли|*.txt" };
        if (dialog.ShowDialog() == true)
        {
            _filePath = dialog.FileName;
            PathTextBox.Text = _filePath;
            InputBox.Text = File.ReadAllText(_filePath);
        }
    }

    // Виправлений узагальнений метод з явним вказівкою типу
    private void ProcessData(List<ModelResult> results, string dataType)
    {
        _stats[dataType] = results.Count;

        foreach (var result in results)
        {
            string value;

            if (dataType == "Телефони")
            {
                if (result.Resolution != null && result.Resolution.TryGetValue("value", out object val))
                {
                    value = val?.ToString()
                        .Replace(" ", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("-", "");
                }
                else
                {
                    value = result.Text;
                }
            }
            else
            {
                if (result.Resolution != null && result.Resolution.TryGetValue("value", out object val))
                {
                    value = val?.ToString();
                }
                else
                {
                    value = result.Text;
                }
            }

            _results.Add(new DataResult
            {
                Type = dataType,
                Text = result.Text,
                Value = value,
                Start = result.Start,
                End = result.End
            });
        }

        UpdateUI();
    }
    private void UpdateUI()
    {
        ResultsPanel.Children.Clear();
        
        foreach (var result in _results)
        {
            ResultsPanel.Children.Add(new TextBlock
            {
                Text = $"{result.Type}: {result.Text} → {result.Value}",
                Margin = new Thickness(0, 5, 0, 0)  // Виправлений Thickness
            });
        }

        StatsListView.ItemsSource = _stats.Select(s => new { Type = s.Key, Count = s.Value }).ToList();
    }

    // Виправлені обробники подій з явним вказівкою типу
    private void Currency_Click(object sender, RoutedEventArgs e)
    {
        var results = NumberWithUnitRecognizer.RecognizeCurrency(InputBox.Text, Culture.English);
        ProcessData(results, "Валюти");
    }

    private void Dimension_Click(object sender, RoutedEventArgs e)
    {
        var results = NumberWithUnitRecognizer.RecognizeDimension(InputBox.Text, Culture.English);
        ProcessData(results, "Розміри");
    }

    private void Temp_Click(object sender, RoutedEventArgs e)
    {
        var results = NumberWithUnitRecognizer.RecognizeTemperature(InputBox.Text, Culture.English);
        ProcessData(results, "Температура");
    }

    private void DateTime_Click(object sender, RoutedEventArgs e)
    {
        var results = DateTimeRecognizer.RecognizeDateTime(InputBox.Text, Culture.English);
        ProcessData(results, "Дата/час");
    }

    private void Contacts_Click(object sender, RoutedEventArgs e)
    {
        // Очищаємо попередні результати для контактів
        ClearPreviousContactResults();
    
        // Розпізнаємо email
        var emails = SequenceRecognizer.RecognizeEmail(InputBox.Text, Culture.English);
        ProcessData(emails, "Email");
    
        // Розпізнаємо телефони
        var phones = SequenceRecognizer.RecognizePhoneNumber(InputBox.Text, Culture.English);
        ProcessData(phones, "Телефони");
    
        // Розпізнаємо URL
        var urls = SequenceRecognizer.RecognizeURL(InputBox.Text, Culture.English);
        ProcessData(urls, "URL");
    
        // Розпізнаємо IP-адреси
        var ips = SequenceRecognizer.RecognizeIpAddress(InputBox.Text, Culture.English);
        ProcessData(ips, "IP-адреси");
    }

    private void ClearPreviousContactResults()
    {
        // Видаляємо тільки результати пов'язані з контактами
        _results.RemoveAll(r => r.Type == "Email" || r.Type == "Телефони" || 
                                r.Type == "URL" || r.Type == "IP-адреси");
    
        // Оновлюємо статистику
        _stats["Email"] = 0;
        _stats["Телефони"] = 0;
        _stats["URL"] = 0;
        _stats["IP-адреси"] = 0;
    
        UpdateUI();
    }

    private void SaveResults()
    {
        var saveDialog = new SaveFileDialog { Filter = "Текстові файли|*.txt" };
        if (saveDialog.ShowDialog() == true)
        {
            var lines = new List<string> { "=== Результати розпізнавання ===" };
            
            foreach (var result in _results)
                lines.Add($"{result.Type.PadRight(15)}: {result.Text} → {result.Value}");
            
            lines.Add("\n=== Статистика ===");
            foreach (var stat in _stats)
                lines.Add($"{stat.Key.PadRight(15)}: {stat.Value}");
            
            File.WriteAllLines(saveDialog.FileName, lines);
        }
    }
}

public class DataResult
{
    public string Type { get; set; }
    public string Text { get; set; }
    public string? Value { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
}