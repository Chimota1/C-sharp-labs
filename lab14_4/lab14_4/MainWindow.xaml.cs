using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows;

namespace PingTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ResultList.Items.Clear();

            string networkAddress = NetworkTextBox.Text.Trim();

            // Наприклад: 192.168.1.0 → беремо 192.168.1.
            string prefix = networkAddress.Substring(0, networkAddress.LastIndexOf('.') + 1);

            for (int i = 1; i <= 254; i++)
            {
                int host = i;

                Thread t = new Thread(() => PingHost(prefix + host));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void PingHost(string ip)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, 1000); // timeout 1 сек

                if (reply.Status == IPStatus.Success)
                {
                    Dispatcher.Invoke(() =>
                    {
                        ResultList.Items.Add($"ONLINE:  {ip}");
                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        ResultList.Items.Add($"OFFLINE: {ip}");
                    });
                }
            }
            catch
            {
                Dispatcher.Invoke(() =>
                {
                    ResultList.Items.Add($"ERROR:   {ip}");
                });
            }
        }
    }
}