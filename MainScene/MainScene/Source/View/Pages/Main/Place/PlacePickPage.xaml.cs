using MainScene.Model;
using MainScene.Source.View.Pages.Main.Payment;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main.Place
{
    /// <summary>
    /// Page3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlacePickPage : Page
    {
        Order order = new Order();
        public PlacePickPage(Order order)
        {
            InitializeComponent();
            this.order = order;
        }


        private void SelectStore(object sender, RoutedEventArgs e)
        {
            order.IsTakeout = true;
            NavigationService.Navigate(new SeatPickPage(order));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Takeout_Click(object sender, RoutedEventArgs e)
        {
            Model.Seat table = new Model.Seat();
            table.seatNum = 0;
            order.IsTakeout = true;
            NavigationService.Navigate(new PaymentPickPage(order));
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

