using MainScene.Model;
using MainScene.Repository;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main.Payment
{

    /// <summary>
    /// CashPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashPaymentPage : Page
    {
        Order order;
        OrderRepository orderRepository;
        public CashPaymentPage(Order order)
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
            }
            else
            {
                MessageBox.Show("주문 실패");
                return;
            }

            NavigationService.Navigate(new FinishPaymentPage(order));
        }
    }
}
