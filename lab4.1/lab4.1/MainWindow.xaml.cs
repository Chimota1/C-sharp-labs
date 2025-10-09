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
using System.IO;

namespace lab4._1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        InitPath();
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        FindBiggerThan10();
    }
    
    
    private void InitPath()
    {
        string text = Output.Text;
        string path = "D:\\PKPZ\\C-sharp-labs\\lab4.1\\lab4.1\\Input_data.txt";
        string[,] array = new string[15, 10];
        for (int i = 0; i < 15; i++)
        {
            string data = File.ReadAllText(path);
            string[] values = data.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < 10; j++)
            {
                array[i, j] = values[j];
                values[j] = text;
            }
        }

        Output.Text = File.ReadAllText(path);
    }

    private void FindBiggerThan10()
    {
        string text = Output.Text;
        string data = File.ReadAllText("D:\\PKPZ\\C-sharp-labs\\lab4.1\\lab4.1\\Input_data.txt");
        string[] lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        string outputPath = "D:\\PKPZ\\C-sharp-labs\\lab4.1\\lab4.1\\Output_data.txt";
        string guard = null;
        foreach (string line in lines)
        {
            if (line.StartsWith("Охоронець"))
            {
                guard = line;
            }
            if (line.StartsWith("Рік працевлаштування:"))
            {
                string yearString = line.Split(':')[1].Trim();
                int year = int.Parse(yearString);
                if (year <= 2015)
                {
                    Output.Text = guard;
                    File.WriteAllText(outputPath, guard);
                }
            }
        }
    }
}