using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainScene.View.Pages.Login
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
            {
                NavigationService.Navigate(new Page1());
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다.");
            }
        }
    }
}
