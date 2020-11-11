﻿using MainScene.Model;
using MainScene.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MainScene.View.Pages.Admin
{
    /// <summary>
    /// ByDate.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByDate : Page
    {

        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();

        List<Order> orderListByDate;

        public ByDate()
        {
            InitializeComponent();

            datePicker1.SelectedDate = DateTime.Now;
            setupView();
        }

        private void dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            setupView();
        }

        private void setupView()
        {
            orderListByDate = GetOrderListByDate(orderRepository.GetOrderHistoryList(), datePicker1.SelectedDate.Value);

            totalLabel.Content = GetTotalMargin();
            amLabel.Content = GetAmMargin();
            pmLabel.Content = GetPmMargin();
        }

        private List<Order> GetOrderListByDate(List<Order> orderHistoryList, DateTime date)
        {
            var orderlist = orderHistoryList.Where(x => x.Payment.PaymentTime.Year == date.Year &&
                                                        x.Payment.PaymentTime.Month == date.Month &&
                                                        x.Payment.PaymentTime.Day == date.Day).ToList();


            return orderlist;
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
                if(order.Payment.PaymentTime.ToString("tt", CultureInfo.CreateSpecificCulture("en-US")).Equals("PM"))//오후인가?
                {
                    tempPmMargin += order.GetTotalPrice();
                }
            }

            return tempPmMargin;
        }
    }
}
