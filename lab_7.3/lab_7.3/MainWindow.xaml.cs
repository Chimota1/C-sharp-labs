using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace lab_7._3
{
    struct Market
    {
        public string nameOfProduct;
        public string company;
        public DateTime date;
        public int expirationDays;
        public double price;
    }

    public partial class MainWindow : Window
    {
        List<Market> products = new List<Market>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // ------------------------- ДОДАВАННЯ ТОВАРУ -------------------------
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = DateBox.Text.Split(':');
                if (parts.Length != 3)
                {
                    Result.Text = " Формат дати має бути дд:мм:рррр";
                    return;
                }

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);
                DateTime manufactureDate = new DateTime(year, month, day);

                Market product = new Market();
                product.nameOfProduct = NameOfProductBox.Text;
                product.company = CompanyBox.Text;
                product.date = manufactureDate;
                product.expirationDays = int.Parse(ExpirationDateBox.Text);
                product.price = double.Parse(CostBox.Text);

                products.Add(product);
                Result.Text = $"Товар '{product.nameOfProduct}' додано успішно!";
            }
            catch (Exception ex)
            {
                Result.Text = "Помилка введення: " + ex.Message;
            }
        }
        
        private void OutputInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count == 0)
            {
                Result.Text = "Список товарів порожній.";
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var p in products)
            {
                DateTime expirationDate = p.date.AddDays(p.expirationDays);
                sb.AppendLine($"{p.nameOfProduct} | {p.company} | Вироблено: {p.date:d} | Закінчується: {expirationDate:d} | Ціна: {p.price} грн");
            }

            Result.Text = sb.ToString();
        }
        
        private void OutputInfoByMonthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Input2.Text, out int month))
            {
                Result.Text = "❌ Введіть номер місяця!";
                return;
            }

            var filtered = products.Where(p => p.date.Month == month && p.date.Year == DateTime.Now.Year);
            StringBuilder sb = new StringBuilder();

            foreach (var p in filtered)
            {
                sb.AppendLine($"{p.nameOfProduct} — {p.date:d}");
            }

            Result.Text = sb.Length > 0 ? sb.ToString() : "Немає товарів, вироблених цього місяця.";
        }
        
        private void OutputInfoBy2Days_Click(object sender, RoutedEventArgs e)
        {
            DateTime target = DateTime.Now.AddDays(2);
            var soon = products.Where(p => p.date.AddDays(p.expirationDays).Date == target.Date);

            int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var p in soon)
            {
                sb.AppendLine($"{p.nameOfProduct} — закінчується {p.date.AddDays(p.expirationDays):d}");
                count++;
            }

            sb.AppendLine($"\nКількість таких товарів: {count}");
            Result.Text = count > 0 ? sb.ToString() : "Немає товарів, що закінчуються через 2 дні.";
        }

        // ------------------------- 4. НАЙСВІЖІШИЙ ТОВАР -------------------------
        private void OutputByFreshBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameOfProductBox.Text.Trim();
            var same = products.Where(p => p.nameOfProduct.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (!same.Any())
            {
                Result.Text = "❌ Немає такого товару.";
                return;
            }

            var freshest = same.OrderByDescending(p => p.date).First();
            Result.Text = $"Найсвіжіший товар '{freshest.nameOfProduct}', виготовлений {freshest.date:d}";
        }

        // ------------------------- 5. НА СПИСАННЯ -------------------------
        private void OutputByStaleBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            var expired = products.Where(p => p.date.AddDays(p.expirationDays) < now);

            StringBuilder sb = new StringBuilder();
            foreach (var p in expired)
            {
                sb.AppendLine($"{p.nameOfProduct} — термін закінчився {p.date.AddDays(p.expirationDays):d}");
            }

            Result.Text = sb.Length > 0 ? sb.ToString() : "Немає товарів для списання.";
        }
    }
}
