using MainScene.Model;
using MainScene.Repository;
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

namespace MainScene.View.Pages.Admin
{
    /// <summary>
    /// ByDate.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByDate : Page
    {

        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();

        List<Product> divideProductList;
        DateTime dateTime = DateTime.Now;

        public ByDate()
        {
            InitializeComponent();
            divideProductList = DivideProductListByDate(orderRepository.GetOrderHistoryList(), dateTime);
        }

        private List<Product> DivideProductListByDate(List<Order> orderHistoryList, DateTime date)
        {
            List<Product> tempDivideProductList = new List<Product>();


            var orderlist = orderHistoryList.Where(x => x.Payment.PaymentTime.Year == date.Year &&
                                                        x.Payment.PaymentTime.Month == date.Month &&
                                                        x.Payment.PaymentTime.Day == date.Day).ToList();


            foreach (Order order in orderlist)
            {
                tempDivideProductList.AddRange(order.Products);
            }
            
            return tempDivideProductList;
        }
    }
}
