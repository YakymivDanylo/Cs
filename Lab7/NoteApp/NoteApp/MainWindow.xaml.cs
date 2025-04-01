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

namespace NoteApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{ private List<Note> blocknote = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phone = PhoneTextBox.Text;
            if (DateTime.TryParse(BirthdayTextBox.Text, out DateTime birthday))
            {
                blocknote.Add(new Note(name, phone, birthday));
                MessageBox.Show("Запис додано!");
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                BirthdayTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Невірний формат дати!");
            }
        }

        private void SortNotes_Click(object sender, RoutedEventArgs e)
        {
            blocknote = blocknote.OrderBy(n => n.Birthday).ToList();
            NotesListBox.Items.Clear();
            foreach (var note in blocknote)
            {
                NotesListBox.Items.Add(note);
            }
        }

        private void SearchByMonth_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MonthTextBox.Text, out int month) && month >= 1 && month <= 12)
            {
                var results = blocknote.Where(n => n.Birthday.Month == month).ToList();
                SearchResultsListBox.Items.Clear();
                if (results.Count > 0)
                {
                    foreach (var note in results)
                    {
                        SearchResultsListBox.Items.Add(note);
                    }
                }
                else
                {
                    MessageBox.Show("Немає людей, народжених у цьому місяці.");
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний номер місяця (1-12)!");
            }
        }
    }

    public struct Note
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

        public Note(string name, string phone, DateTime birthday)
        {
            Name = name;
            Phone = phone;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Name}, {Phone}, {Birthday:dd.MM.yyyy}";
        }
}