using System;
using System.Threading; // Необхідно для класу Thread
using System.Windows;

namespace WpfTimeMonitor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Thread timeThread = new Thread(MonitorTime);
            timeThread.IsBackground = true;
            timeThread.Start();
        }
        
        private void MonitorTime()
        {
            while (true)
            {
                string currentTime = DateTime.Now.ToString("HH:mm");
                Dispatcher.Invoke(() =>
                {
                    TimeDisplay.Text = currentTime;
                });
                Thread.Sleep(60000);
            }
        }
    }
}