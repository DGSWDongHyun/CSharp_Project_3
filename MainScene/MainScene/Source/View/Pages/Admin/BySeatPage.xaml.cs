using MainScene.Model;
using MainScene.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MainScene.Source.View.Pages.Admin
{
    /// <summary>
    /// ByTable.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BySeatPage : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private SeatRepository tableRepository = App.repositoryController.GetTableRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();

        List<Seat> seatList;

        public BySeatPage()
        {
            InitializeComponent();

            SetupData();
            SetupView();
        }

        private void SetupData()
        {
            seatList = tableRepository.GetSeatList();
        }

        private void SetupView()
        {
            lbSeat.ItemsSource = seatList;
            lbSeat.SelectedIndex = 0;
        }

        private void LbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seat seat = lbSeat.SelectedItem as Seat;
            var productListByTable = MapOrderToProduct(seat);

            SetupProductView(productListByTable); 
        }

        private void SetupProductView(List<Product> productList)
        {
            lbMenus.ItemsSource = productList;

            int totalMargin = 0;
            int totalCount = 0;
            foreach (Product product in productList)
            {
                totalMargin += product.Count > 0 ? product.TotalCellPrice : 0;
                totalCount += product.Count;
            }

            statisticsInfo.Text = "총" + totalCount + "개 판매, 총" + totalMargin + "원";
        }

        private List<Product> MapOrderToProduct(Seat seat)
        {
            List<Product> productList = productRepository.GetProduct();
            List<Order> orderListByTable = orderRepository.GetOrderListBySeat(seat);

            var productListByTable = new List<Product>();

            foreach (Order order in orderListByTable)
            {
                productListByTable.AddRange(order.Products);
            }

            foreach(Product product in productList)
            {
                product.Count = productListByTable.Where(x => x.name == product.name).Count();
            }

            return productList;
        }
    }
}
