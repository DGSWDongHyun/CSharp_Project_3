using LiveCharts;
using LiveCharts.Wpf;
using MainScene.Model;
using MainScene.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace MainScene.Source.View.Pages.Admin
{
    /// <summary>
    /// ByDate.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByDatePage : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();

        List<Order> orderListByDate;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ByDatePage()
        {
            InitializeComponent();

            datePicker.SelectedDate = DateTime.Now;
            SetupData();
            SetupView();
        }

        private void SetupData()
        {
            orderListByDate = orderRepository.GetOrderListByDate(datePicker.SelectedDate.Value);
        }

        private void SetupView()
        {
            InitGraph();
        }

        private int GetTotalMargin()
        {
            int tempTotalMargin = 0;
            foreach (Order order in orderListByDate)
            {
                tempTotalMargin += order.GetTotalPrice();
            }

            return tempTotalMargin;
        }

        private int GetAmMargin()
        {
            int tempAmMargin = 0;
            foreach (Order order in orderListByDate)
            {
                if (order.Payment.PaymentTime.ToString("tt", CultureInfo.CreateSpecificCulture("en-US")).Equals("AM"))//오전인가?
                {
                    tempAmMargin += order.GetTotalPrice();
                }
            }

            return tempAmMargin;
        }

        private int GetPmMargin()
        {
            int tempPmMargin = 0;
            foreach (Order order in orderListByDate)
            {
                if (order.Payment.PaymentTime.ToString("tt", CultureInfo.CreateSpecificCulture("en-US")).Equals("PM"))//오후인가?
                {
                    tempPmMargin += order.GetTotalPrice();
                }
            }

            return tempPmMargin;
        }

        private void InitGraph()
        {
            int totalAM = GetAmMargin();
            int totalPM = GetPmMargin();
            int totalEarn = GetTotalMargin();

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "시간대 별 총 매출액",
                    Values = new ChartValues<int> { totalPM, totalAM, totalEarn }
                }
            };

            Labels = new[] { "오후", "오전", "총 매출액" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        private void UpdateGraph()
        {
            if (SeriesCollection != null)
            {
                SeriesCollection[0].Values.Clear();

                int totalAM = GetAmMargin();
                int totalPM = GetPmMargin();
                int totalEarn = GetTotalMargin();

                SeriesCollection[0].Values.Add(totalEarn);
                SeriesCollection[0].Values.Add(totalAM);
                SeriesCollection[0].Values.Add(totalPM);

                Labels = new[] { "오후", "오전", "총 매출액" };
                Formatter = value => value.ToString("N");

                DataContext = this;
            }
        }

        private void Dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGraph();
        }
    }
}
