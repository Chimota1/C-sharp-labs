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

namespace lab3._3;

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
        string text = Text.Text;
        
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '(', ')', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);

        string bestWord = "";
        int maxCount = 0;

        foreach (string w in words)
        {
            int count = MaxSameCharCount(w);
            if (count > maxCount)
            {
                maxCount = count;
                bestWord = w;
            }
        }

        Result.Text = bestWord;
    }

    private int MaxSameCharCount(string word)
    {
        int max = 0;
        for (int i = 0; i < word.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (word[i] == word[j])
                    count++;
            }
            if (count > max)
                max = count;
        }

        return max;
    }
}