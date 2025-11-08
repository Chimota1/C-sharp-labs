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

namespace lab7._2
{
    public struct ITINERARY
    {
        public string FIRST;
        public string FINAL;
        public int NUM;
        public int DISTANCE;
    }

    public class SortByDistance : IComparer<ITINERARY>
    {
        public int Compare(ITINERARY x, ITINERARY y)
        {
            if (x.DISTANCE < y.DISTANCE)
            return 1;
            else if (x.DISTANCE > y.DISTANCE)
                return -1;
            else
                return 0;
    }    
    }
    
    public partial class MainWindow : Window
    {
        List<ITINERARY> Routh = new List<ITINERARY>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ITINERARY temp;
            temp.FIRST = FirstBox.Text;
            temp.FINAL = FinalBox.Text;
            temp.NUM = int.Parse(NumBox.Text);
            temp.DISTANCE = int.Parse(DistanceBox.Text);
            Routh.Add(temp);
            FirstBox.Clear();
            FinalBox.Clear();
            NumBox.Clear();
            DistanceBox.Clear();
        }

        public void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Routh.Count > 0)
            {
                Routh.Sort(new SortByDistance());
                foreach (ITINERARY temp in Routh)
                {
                    OutputBlock.Text +=
                        $"From: {temp.FIRST} To: {temp.FINAL} Number: {temp.NUM} Distance: {temp.DISTANCE}\n";
                }
            }
            else
            {
                OutputBlock.Text = "The list is empty!";
            }
        }

        public void SearchBtn(object sender, RoutedEventArgs e)
            {
                int searchNum = int.Parse(SearchNumBox.Text);
                StringBuilder results = new StringBuilder();
                foreach (ITINERARY temp in Routh)
                {
                    if (temp.NUM == searchNum)
                    {
                        results.AppendLine($"From: {temp.FIRST} To: {temp.FINAL} Number: {temp.NUM} Distance: {temp.DISTANCE}");
                    }
                }
                if (results.Length > 0)
                {
                    OutputBlock.Text = results.ToString();
                }
                else
                {
                    OutputBlock.Text = "No routes found within the specified distance.";
                }
            }
        }
}