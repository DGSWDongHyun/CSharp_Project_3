using MainScene.Model;
using MainScene.Repository;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main.Payment
{
    /// <summary>
    /// CardPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPaymentPage : Page
    {
        private readonly Order order;
        private readonly OrderRepository orderRepository;

        public CardPaymentPage(Order order)
        {
            InitializeComponent();
            orderRepository = App.repositoryController.GetOrderRepository();
            this.order = order;

            webcam.CameraIndex = 0;

            SetupView();
        }

        private void SetupView()
        {
            price.Text = "총 금액 : " + order.GetTotalPrice() + "원";
        }

        private void Webcam_QrDecoded(object sender, string e)
        {

            tbRecog.Text = "인식된 카드번호 : " + e;

            var orderIdx = Order(e);

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
