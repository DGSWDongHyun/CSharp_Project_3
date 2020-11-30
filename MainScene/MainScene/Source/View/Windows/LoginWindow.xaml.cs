using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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
        private readonly Stopwatch stopWatch;
        private readonly LoginViewType loginViewType;

        private readonly string Admin_ID = "manager";
        private readonly string Admin_PW = "1234";

        private readonly string Launch_ID = "manager2";
        private readonly string Launch_PW = "12345";

        public LoginWindow(Stopwatch stopWatch, LoginViewType loginViewType)
        {
            InitializeComponent();
            this.stopWatch = stopWatch;
            this.loginViewType = loginViewType;

            StorageGet();
        }

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            switch(loginViewType)
            {
                case LoginViewType.LunchLogin:
                    SetupLunchLoginView();
                    return;
                case LoginViewType.AdminLogin:
                    SetupAdminLoginView();
                    return;
            }
        }

        private void SetupLunchLoginView()
        {
            if (!(idTextBox.Text == Launch_ID && passwordTextBox.Text == Launch_PW))
            {
                MessageBox.Show("로그인에 실패했습니다.");
                return;
            }

            if (check.IsChecked == true) { StorageSave(); }
            
            Window.GetWindow(this).Close();
            (App.Current.MainWindow as MainWindow).LoginToServer();
        }

        private void SetupAdminLoginView()
        {
            if (!(idTextBox.Text == Admin_ID && passwordTextBox.Text == Admin_PW))
            {
                MessageBox.Show("로그인에 실패했습니다.");
                return;
            }

            if (check.IsChecked == true) { StorageSave(); }
            Window.GetWindow(this).Close();

            Window win2 = new AdminWindow(stopWatch);
            win2.ShowDialog();
        }

        private void StorageSave()
        {
            if (loginViewType == LoginViewType.LunchLogin)
            {
                Properties.Settings.Default.LoginIdOnPage = idTextBox.Text;
                Properties.Settings.Default.IsCheckedOnPage = check.IsEnabled;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.LoginId = idTextBox.Text;
                Properties.Settings.Default.IsChecked = check.IsEnabled;
                Properties.Settings.Default.Save();
            }
        }

        private void StorageGet()
        {
            if (loginViewType == LoginViewType.LunchLogin)
            {
                if (Properties.Settings.Default.LoginIdOnPage == "manager2" && Properties.Settings.Default.IsCheckedOnPage == true)
                {
                    Window.GetWindow(this).Close();
                }
            }
            else
            {
                if (Properties.Settings.Default.LoginId == "manager" && Properties.Settings.Default.IsChecked == true)
                {
                    Window.GetWindow(this).Close();
                    Window win2 = new AdminWindow(stopWatch);
                    win2.ShowDialog();
                }
            }

        }
    }

    public enum LoginViewType
    {
        LunchLogin,
        AdminLogin
    }
}