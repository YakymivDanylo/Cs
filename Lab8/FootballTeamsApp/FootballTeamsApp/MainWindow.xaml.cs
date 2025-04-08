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

namespace FootballTeamsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Tuple<string, int, int, int>> teams = new List<Tuple<string, int, int, int>>();
    public MainWindow()
    {
        InitializeComponent();
    }
     private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TeamNameTextBox.Text) ||
                !int.TryParse(TotalScoreTextBox.Text, out int totalScore) ||
                !int.TryParse(GoalsScoredTextBox.Text, out int goalsScored) ||
                !int.TryParse(GoalsConcededTextBox.Text, out int goalsConceded))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля коректними значеннями.", "Помилка введення");
                return;
            }

            var newTeam = Tuple.Create(TeamNameTextBox.Text, totalScore, goalsScored, goalsConceded);
            teams.Add(newTeam);
            TeamsListBox.Items.Add(newTeam.Item1); // Відображаємо лише назву в списку
            ClearInputFields();
            UpdateSelectionResults();
        }

        private void TeamsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsListBox.SelectedItem != null)
            {
                string selectedTeamName = TeamsListBox.SelectedItem.ToString();
                var selectedTeam = teams.FirstOrDefault(t => t.Item1 == selectedTeamName);
                if (selectedTeam != null)
                {
                    DisplayTeamInfo(selectedTeam);
                }
            }
        }

        private void DisplayTeamInfo(Tuple<string, int, int, int> team)
        {
            TeamInfoTextBlock.Text = $"Назва команди: {team.Item1}\n" +
                                      $"Загальний бал: {team.Item2}\n" +
                                      $"Забиті голи: {team.Item3}\n" +
                                      $"Пропущені голи: {team.Item4}";
        }

        private void ClearInputFields()
        {
            TeamNameTextBox.Clear();
            TotalScoreTextBox.Clear();
            GoalsScoredTextBox.Clear();
            GoalsConcededTextBox.Clear();
        }

        private void UpdateSelectionResults()
        {
            if (teams.Count > 0)
            {
                double averageScore = teams.Average(t => t.Item2);
                int selectedTeamsCount = teams.Count(t => t.Item2 > averageScore);
                SelectionResultsTextBlock.Text = $"Середній бал: {averageScore:F2}\n" +
                                                 $"Кількість команд, що пройшли відбір: {selectedTeamsCount}";
            }
            else
            {
                SelectionResultsTextBlock.Text = "Немає введених команд.";
            }
        }
}