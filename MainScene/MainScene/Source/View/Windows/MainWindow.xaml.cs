using MainScene.Repository;
using MainScene.Source.Data.Model;
using MainScene.Source.Data.NetWorkManager;
using MainScene.Source.View.Pages;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, ReciveHandler
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch;
        string currentTime = string.Empty;
        SystemRepository systemRepository = App.repositoryController.GetSystemRepository();
        AuthNetWorkManager authNetWorkManager = App.netWorkManagerController.GetAuthNetWorkManager();
        SettlementRepository settlementRepository = App.repositoryController.GetSettlementRepository();
        OrderNetWorkManager orderNetWorkManager = App.netWorkManagerController.GetOrderNetWorkManager();

        public MainWindow()
        {
            InitializeComponent();
            var tempSystemRunningTime = systemRepository.GetRunningTime();

            stopWatch = tempSystemRunningTime == null ? new Stopwatch() : tempSystemRunningTime;

            stopWatch.Start();

            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromMilliseconds(500);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가
            timer.Start();                                       //타이머 시작. 종료는 timer.Stop(); 으로 한다
        }


        private void Exit(object sender, CancelEventArgs e)
        {
            systemRepository.SaveRunningTime(stopWatch);
        }


        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string datePart = dt.ToString("yyyy-MM-dd hh:mm:ss");
            lb_Time.Content = datePart;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F2)
            {
                    if (!FrameNavigation.CanGoBack)
                    {
                        if ((Properties.Settings.Default.LoginId != "manager"))
                        {
                            LoginWindow((int)LoginWindowModel.Model.adminModel);
                        }
                        else
                        {
                            Window win2 = new AdminWindow(stopWatch);
                            win2.ShowDialog();
                        }
                    }
                    e.Handled = true;

             
            }



        }

        private void LoginWindow(int ModelNum)
        {
          
                LoginWindow LoginWindow = new LoginWindow(stopWatch, ModelNum);
                LoginWindow.ShowDialog();
            


        }

        public void Login()
        {
            authNetWorkManager.Connect();
            authNetWorkManager.PostLogin();

            Thread reciverThread = new Thread(() => authNetWorkManager.Recive(this));
            reciverThread.Start();
        }

        private void HomeButton_Click_1(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (FrameNavigation.CanGoBack)
                {
                    
                    if (FrameNavigation.CurrentSource == PagesURI.HomePage.Value)
                    {
                        break;
                    }


                    FrameNavigation.GoBack();
                } else
                {
                    break;
                }
            }
        }

        public void ReciveData(string data)
        {
            if (data.Contains("총매출액"))
            {
                orderNetWorkManager.PostTotalSalse("총 매출액 : " + settlementRepository.GetTotalSales().ToString());
                MessageBox.Show("총매출액 전송완료");
            }
            else
            {
                MessageBox.Show(data);
            }
        }
    }

}
