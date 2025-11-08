using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace lab6_3
{
    public partial class MainWindow : Window
    {
        private Auto currentAuto = new Auto();
        private AutoCollection autos = new AutoCollection(100);

        public MainWindow()
        {
            InitializeComponent();
            
            autos.Add(new Auto { Cost = 50000, Power = 150 });
            autos.Add(new Auto { Cost = 30000, Power = 180 });
            autos.Add(new Auto { Cost = 50000, Power = 100 });
            autos.Add(new Auto { Cost = 40000, Power = 200 });
            autos.Add(new Auto { Cost = 30000, Power = 120 });
        }
        
        private void SetCostBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Setters.Text, out int cost))
            {
                currentAuto.Cost = cost;
                Setters.Text = string.Empty;
                Btn1.Visibility = Visibility.Hidden;
                Btn2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Введіть число для Cost!");
            }
        }
        
        private void BtnPowerBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Setters.Text, out int power))
            {
                currentAuto.Power = power;
                Setters.Text = string.Empty;

                autos.Add(currentAuto);
                currentAuto = new Auto();

                Btn2.Visibility = Visibility.Hidden;
                Setters.Visibility = Visibility.Hidden;
                OutputText.Visibility = Visibility.Visible;
                Btn3.Visibility = Visibility.Visible;
                Btn4.Visibility = Visibility.Visible;
                Btn5.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Введіть число для Power!");
            }
        }
        
        private void OutputBtn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in autos)
            {
                sb.AppendLine(a.ToString());
            }
            OutputText.Text = sb.ToString();
        }
        
        private void SortByCostBtn(object sender, RoutedEventArgs e)
        {
            var sorted = autos.GetSorted(new CompareByCost());
            ShowAutos(sorted, "Сортування за ціною:");
        }
        
        private void SortByPowerBtn(object sender, RoutedEventArgs e)
        {
            var sorted = autos.GetSorted(new CompareByPower());
            ShowAutos(sorted, "Сортування за потужністю:");
        }

        private void ShowAutos(IEnumerable<Auto> list, string title)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(title);
            sb.AppendLine(new string('-', 30));
            foreach (var a in list)
            {
                sb.AppendLine(a.ToString());
            }
            OutputText.Text = sb.ToString();
        }
    }
    

    public class Auto : IComparable<Auto>
    {
        public int Cost { get; set; }
        public int Power { get; set; }

        public int CompareTo(Auto obj)
        {
            int costCompare = Cost.CompareTo(obj.Cost);
            return costCompare != 0 ? costCompare : Power.CompareTo(obj.Power);
        }

        public override string ToString()
        {
            return $"Cost: {Cost}, Power: {Power}";
        }
    }
    
    public class CompareByCost : IComparer<Auto>
    {
        public int Compare(Auto x, Auto y)
        {
            return x.Cost.CompareTo(y.Cost);
        }
    }
    
    public class CompareByPower : IComparer<Auto>
    {
        public int Compare(Auto x, Auto y)
        {
            return x.Power.CompareTo(y.Power);
        }
    }
    
    public class AutoCollection : IEnumerable<Auto>
    {
        private Auto[] _autos;
        private int _count = 0;

        public AutoCollection(int capacity)
        {
            _autos = new Auto[capacity];
        }

        public void Add(Auto auto)
        {
            if (_count < _autos.Length)
            {
                _autos[_count++] = auto;
            }
        }

        public IEnumerable<Auto> GetSorted(IComparer<Auto> comparer)
        {
            Auto[] copy = new Auto[_count];
            Array.Copy(_autos, copy, _count);
            Array.Sort(copy, comparer);
            return copy;
        }

        public IEnumerator<Auto> GetEnumerator()
        {
            Array.Sort(_autos, 0, _count);
            for (int i = 0; i < _count; i++)
            {
                yield return _autos[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
