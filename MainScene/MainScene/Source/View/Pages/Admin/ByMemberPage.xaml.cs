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

        public ByMemberPage()
        {
            InitializeComponent();

            SetupData();
            SetupView();
        }

        private void SetupData()
        {
            orderHistoryList = orderRepository.GetOrderHistoryList();
            orderedUserCodeList = orderRepository.GetOrderedUserCodeList();
        }

        private void SetupView()
        {
            lbMember.ItemsSource = orderedUserCodeList;
            lbMember.SelectedIndex = 0;
        }

        private void LbMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string userCode = lbMember.SelectedItem as string;
            var productListByUser = orderRepository.GetOrderedProductListByUser(userCode);

            int totalMargin = 0;
            int totalCount = 0;
            foreach (Product product in productListByUser)
            {
                totalMargin += product.Count > 0 ? product.TotalCellPrice : 0;
                totalCount += product.Count;
            }
            
            statisticsInfo.Text = "총" + totalCount + "개 판매, 총" + totalMargin + "원";
            lbMenus.ItemsSource = productListByUser;
        }
    }
}
