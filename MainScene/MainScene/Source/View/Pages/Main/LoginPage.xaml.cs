using MainScene.Source.Data.Util;
using MainScene.widget;
using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
            {
                ConnectServer();

                NavigationService.Navigate(PagesURI.HomePage.Value);
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다.");
            }
        }

        private void ConnectServer()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                try
                {
                    App.tcpClient = new TcpClient();
                    var result = App.tcpClient.BeginConnect(Constants.SERVER_URL, Constants.SERVER_PORT, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(1000, false);

                    if (success)
                        App.tcpClient.EndConnect(result);
                    else
                        throw new Exception();
                }
                catch
                {
                    NotificationMessage toast = new NotificationMessage();
                    toast.ShowNotification("서버 에러", "서버가 연결되어 있지 않습니다");
                }
            }
        }

    }
}
