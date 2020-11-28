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
        Order order;
        OrderRepository orderRepository;


        public CardPaymentPage(Order order)
        {
            InitializeComponent();
            orderRepository = App.repositoryController.GetOrderRepository();

            webcam.CameraIndex = 0;
            this.order = order;
            price.Text = "총 금액 : " + allPrices() + "원";
        }
        private void webcam_QrDecoded(object sender, string e)
        {
            tbRecog.Text = "인식된 카드번호 : " + e;


            if (!order.IsTakeout)
            {
                order.Seat.UsedTime = DateTime.Now;
            }

            order.Payment = new Model.Payment()
            {
                PaymentTime = DateTime.Now,
                UserCode = e,
                paymentType = PayMentType.Card
            };


            var orderIdx = orderRepository.SaveOrder(order);

            if (orderIdx != -1)
            {
                order.Index = orderIdx;
                NavigationService.Navigate(new FinishPaymentPage(order));
            }
            else
            {
                MessageBox.Show("주문 실패");
            }
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

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
