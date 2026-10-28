using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTimeMonitor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartTimeMonitorWithDelay(1000);
            StartTimeMonitorWithDelay(3000);
            StartTimeMonitorWithDelay(5000);
        }

        private void StartTimeMonitorWithDelay(int delay)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    
                    await Dispatcher.InvokeAsync(() =>
                    {
                        TimeDisplay.Text = $"{time}  (delay: {delay} ms)";
                    });

                    await Task.Delay(delay);
                }
            });
        }
    }
}