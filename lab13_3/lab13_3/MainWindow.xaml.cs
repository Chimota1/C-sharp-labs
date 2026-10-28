using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32; // Для діалогу відкриття файлу

// Підключаємо всі необхідні простори імен Recognizers
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Sequence;

namespace lab13_3;

public partial class MainWindow : Window
{
    private string userInput = "";

    public MainWindow()
    {
        InitializeComponent();
    }

    // Кнопка: Зчитати дані з файлу
    private void EnterClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                // Зчитуємо весь текст
                userInput = File.ReadAllText(openFileDialog.FileName);
                // Виводимо на форму
                Input.Text = userInput;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка читання файлу: {ex.Message}");
            }
        }
    }

    // Кнопка: Розпізнати, вивести статистику та зберегти
    private void OutputClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            OutputText.Text = "Спочатку завантажте текст!";
            return;
        }

        StringBuilder report = new StringBuilder();
        report.AppendLine($"ЗВІТ РОЗПІЗНАВАННЯ ({DateTime.Now})");
        report.AppendLine(new string('=', 40));

        // --- 1. ВАЛЮТА (Currency) ---
        var currencies = NumberWithUnitRecognizer.RecognizeCurrency(userInput, Culture.English);
        AppendCategoryResult(report, "Валюти (Currencies)", currencies);

        // --- 2. РОЗМІРИ/ВАГА (Dimension) ---
        var dimensions = NumberWithUnitRecognizer.RecognizeDimension(userInput, Culture.English);
        AppendCategoryResult(report, "Вимірювання (Dimensions)", dimensions);

        // --- 3. ТЕМПЕРАТУРА (Temperature) ---
        var temps = NumberWithUnitRecognizer.RecognizeTemperature(userInput, Culture.English);
        AppendCategoryResult(report, "Температура (Temperature)", temps);

        // --- 4. ДАТА І ЧАС (DateTime) ---
        var dates = DateTimeRecognizer.RecognizeDateTime(userInput, Culture.English);
        AppendCategoryResult(report, "Дата та час (DateTime)", dates);

        // --- 5. ТЕЛЕФОНИ (Phone Numbers) ---
        var phones = SequenceRecognizer.RecognizePhoneNumber(userInput, Culture.English);
        AppendCategoryResult(report, "Номери телефонів (Phone Numbers)", phones);

        // --- 6. IP-АДРЕСИ (IP Address) ---
        var ips = SequenceRecognizer.RecognizeIpAddress(userInput, Culture.English);
        AppendCategoryResult(report, "IP-адреси (IP Addresses)", ips);

        // --- 7. EMAIL ---
        var emails = SequenceRecognizer.RecognizeEmail(userInput, Culture.English);
        AppendCategoryResult(report, "Електронні пошти (Emails)", emails);

        // --- 8. URL (Links) ---
        var urls = SequenceRecognizer.RecognizeURL(userInput, Culture.English);
        AppendCategoryResult(report, "URL-адреси (URLs)", urls);

        // --- 9. ХЕШ-ТЕГИ (Hashtags) ---
        var hashtags = SequenceRecognizer.RecognizeHashtag(userInput, Culture.English);
        AppendCategoryResult(report, "Хеш-теги (Hashtags)", hashtags);

        // --- Фінальний вивід ---
        string finalReport = report.ToString();
        OutputText.Text = finalReport;

        // --- Запис у файл ---
        try
        {
            string outputPath = "result_report.txt";
            File.WriteAllText(outputPath, finalReport);
            MessageBox.Show($"Аналіз завершено!\nРезультат збережено у файл: {outputPath}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка запису файлу: {ex.Message}");
        }
    }

    // Допоміжний метод, щоб не писати один і той же цикл 9 разів
    private void AppendCategoryResult(StringBuilder sb, string categoryName, List<ModelResult> results)
    {
        sb.AppendLine();
        sb.AppendLine($">>> КАТЕГОРІЯ: {categoryName}");
        sb.AppendLine($"Кількість знайдених: {results.Count}");
        
        if (results.Count > 0)
        {
            sb.AppendLine("- Деталі -");
            foreach (var item in results)
            {
                // Формуємо рядок результату
                sb.AppendLine($"   • Текст: \"{item.Text}\"");
                
                // Якщо є розпізнане значення (Value), спробуємо його показати
                // У різних типів структура Resolution різна, тому беремо просто словник
                if (item.Resolution != null && item.Resolution.Count > 0)
                {
                    foreach (var kvp in item.Resolution)
                    {
                        // Виводимо ключові дані (зазвичай value, unit, unit, date тощо)
                        sb.AppendLine($"     [{kvp.Key}]: {kvp.Value}");
                    }
                }
            }
        }
        sb.AppendLine(new string('-', 30));
    }
}