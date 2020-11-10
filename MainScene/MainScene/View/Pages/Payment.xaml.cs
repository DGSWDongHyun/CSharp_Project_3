using MainScene.Model;
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

namespace MainScene.View.Pages
{
    
    public partial class Payment : Page
    {
        Order order;
        public Payment(Model.Table table,Order order)
        {
            InitializeComponent();
            this.order = order;
            lbSelected.ItemsSource = order.Products;
        }
        private void PaymentCard(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new CardPayment(order));
        }
        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }

}
