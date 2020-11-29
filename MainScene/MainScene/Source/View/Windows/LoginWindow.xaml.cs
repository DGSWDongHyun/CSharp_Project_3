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
using MainScene.Source.Data.Model;

namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        Stopwatch stopWatch;
        int ModelNum = 0;
        public LoginWindow(Stopwatch stopWatch, int ModelNum)
        {
            InitializeComponent();
            this.stopWatch = stopWatch;
            this.ModelNum = ModelNum;

            storageGet();
        }

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if (ModelNum == (int)LoginWindowModel.Model.initModel)
            {
                if (idTextBox.Text == "manager2" && passwordTextBox.Text == "12345")
                {
                    if (check.IsChecked == true)
                    {
                        storageSave();
                        (App.Current.MainWindow as MainWindow).Login();
                    }

                }
                else
                {
                    MessageBox.Show("로그인에 실패했습니다.");

                }
            }
            else
            {
                if (idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
                {
                    if (check.IsChecked == true)
                    {
                        storageSave();
                    }
                    Window win2 = new AdminWindow(stopWatch);
                    win2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("로그인에 실패했습니다.");

                }
            }

        }

        private void storageSave()
        {
            if (ModelNum == (int)LoginWindowModel.Model.initModel)
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
            Window.GetWindow(this).Close();
        }

        private void storageGet()
        {
            if (ModelNum == (int)LoginWindowModel.Model.initModel)
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
}