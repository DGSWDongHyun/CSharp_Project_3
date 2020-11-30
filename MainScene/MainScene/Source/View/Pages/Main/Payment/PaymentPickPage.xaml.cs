using MainScene.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main.Payment
{

    public partial class PaymentPickPage : Page
    {
        private readonly Order order;

        public PaymentPickPage(Order order)
        {
            InitializeComponent();
            this.order = order;
            SetupView();
        }

        private void SetupView()
        {
            lbSelected.ItemsSource = order.Products;

            if (order.Seat != null)
            {
                tabletest.Content = "테이블 번호 : " + order.Seat.seatNum;
            }
            else
            {
                tabletest.Content = "포장 식사";
            }
        }

        private void PaymentCard(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new CardPaymentPage(order));
        }

        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PaymentCash(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CashPaymentPage(order));
        }
    }

}
