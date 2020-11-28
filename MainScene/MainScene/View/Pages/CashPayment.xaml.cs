using MainScene.Model;
using MainScene.View.Pages;
using System;
using System.Collections.Generic;
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
using MainScene.Repository;

namespace MainScene.View 
{ 

    /// <summary>
    /// CashPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashPayment : Page
    {
        Order order;
        OrderRepository orderRepository;
        public CashPayment(Order order)
        {
            InitializeComponent();
            orderRepository = App.repositoryController.GetOrderRepository();

            this.order = order;
            price.Text = "총 금액 : " + allPrices() + "원";
            tbCash.Focusable = true;
            tbCash.Focus();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private int allPrices()
    {
        int prices = 0;
        for (int i = 0; i < order.Products.Count; i++)
        {
            Product products = order.Products[i];
            prices += (products.FinalPrice * products.Count);
        }
        return prices;
    }

        private void finishPayment_Click(object sender, RoutedEventArgs e)
        {
            //order 저장 구현 (예외처리)
            if (!order.IsTakeout)
            {
                order.Seat.UsedTime = DateTime.Now;
            }
            order.Payment = new Model.Payment()
            {
                PaymentTime = DateTime.Now,
                UserCode = tbCash.Text,
                paymentType = PayMentType.Cache
            };


            var orderIdx = orderRepository.SaveOrder(order);

            if (orderIdx != -1)
            {
                order.Index = orderIdx;
                NavigationService.Navigate(new FinishPayment(order));
            }
            else
            {
                MessageBox.Show("주문 실패");
            }

            NavigationService.Navigate(new FinishPayment(order));
        }
    }
}
