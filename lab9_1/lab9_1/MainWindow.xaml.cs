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

namespace lab9_1;

public partial class MainWindow : Window
{
    List<int> numbers = new List<int>();
    public MainWindow()
    {
        InitializeComponent();
        string numbersFile = "D:\\PKPZ\\C-sharp-labs\\lab9_1\\lab9_1\\Numbers.txt";
        string outputFile = "D:\\PKPZ\\C-sharp-labs\\lab9_1\\lab9_1\\Output.txt";
        File.WriteAllText(numbersFile, string.Empty);
        File.WriteAllText(outputFile, string.Empty);
    }
    void Add_Click(object sender, RoutedEventArgs e)
    {
        string path = "D:\\PKPZ\\C-sharp-labs\\lab9_1\\lab9_1\\Numbers.txt";
        int num = int.Parse(InputBox.Text);
        numbers.Add(num);
        File.AppendAllText(path, InputBox.Text + ' ', Encoding.UTF8);
        InputBox.Clear();
    }

    void Change_Click(object sender, RoutedEventArgs e)
    {
        string numbersFile = "D:\\PKPZ\\C-sharp-labs\\lab9_1\\lab9_1\\Numbers.txt";
        string outputFile = "D:\\PKPZ\\C-sharp-labs\\lab9_1\\lab9_1\\Output.txt";
        int count = 0;
        List<int> negative = new List<int>();
        foreach (var n in numbers)
        {
            if (n < 0)
            {
                negative.Add(n);
            }
        }
        
        foreach (var n in negative)
        {
            numbers.Remove(n);
        }
        
        negative.Reverse();
        numbers.AddRange(negative);
        foreach (var n in numbers)
        {
            File.AppendAllText(outputFile, n.ToString() + ' ', Encoding.UTF8);
            count++;
            if (count % 5 == 0)
            {
                File.AppendAllText(outputFile, Environment.NewLine, Encoding.UTF8);
            }

            OutputBlock.Text += n.ToString() + ' ';
        }
    }
}