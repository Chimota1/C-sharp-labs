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
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;

namespace lab13_1;

public partial class MainWindow : Window
{
    private string userText;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EnterClick(object sender, RoutedEventArgs e)
    {  
        this.userText = Input.Text;
       Input.Text = string.Empty;
    }

private void OutputClick(object sender, RoutedEventArgs e)
    {
        var results = NumberRecognizer.RecognizeNumber(userText, Culture.English);
        
        StringBuilder finalOutput = new StringBuilder();
        
        finalOutput.AppendLine("=== РЕЗУЛЬТАТИ РОЗПІЗНАВАННЯ ===");
        
        foreach (var result in results)
        {
            string value = "N/A";
            if (result.Resolution.TryGetValue("value", out var val))
            {
                value = val.ToString();
            }

            finalOutput.AppendLine($"Розпізнаний текст (число): {result.Text}");
            finalOutput.AppendLine($"Початковий індекс у рядку: {result.Start}");
            finalOutput.AppendLine($"Кінцевий індекс у рядку: {result.End}");
            finalOutput.AppendLine($"Розпізнане значення числа: {value}");
            finalOutput.AppendLine(new string('-', 20));
        }
        
        StringBuilder modifiedTextBuilder = new StringBuilder(userText);

        var sortedResults = results.OrderByDescending(r => r.Start).ToList();

        foreach (var result in sortedResults)
        {
            if (result.Resolution.TryGetValue("value", out var val))
            {
                string numericValue = val.ToString();
                int length = result.End - result.Start + 1;
                modifiedTextBuilder.Remove(result.Start, length);
                modifiedTextBuilder.Insert(result.Start, numericValue);
            }
        }
        
        finalOutput.AppendLine("\n=== МОДИФІКОВАНИЙ ТЕКСТ ===");
        finalOutput.AppendLine(modifiedTextBuilder.ToString());
        
        OutputText.Text = finalOutput.ToString();
    }
}