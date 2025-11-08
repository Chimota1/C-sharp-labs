using System;
using System.Windows;

namespace lab8_3
{
    public partial class MainWindow : Window
    {
        enum TimeOfDay
        {
            Ранок,
            Ланч,
            День,
            Полудень,
            Вечір,
            Ніч
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTime_Click(object sender, RoutedEventArgs e)
        {
            string userInput = (inputBox.Text ?? "").Trim();

            if (userInput == "0")
            {
                Application.Current.Shutdown();
                return;
            }
            
            try
            {
                string normalized = FirstUpper(userInput);
                TimeOfDay time = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), normalized);

                switch (time)
                {
                    case TimeOfDay.Ранок:
                        resultText.Text = "Ранок – 8:00 (кава та тост)";
                        break;

                    case TimeOfDay.Ланч:
                        resultText.Text = "Ланч – 11:00 (бутерброд і сік)";
                        break;

                    case TimeOfDay.День:
                        resultText.Text = "День – 13:00 (суп і салат)";
                        break;

                    case TimeOfDay.Полудень:
                        resultText.Text = "Полудень – 16:00 (печиво та чай)";
                        break;

                    case TimeOfDay.Вечір:
                        resultText.Text = "Вечір – 19:00 (борщ і котлета)";
                        break;

                    case TimeOfDay.Ніч:
                        resultText.Text = "Ніч – 22:00 (йогурт або кефір)";
                        break;

                    default:
                        resultText.Text = "Невідомий час доби.";
                        break;
                }
            }
            catch (ArgumentException)
            {
                resultText.Text = "Такої доби не існує! Спробуйте: ранок, ланч, день, полудень, вечір, ніч.";
            }
        }

        private string FirstUpper(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;
            text = text.Trim().ToLowerInvariant();
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
