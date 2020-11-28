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

namespace MainScene.Source.View.Pages.Main
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

        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            storageGet(); 
            this.NavigationService.LoadCompleted -= new LoadCompletedEventHandler(NavigationService_LoadCompleted);
        }

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
            {
               if(check.IsChecked == true)
                {
                    storageSave();
                    NavigationService.Navigate(PagesURI.HomePage.Value);
                }
                else
                {
                    NavigationService.Navigate(PagesURI.HomePage.Value);
                }
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다.");
            }
        }

        private void storageSave()
        {
            Properties.Settings.Default.LoginIdOnPage = idTextBox.Text;
            Properties.Settings.Default.IsCheckedOnPage = check.IsEnabled;
            Properties.Settings.Default.Save();
        }

        private void storageGet()
        {
            if (Properties.Settings.Default.LoginIdOnPage == "manager" && Properties.Settings.Default.IsCheckedOnPage == true)
            {
               
                // NavigationService.Navigate(PagesURI.HomePage.Value);
              
            }
        }

    }
}
