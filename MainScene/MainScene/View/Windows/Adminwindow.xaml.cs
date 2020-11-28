using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using MainScene.Util;
using MainScene.Repository;
using System.Windows.Navigation;

namespace MainScene.View.Windows
{
    /// <summary>
    /// Adminwindow.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class Adminwindow : Window
    {
        private Stopwatch DriveTime;

        private SettlementRepository settlementRepository = App.repositoryController.GetSettlementRepository();

        public Adminwindow(Stopwatch driveTime)
        {
            InitializeComponent();
            DriveTime = driveTime;

            SetUpBaseSet();
            SetUpView();


            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromMilliseconds(500);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가
            timer.Start();                                       //타이머 시작. 종료는 timer.Stop(); 으로 한다
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DriveTimeLabel.Content = DriveTime.Elapsed;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string datePart = dt.ToString("yyyy-MM-dd hh:mm:ss");
            lb_Time.Content = datePart;
        }

        private void SetUpBaseSet()
        {
            WindowStyle = WindowStyle.None; //Window의 타이틀, 버튼(Minimized, Maximized 등) 제거
            WindowState = WindowState.Maximized; // 모니터의 해상도 크기로 변경
            ResizeMode = ResizeMode.NoResize; // Window의 크기를 변경 불가s
        }

        private void SetUpView()
        {
            SetDriveTime();
            SetTotalSales();
            SetDiscount();
            SetSales();
            SetCardSales();
            SetCacheSales();

            //datePicker1.SelectedDate = DateTime.Now;
        }


        public void SetDriveTime()
        {
            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromMilliseconds(500);    //시간간격 설정
            timer.Tick += new EventHandler(TimerTick);          //이벤트 추가
            timer.Start();
        }
        
        public void SetTotalSales()
        {
            TotalSales.Content = settlementRepository.GetTotalSales();
        }
        
        public void SetDiscount()
        {
            DiscountLabel.Content = settlementRepository.GetDiscount();
        }
        
        public void SetSales()
        {
            Sales.Content = settlementRepository.GetSales();
        }

        public void SetCardSales()
        {
            CardSales.Content = settlementRepository.GetCardSales();
        }
        
        public void SetCacheSales()
        {
            CacheSales.Content = settlementRepository.GetCacheSales();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate( new Uri("View/Pages/Admin/ByMenu.xaml", UriKind.Relative));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(new Uri("View/Pages/Admin/BySeat.xaml", UriKind.Relative));
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(new Uri("View/Pages/Admin/ByCategory.xaml", UriKind.Relative));
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = true;
            frame.Navigate(new Uri("View/Pages/Admin/ByDate.xaml", UriKind.Relative));
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(new Uri("View/Pages/Admin/ByMember.xaml", UriKind.Relative));
        }

        private void HomeButton_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void AdminDiscount(object sender, RoutedEventArgs e)
        {
            ProductManagerWindow DiscountWindow = new ProductManagerWindow();

            DiscountWindow.ShowDialog();
        }
    }
}