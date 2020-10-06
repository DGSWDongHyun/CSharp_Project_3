using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;
using System.Windows.Navigation;

namespace MainScene
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
            if(e.Key == System.Windows.Input.Key.F2)
            {
                if(FrameNavigation.CanGoBack )//chris, 페이지1에서만 관리자페이지로 이동할 수 있도록 처리
                {
                    e.Handled = true;
                    //do nothing!!
                }


                //FrameNavigation.Source = new Uri("AdminPage.xaml", UriKind.Relative);

            }

            
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigation.Source = new Uri("Page1.xaml", UriKind.Relative);
        }
    }
    
}
