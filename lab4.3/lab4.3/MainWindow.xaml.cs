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
using Path = System.Windows.Shapes.Path;

namespace lab4._3;

public partial class MainWindow : Window
{
    private int n1;
    private int n2;
    private string operation = "";
    private string session = @"D:\PKPZ\C-sharp-labs\lab4.3\lab4.3\SessionLog.txt";
    private int sessionCount = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartButton(object sender, RoutedEventArgs e)
    {
        Start.Visibility = Visibility.Hidden;
        Result.Visibility = Visibility.Visible;
        Panel.Visibility = Visibility.Visible;
        ButtonBlock.Visibility = Visibility.Visible;
        sessionCount = 0;
        File.WriteAllText(session, string.Empty);
        sessionCount++;
        File.WriteAllLines(session, new string[] { $"Дія{sessionCount}: Запуск програми" });
    }

    private void CalculateClick(object sender, RoutedEventArgs e)
    {
        if (PlusButton.IsChecked == true)
        {
            sessionCount++;
            operation = "+";
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Додвання" });
        }
        else if (MinusButton.IsChecked == true)
        {
            sessionCount++;
            operation = "-";
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Віднімання" });
        }
        else if (MultiplyButton.IsChecked == true)
        {
            sessionCount++;
            operation = "*";
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Множення" });
        }
        else if (DivideButton.IsChecked == true)
        {
            sessionCount++;
            operation = "/";
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Ділення" });
        }
        else if (ElevationButton.IsChecked == true)
        {
            sessionCount++;
            operation = "^";
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Піднесення до степеня" });
        }

        try
        {
            switch (operation)
            {
                case "+":
                    ResultNumber.Text = (n1 + n2).ToString();
                    sessionCount++;
                    File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Обчислення" });
                    break;
                case "-":
                    ResultNumber.Text = (n1 - n2).ToString();
                    sessionCount++;
                    File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Обчислення" });
                    break;
                case "*":
                    sessionCount++;
                    ResultNumber.Text = (n1 * n2).ToString();
                    File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Обчислення" });
                    break;
                case "/":
                    try
                    {
                        ResultNumber.Text = (n1 / n2).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Ділення на нуль неможливе");
                    }
                    finally
                    {
                        sessionCount++;
                        File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Обчислення" });
                    }

                    break;
                case "^":
                    try
                    {
                        ResultNumber.Text = (Math.Pow(n1, n2)).ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Помилка піднесення до степеня 0: " + ex.Message);
                    }
                    finally
                    {
                        sessionCount++;
                        File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Обчислення" });
                        
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            if (n1 == 0 && n2 == 0)
            {
                throw new Exception("Ви не імпортували дані");
            }
        }
    }

    private void ImportClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string path = @"D:\PKPZ\C-sharp-labs\lab4.3\lab4.3\Input_data.txt";
            string[] numbers = System.IO.File.ReadAllLines(path);
            string lines = numbers[0];
            string[] parts = lines.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);
            n1 = int.Parse(parts[0].Trim());
            n2 = int.Parse(parts[1].Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Помилка імпорту даних: " + ex.Message);
        }
        finally
        {
            sessionCount++;
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Імпорт даних" });
        }
    }

    private void ExportClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string path = @"D:\PKPZ\C-sharp-labs\lab4.3\lab4.3\Output.txt";
            File.WriteAllText(path, $"{n1}{operation}{n2}  Результат: {ResultNumber.Text}", Encoding.UTF8);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не вдалось відкрити файл: " + ex.Message);
        }
        finally
        {
            sessionCount++;
            File.AppendAllLines(session, new string[] { $"Дія{sessionCount}: Експорт даних" });
        }
    }
}
