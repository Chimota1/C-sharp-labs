using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncFileDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            StatusText.Text = "Статус: Виконується...";

            Log("Старт процесу...");
            string inputPath = "bigData.txt";
            string outputPath = "processedData.txt";

            await ProcessFileAsync(inputPath, outputPath);

            Log("Готово! Запис завершено.");
            StatusText.Text = "Статус: Завершено";
            StartButton.IsEnabled = true;
        }

        // Асинхронний метод обробки «великого файлу»
        private async Task ProcessFileAsync(string inputPath, string outputPath)
        {
            // 1. Імітація читання
            Log("Читання великого файлу...");
            await Task.Delay(3000);

            string fileData = "This is BIG DATA content...";

            // 2. Обробка даних
            Log("Обробка даних...");
            string processed = fileData.ToUpper();

            // 3. Асинхронний запис
            Log("Запис у файл...");
            await File.WriteAllTextAsync(outputPath, processed);
        }

        // Для зручності: додавання тексту у лог
        private void Log(string text)
        {
            LogBox.AppendText(text + Environment.NewLine);
            LogBox.ScrollToEnd();
        }
    }
}