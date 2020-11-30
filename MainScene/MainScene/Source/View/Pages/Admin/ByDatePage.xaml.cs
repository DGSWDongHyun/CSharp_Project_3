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

        SeriesCollection piechartData;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

        public ByDatePage()
        {
            InitializeComponent();
            SetupView();
        }

        private void SetupData(DateTime date)
        {
            orderListByDate = orderRepository.GetOrderListByDate(date);
        }

        private void SetupView()
        {
            datePicker.SelectedDate = DateTime.Now;
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

        private void SetupGraph()
        {
            piechart_cell.Series = new SeriesCollection
            {
                 new PieSeries
                 {
                   Title = "오전",
                   Values = new ChartValues<int> { GetAmMargin() },
                   DataLabels = true,
                },
                new PieSeries
                {
                    Title = "오후",
                    Values = new ChartValues<int> { GetPmMargin() },
                    DataLabels = true,
                },
            };
        }

        private void Dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetupData((sender as DatePicker).SelectedDate.Value);
            SetupGraph();
        }
    }
}
