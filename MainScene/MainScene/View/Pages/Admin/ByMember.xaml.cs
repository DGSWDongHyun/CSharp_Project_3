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
    /// ByMember.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByMember : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();

        Dictionary<String, List<Product>> dividedProductList;
        List<String> orderedUserCodeList;

        public ByMember()
        {
            InitializeComponent();

            List<Order> orderHistoryList = orderRepository.GetOrderHistoryList();

            orderedUserCodeList = GetOrderedUserCodeList(orderHistoryList);
        }

        private List<String> GetOrderedUserCodeList(List<Order> orderHistoryList)
        {
            List<String> orderedUserCodeList = new List<String>();
            List<String> tempOrderedUserCodeList = new List<String>();

            foreach (Order order in orderHistoryList)
            {
                tempOrderedUserCodeList.Add(order.Payment.UserCode);
            }

            return tempOrderedUserCodeList.Distinct().ToList();
        }
    }
}
