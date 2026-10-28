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
    
namespace lab13_2;

public partial class MainWindow : Window
{
    private string userInput;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void EnterClick(object sender, RoutedEventArgs e)
    {  
        this.userInput = Input.Text;
        Input.Text = string.Empty;
    }

    private void OutputClick(object sender, RoutedEventArgs e)
    {
        var results = NumberRecognizer.RecognizeOrdinal(userInput, Culture.English);
        if (results.Count == 0)
        {
            OutputText.Text = "Порядкових числівників не знайдено.";
            return;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Всього знайдено: {results.Count}");
        sb.AppendLine("-----------------------------");
        foreach (var result in results)
        {
            string text = result.Text;
            string value = "не визначено";
        
            if (result.Resolution.TryGetValue("value", out var val))
            {
                value = val.ToString();
            }
            sb.AppendLine($"Text (підрядок): {text}");
            sb.AppendLine($"Resolution (значення): {value}");
            sb.AppendLine("-");
        }

        OutputText.Text = sb.ToString();
    }
}