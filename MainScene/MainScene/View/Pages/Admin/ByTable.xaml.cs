using MainScene.Model;
using MainScene.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MainScene.View.Pages.Admin
{
    /// <summary>
    /// ByTable.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByTable : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private TableRepository tableRepository = App.repositoryController.GetTableRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();

        List<Model.Seat> tableList;
        List<Order> orderList;
        List<Product> productList;
        List<Product> productListByTable;

        public ByTable()
        {
            InitializeComponent();

            setupData();
            setupView();
        }

        private void setupData()
        {
            tableList = tableRepository.GetTable();
            orderList = orderRepository.GetOrderHistoryList();
            productList = productRepository.GetProduct();
        }

        private void setupView()
        {
            lbTable.ItemsSource = tableList;
            lbTable.SelectedIndex = 0;
        }

        private void lbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Seat table = lbTable.SelectedItem as Model.Seat;

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
            List<Order> orderListByTable = orderList.Where(x => x.Seat.tablenum == table.tablenum).ToList();

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
