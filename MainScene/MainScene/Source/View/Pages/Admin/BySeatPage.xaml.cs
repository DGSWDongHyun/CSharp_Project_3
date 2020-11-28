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
        List<Order> orderList;
        List<Product> productList;
        List<Product> productListByTable;

        public BySeatPage()
        {
            InitializeComponent();

            setupData();
            setupView();
        }

        private void setupData()
        {
            seatList = tableRepository.GetSeatList();
            orderList = orderRepository.GetOrderHistoryList();
            productList = productRepository.GetProduct();
        }

        private void setupView()
        {
            lbSeat.ItemsSource = seatList;
            lbSeat.SelectedIndex = 0;
        }

        private void lbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Seat table = lbSeat.SelectedItem as Model.Seat;

            lbMenus.ItemsSource = mappingCellCount(orderList, table);


            int totalMargin = 0;
            foreach (Product product in productListByTable)
            {
                totalMargin += product.Price;
            }

            statisticsInfo.Text = "총" + productListByTable.Count + "개 판매, 총" + totalMargin + "원";
        }

        private List<Product> mappingCellCount(List<Order> orderList, Model.Seat table)
        {
            productList = productRepository.GetProduct();
            List<Order> orderListByTable = orderList
                .Where(x => !x.IsTakeout)
                .Where(x => x.Seat.seatNum == table.seatNum).ToList();

            productListByTable = new List<Product>();

            foreach (Order order in orderListByTable)
            {
                productListByTable.AddRange(order.Products);
            }

            foreach (Product product in productList)
            {
                product.TotalCellCount = productListByTable.Where(x => x.name == product.name).Count();
                product.TotalCellPriceCount = product.TotalCellCount * product.Price;
            }


            return productList;
        }
    }
}
