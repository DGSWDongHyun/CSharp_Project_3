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

namespace MainScene.View.Windows
{
    /// <summary>
    /// Adminwindow.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class Adminwindow : Window
    {
        private Stopwatch DriveTime;

        private SettlementRepository settlementRepository = App.repositoryController.GetSettlementRepository();


        public Adminwindow(Stopwatch stopWatch)
        {
            InitializeComponent();
            DataContext = this;
            DriveTime = stopWatch;

            WindowStyle = WindowStyle.None; //Window의 타이틀, 버튼(Minimized, Maximized 등) 제거
            WindowState = WindowState.Maximized; // 모니터의 해상도 크기로 변경
            ResizeMode = ResizeMode.NoResize; // Window의 크기를 변경 불가s

            
            InitData();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DriveTimeLabel.Content = DriveTime.Elapsed;
        }

        private void InitData()
        {
            SetDriveTime();
            SetTotalSales();
            SetDiscount();
            SetSales();
            SetCardSales();
            SetCacheSales();
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
    }
}
