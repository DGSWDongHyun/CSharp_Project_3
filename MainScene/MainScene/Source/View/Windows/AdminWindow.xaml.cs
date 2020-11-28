using MainScene.Repository;
using MainScene.Source.View.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// Adminwindow.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class AdminWindow : Window
    {
        private Stopwatch DriveTime;

        private SettlementRepository settlementRepository = App.repositoryController.GetSettlementRepository();

        public AdminWindow(Stopwatch driveTime)
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

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(PagesURI.BySeatPage.Value);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(PagesURI.ByCategoryPage.Value);
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = true;
            frame.Navigate(PagesURI.ByDatePage.Value);
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            //datePicker1.IsEnabled = false;
            frame.Navigate(PagesURI.ByMemberPage.Value);
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