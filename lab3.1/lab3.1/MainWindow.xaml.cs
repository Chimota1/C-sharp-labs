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

namespace lab3._1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Process_Click(object sender, RoutedEventArgs e)
        {
            string text = InputBox.Text;
            char[] word = text.ToCharArray();

            newWord(word);                     

            ResultBlock.Text = new string(word);
        }

        private void newWord(char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] >= 'A' && word[i] <= 'Z')
                {
                    if (i != 0 && char.IsUpper(word[i]))
                    {
                        word[i - 1] = ' ';
                    }
                }
            }
        }
    }
}