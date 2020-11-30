using MainScene.Model;
using MainScene.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MainScene.Source.View.Pages.Admin
{
    /// <summary>
    /// ByMember.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByMemberPage : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();

        List<string> orderedUserCodeList;
        List<Order> orderHistoryList;
        List<Product> productList;

        public ByMemberPage()
        {
            InitializeComponent();

            orderHistoryList = orderRepository.GetOrderHistoryList();

            orderedUserCodeList = GetOrderedUserCodeList(orderHistoryList);

            setupView();
        }


        private void setupView()
        {
            lbMember.ItemsSource = orderedUserCodeList;
            lbMember.SelectedIndex = 0;
        }


        private void lbMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string userCode = lbMember.SelectedItem as string;

            var productLisyByMember = GetDividedProductList(userCode, orderHistoryList);

            productList = productRepository.GetProduct();


            int totalMargin = 0;
            foreach (Product product in productLisyByMember)
            {
                totalMargin += product.Price;
            }

            statisticsInfo.Text = "총" + productLisyByMember.Count + "개 판매, 총" + totalMargin + "원";

            lbMenus.ItemsSource = productList;
        }

        private List<Product> GetDividedProductList(string userCode, List<Order> orderHistoryList)
        {
            List<Product> orderedProductList = new List<Product>();

            var devidedOrderList = orderHistoryList.Where(x => x.Payment.UserCode.Equals(userCode)).ToList();

            foreach (var devidedOrder in devidedOrderList)
            {
                orderedProductList.AddRange(devidedOrder.Products);
            }
            return orderedProductList;
        }

        private List<string> GetOrderedUserCodeList(List<Order> orderHistoryList)
        {
            List<string> orderedUserCodeList = new List<string>();
            List<string> tempOrderedUserCodeList = new List<string>();

            foreach (Order order in orderHistoryList)
            {
                tempOrderedUserCodeList.Add(order.Payment.UserCode);
            }

            return tempOrderedUserCodeList.Distinct().ToList();
        }
    }
}
