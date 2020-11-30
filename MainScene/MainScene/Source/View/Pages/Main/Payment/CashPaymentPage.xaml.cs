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
        private readonly Order order;
        private readonly OrderRepository orderRepository;
        
        public CashPaymentPage(Order order)
        {
            InitializeComponent();
            orderRepository = App.repositoryController.GetOrderRepository();
            this.order = order;

            SetupView();
        }

        private void SetupView()
        {
            price.Text = "총 금액 : " + order.GetTotalPrice() + "원";
            tbCash.Focusable = true;
            tbCash.Focus();
        }

        private void FinishPayment_Click(object sender, RoutedEventArgs e)
        {
            var orderIdx = Order(tbCash.Text);

            if (orderIdx == -1)
            {
                MessageBox.Show("주문 실패");
                return;
            }

            order.Index = orderIdx;
            NavigationService.Navigate(new FinishPaymentPage(order));
        }

        private int Order(string userCode)
        {
            if (!order.IsTakeout) { order.Seat.UsedTime = DateTime.Now; }

            order.Payment = new Model.Payment()
            {
                PaymentTime = DateTime.Now,
                paymentType = PayMentType.Card,
                UserCode = userCode
            };

            return orderRepository.SaveOrder(order);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
