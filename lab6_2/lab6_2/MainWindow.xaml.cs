using System.Windows;

namespace lab6_2
{
    public partial class MainWindow : Window
    {
        private OS os;
        private MobileApp app;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void InitClick(object sender, RoutedEventArgs e)
        {
            os = new OS(); // пустий конструктор
            app = new MobileApp("MyApp", "Android", 1.0f, 1.0f, false);

            // Робимо видимими елементи введення
            OsType.Visibility = Visibility.Visible;
            OsVersion.Visibility = Visibility.Visible;
            OsLicensed.Visibility = Visibility.Visible;
            SetOsButton.Visibility = Visibility.Visible;

            AppName.Visibility = Visibility.Visible;
            AppPlatform.Visibility = Visibility.Visible;
            AppCurrentVersion.Visibility = Visibility.Visible;
            AppPremium.Visibility = Visibility.Visible;
            SetAppButton.Visibility = Visibility.Visible;

            Output.Visibility = Visibility.Visible;

            OptimizationButton.Visibility = Visibility.Visible;
            ReleaseButton.Visibility = Visibility.Visible;
            SupportButton.Visibility = Visibility.Visible;
            TypeButton.Visibility = Visibility.Visible;

            StartButton.Visibility = Visibility.Hidden;
        }
        
        private void SetOSBtn(object sender, RoutedEventArgs e)
        {
            float.TryParse(OsVersion.Text, out float ver);
            bool licensed = OsLicensed.IsChecked == true;

            os.SetInfo(OsType.Text, ver, ver, licensed);
            Output.Text = $"OS info set: {OsType.Text}, Version: {ver}, Licensed: {licensed}";
        }
        
        private void SetAppBtn(object sender, RoutedEventArgs e)
        {
            string name = AppName.Text;
            string platform = AppPlatform.Text;
            float.TryParse(AppCurrentVersion.Text, out float currentVer);
            bool premium = AppPremium.IsChecked == true;

            app = new MobileApp(name, platform, currentVer, currentVer, premium);
            Output.Text = $"MobileApp info set: {name}, Platform: {platform}, Version: {currentVer}, Premium: {premium}";
        }
        
        private void OptimizationBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = $"OS Optimization (1.0): {os.Optimization(1.0f)}\n" +
                          $"App Optimization (1.0): {app.Optimization(1.0f)}";
        }

        private void ReleaseBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = $"OS Release 2.0: {os.RelaeseNewVersion(2.0f)}\n" +
                          $"App Release 2.0: {app.RelaeseNewVersion(2.0f)}";
        }

        private void SupportBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = $"OS Support: {os.ProvideTechnicalSupport()}\n" +
                          $"App Support: {app.ProvideTechnicalSupport()}";
        }
        
        private void TypeBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = $"OS Type: {os.TypeOfProgram("OS")}\n" +
                          $"App Type: {app.TypeOfProgram("Mobile App")}";
        }
    }
    
    public class OS : IProgramProduct, IDeveloper
    {
        private string typeOfProgram;
        private float versionOfOs;
        private float versionOfPro;
        private bool isLincesed;

        public bool Optimization(float version)
        {
            return versionOfOs >= version;
        }

        public string TypeOfProgram(string type)
        {
            typeOfProgram = type;
            return typeOfProgram;
        }

        public bool RelaeseNewVersion(float version)
        {
            if (versionOfPro < version)
            {
                versionOfPro = version;
                return true;
            }
            return false;
        }

        public bool ProvideTechnicalSupport()
        {
            return isLincesed;
        }

        public void SetInfo(string type, float versionOs, float versionPro, bool licensed)
        {
            typeOfProgram = type;
            versionOfOs = versionOs;
            versionOfPro = versionPro;
            isLincesed = licensed;
        }
    }
    
    public class MobileApp : IProgramProduct, IDeveloper
    {
        private string appName;
        private string platform;
        private float currentVersion;
        private float latestVersion;
        private bool hasPremium;

        public MobileApp(string name, string platform, float current, float latest, bool premium)
        {
            appName = name;
            this.platform = platform;
            currentVersion = current;
            latestVersion = latest;
            hasPremium = premium;
        }

        public bool Optimization(float version)
        {
            return currentVersion >= version;
        }

        public string TypeOfProgram(string type)
        {
            return $"{appName} is a {type} app for {platform}.";
        }

        public bool RelaeseNewVersion(float version)
        {
            if (version > latestVersion)
            {
                latestVersion = version;
                return true;
            }
            return false;
        }

        public bool ProvideTechnicalSupport()
        {
            return hasPremium;
        }

        public bool EnablePremiumFeatures()
        {
            if (!hasPremium)
            {
                hasPremium = true;
                return true;
            }
            return false;
        }

        public string CheckPlatformCompatibility(string deviceOS)
        {
            return platform == deviceOS ? "Compatible with your device!" : "Not supported on your device.";
        }
    }
    
    public interface IProgramProduct
    {
        bool Optimization(float version);
        string TypeOfProgram(string type);
    }

    public interface IDeveloper
    {
        bool RelaeseNewVersion(float version);
        bool ProvideTechnicalSupport();
    }
}