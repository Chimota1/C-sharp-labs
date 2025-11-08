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

namespace lab8_1;


public partial class MainWindow : Window
{
    private int count = 0;
    List<Tuple<string, int, int, int>> teams = new List<Tuple<string, int, int, int>>();
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void AddTeam(object sender, RoutedEventArgs e)
    {
        string name = TeamNameBox.Text;
        int points = int.Parse(PointsBox.Text);
        int place = int.Parse(PlaceBox.Text);
        int injures = int.Parse(InjuredBox.Text);
        teams.Add(new Tuple<string, int, int, int>(name, points, place, injures));
        count++;
        TeamNameBox.Clear();
        PointsBox.Clear();
        PlaceBox.Clear();
        InjuredBox.Clear();
    }
    
    public void ShowTeams(object sender, RoutedEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var team in teams)
        {
            sb.AppendLine($"Team: {team.Item1}, Points: {team.Item2}, Place: {team.Item3}, Injured players: {team.Item4}");
        }
        Result.Text += sb.ToString();
    }

    public void WhoGoToChamp(object sender, RoutedEventArgs e)
    {
        int sum = 0;
        int avarage = 0;
        foreach (var team in teams)
        {
            sum += team.Item2;
        }
        avarage = sum / count;
        foreach (var team in teams)
        {
            if (team.Item2 > avarage)
            {
                Result.Text += $"Team {team.Item1} goes to championship!\n";
            }
        }
    }
}