using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        Stopwatch stopWatch;
        public LoginWindow(Stopwatch stopWatch)
        {
            InitializeComponent();
            this.stopWatch = stopWatch;

            storageGet();  
        }
      
        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
            {
                if (check.IsChecked == true)
                {
                    storageSave();
                    Window win2 = new AdminWindow(stopWatch);
                    win2.ShowDialog(); 
                }
                else
                {
                    Window win2 = new AdminWindow(stopWatch);
                    win2.ShowDialog();
                }
              
            }
        }
      
        private void storageSave()
        {
            Properties.Settings.Default.LoginId = idTextBox.Text;
            Properties.Settings.Default.IsChecked = check.IsEnabled;
            Properties.Settings.Default.Save();
        }

        private void storageGet()
        {
            if(Properties.Settings.Default.LoginId == "manager" && Properties.Settings.Default.IsChecked == true)
            {
                Window win2 = new AdminWindow(stopWatch);
                win2.ShowDialog();
            }
        }
    }
}
