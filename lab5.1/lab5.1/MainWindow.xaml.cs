using System.IO;
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

namespace lab5._1
{
    using static lab5._1.Bike;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Bike myBike;

        private void InitClick(object sender, RoutedEventArgs e)
        {
                {

                }
                string path = @"D:\\PKPZ\\C-sharp-labs\\lab5.1\\lab5.1\\data.txt";
                InitClass();
                StartButton.Visibility = Visibility.Hidden;
                Mark.Visibility = Visibility.Visible;
                MarkButton.Visibility = Visibility.Visible;
                Name.Visibility = Visibility.Visible;
                NameButton.Visibility = Visibility.Visible;
                Year.Visibility = Visibility.Visible;
                YearButton.Visibility = Visibility.Visible;
                Color.Visibility = Visibility.Visible;
                ColorButton.Visibility = Visibility.Visible;
                WheelDiameter.Visibility = Visibility.Visible;
                WheelButton.Visibility = Visibility.Visible;
                HeightOfSaddle.Visibility = Visibility.Visible;
                SaddleButton.Visibility = Visibility.Visible;
                TypeOfFrame.Visibility = Visibility.Visible;
                FrameButton.Visibility = Visibility.Visible;
                Next.Visibility = Visibility.Visible;
                File.WriteAllText(path, string.Empty);
        }
        

        private void SetMarkBtn(object sender, RoutedEventArgs e)
        {
            string markName = Mark.Text;
            myBike.SetMark(markName);
        }

        private void SetNameBtn(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            myBike.SetName(name);
        }

        private void SetYearBtn(object sender, RoutedEventArgs e)
        {
            string year = Year.Text;
            myBike.SetYear(year);
        }

        private void SetColorBtn(object sender, RoutedEventArgs e)
        {
            string color = Color.Text;
            myBike.SetColor(color);
        }

        private void SetWheelDiameterBtn(object sender, RoutedEventArgs e)
        {
            string wheel = WheelDiameter.Text;
            myBike.SetWheelDiameter(wheel);
        }

        private void SetHeightSaddlelBtn(object sender, RoutedEventArgs e)
        {
            string saddle = HeightOfSaddle.Text;
            myBike.SetHeightOfSaddle(saddle);
        }

        private void SetTypeOfFrameBtn(object sender, RoutedEventArgs e)
        {
            string frame = TypeOfFrame.Text;
            myBike.SetTypeOfFrame(frame);
        }

        private void NextBtn(object sender, RoutedEventArgs e)
        {
            Mark.Visibility = Visibility.Hidden;
            MarkButton.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            NameButton.Visibility = Visibility.Hidden;
            Year.Visibility = Visibility.Hidden;
            YearButton.Visibility = Visibility.Hidden;
            Color.Visibility = Visibility.Hidden;
            ColorButton.Visibility = Visibility.Hidden;
            WheelDiameter.Visibility = Visibility.Hidden;
            WheelButton.Visibility = Visibility.Hidden;
            HeightOfSaddle.Visibility = Visibility.Hidden;
            SaddleButton.Visibility = Visibility.Hidden;
            TypeOfFrame.Visibility = Visibility.Hidden;
            FrameButton.Visibility = Visibility.Hidden;   
            Output.Visibility = Visibility.Visible;
            GetRadiusButton.Visibility = Visibility.Visible;
            FullInfoButton.Visibility = Visibility.Visible;
            AtributtesButton.Visibility = Visibility.Visible;
            AllGetters.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Hidden;
        }

        private void GetRadiusBtn(object sender, RoutedEventArgs e)
        {
          Output.Text = myBike.RadiusOfWheel();
        }

        private void FullInfoBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = myBike.FullInfo();
        }

        private void AtributtesBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = myBike.Atributtes();
        }

        private void GetAllBtn(object sender, RoutedEventArgs e)
        {
            Output.Text = myBike.GetMark() + " " +  myBike.GetName() + " " + myBike.GetColor() + " " + myBike.GetYear() +
                         " " + myBike.GetHeightOfSaddle()+ " " + myBike.GetTypeOfFrame()+ " " + myBike.GetWheelDiameter();
        }
        
        private void InitClass()
        {
            myBike = new Bike();
        }

        private void CheckIfHidden()
        {
        }
    }
}