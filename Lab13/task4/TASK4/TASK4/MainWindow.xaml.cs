using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;

namespace TASK4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void PingButton_Click(object sender, RoutedEventArgs e)
    {
        string userIp = IpTextBox.Text.Trim();

        string[] parts = userIp.Split('.');
        if (parts.Length != 4)
        {
            MessageBox.Show("Невiрний формат IP-адреси.");
            return;
        }

        ResultsListBox.Items.Clear();
        await PingNetworkAsync(parts);
    }

    private async Task PingNetworkAsync(string[] parts)
    {
        Task[] tasks = new Task[254];

        for (int i = 1; i < 255; i++)
        {
            string ipAddress = $"{parts[0]}.{parts[1]}.{parts[2]}.{i}";
            tasks[i - 1] = Task.Run(() => PingHost(ipAddress));
        }

        await Task.WhenAll(tasks);

        MessageBox.Show("Перевiрка мережi завершена.");
    }

    private void PingHost(string ipAddress)
    {
        Ping ping = new Ping();
        try
        {
            PingReply reply = ping.Send(ipAddress, 1000);  
            if (reply.Status == IPStatus.Success)
            {
                Dispatcher.Invoke(() => ResultsListBox.Items.Add($"{ipAddress} - доступна"));
            }
            else
            {
                Dispatcher.Invoke(() => ResultsListBox.Items.Add($"{ipAddress} - не доступна"));
            }
        }
        catch
        {
            Dispatcher.Invoke(() => ResultsListBox.Items.Add($"{ipAddress} - не доступна"));
        }
    }
}
