using MainScene.Repository;
using MainScene.Source.View.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// Adminwindow.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class AdminWindow : Window
    {
        private readonly Stopwatch driveTime;
        private readonly SettlementRepository settlementRepository = App.repositoryController.GetSettlementRepository();


        public AdminWindow(Stopwatch driveTime)
        {
            InitializeComponent();
            this.driveTime = driveTime;

            SetupView();
        }


        private void SetupView()
        {
            WindowStyle = WindowStyle.None; //Window의 타이틀, 버튼(Minimized, Maximized 등) 제거
            WindowState = WindowState.Maximized; // 모니터의 해상도 크기로 변경
            ResizeMode = ResizeMode.NoResize; // Window의 크기를 변경 불가s

            TotalSales.Content = settlementRepository.GetTotalSales();
            DiscountLabel.Content = settlementRepository.GetDiscount();
            Sales.Content = settlementRepository.GetSales();
            CardSales.Content = settlementRepository.GetCardSales();
            CacheSales.Content = settlementRepository.GetCacheSales();

            groupMsgCheckBox.IsChecked = Properties.Settings.Default.isGroupMsg;

            SetupTime();
        }


        private void SetupTime()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //구동시간
            DriveTimeLabel.Content = driveTime.Elapsed;

            //현재시각
            DateTime dt = DateTime.Now;
            string datePart = dt.ToString("yyyy-MM-dd hh:mm:ss");
            lb_Time.Content = datePart;
        }


        private void BySeatPageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(PagesURI.BySeatPage.Value);
        }

        private void ByCategoryPageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(PagesURI.ByCategoryPage.Value);
        }

        private void ByDatePageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(PagesURI.ByDatePage.Value);
        }

        private void ByMemberPageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(PagesURI.ByMemberPage.Value);
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.isGroupMsg = ((CheckBox)sender).IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void ProductManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ProductManagerWindow DiscountWindow = new ProductManagerWindow();

            DiscountWindow.ShowDialog();
        }
    }
}