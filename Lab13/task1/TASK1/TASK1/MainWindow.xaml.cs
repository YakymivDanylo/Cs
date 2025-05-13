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
using System.Threading;
using System.Windows.Threading;

namespace TASK1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Thread _pingThread; // Потік для перевірки сервера
    private bool _isRunning = false; // Прапорець для контролю роботи потоку
    private readonly Random _random; // Генератор випадкових чисел
    private readonly object _lock = new object(); // Об'єкт для блокування

    public MainWindow()
    {
        InitializeComponent();
        _random = new Random();
    }

    // Обробник кнопки Start
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isRunning) return;

        LogMessage("Запуск моніторингу сервера...");

        _isRunning = true;
        StartButton.IsEnabled = false;
        StopButton.IsEnabled = true;

        // Створюємо і запускаємо новий потік
        _pingThread = new Thread(PingServer)
        {
            IsBackground = true // Це дозволить потоку автоматично завершитися при закритті програми
        };
        _pingThread.Start();
    }

    // Обробник кнопки Stop
    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        if (!_isRunning) return;

        LogMessage("Зупинка моніторингу сервера...");

        // Безпечно зупиняємо потік
        lock (_lock)
        {
            _isRunning = false;
        }

        StartButton.IsEnabled = true;
        StopButton.IsEnabled = false;
    }

    // Метод для імітації пінгу сервера
    private void PingServer()
    {
        try
        {
            while (true)
            {
                // Перевіряємо, чи потрібно продовжувати роботу
                lock (_lock)
                {
                    if (!_isRunning) break;
                }

                // Імітуємо затримку мережевого запиту
                Thread.Sleep(5000);

                // Генеруємо випадковий результат (80% шанс успіху)
                bool isSuccess = _random.Next(0, 100) < 80;
                string message = isSuccess
                    ? "Успішно: сервер доступний"
                    : "Помилка: сервер не відповідає";

                // Виводимо результат в лог
                LogMessage(message);
            }
        }
        catch (ThreadAbortException)
        {
            // Не використовуємо Thread.Abort(), тому цей блок майже не потрібен
            LogMessage("Потік перервано примусово");
        }
        catch (Exception ex)
        {
            LogMessage($"Помилка в потоці: {ex.Message}");
        }
        finally
        {
            // Оновлюємо UI при завершенні потоку
            Dispatcher.Invoke(() =>
            {
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            });
        }
    }

    // Метод для додавання повідомлення в лог
    private void LogMessage(string message)
    {
        // Використовуємо Dispatcher для безпечного оновлення UI
        Dispatcher.Invoke(() =>
        {
            string timestamp = DateTime.Now.ToString("[HH:mm:ss] ");
            LogTextBox.AppendText(timestamp + message + Environment.NewLine);
            LogTextBox.ScrollToEnd();
        });
    }

    // Обробник закриття вікна
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        // Завершуємо потік при закритті програми
        lock (_lock)
        {
            _isRunning = false;
        }

        // Даємо потоку час на коректне завершення
        if (_pingThread != null && _pingThread.IsAlive)
        {
            if (!_pingThread.Join(1000)) // Чекаємо 1 секунду
            {
                _pingThread.Interrupt(); // Якщо потік не відповідає
            }
        }
    }
}