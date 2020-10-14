using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MainScene.View.Windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;

          public MainWindow()
        {
            InitializeComponent();

            stopWatch.Start();

            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromMilliseconds(500);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가
            timer.Start();                                       //타이머 시작. 종료는 timer.Stop(); 으로 한다
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
                if (!FrameNavigation.CanGoBack)//chris, 페이지1에서만 관리자페이지로 이동할 수 있도록 처리
                {
                    Window win2 = new Adminwindow(stopWatch);
                    win2.ShowDialog();
                }

                e.Handled = true;
                

            }


        }

     

        private void HomeButton_Click_1(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!FrameNavigation.CanGoBack)
                {
                    break;
                }
                else
                {
                    FrameNavigation.GoBack();
                }
            }
        }
    }

}
