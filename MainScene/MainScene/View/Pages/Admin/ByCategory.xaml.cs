using MainScene.Model;
using MainScene.Repository;
using System;
using System.Collections;
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
    /// ByCategory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByCategory : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();

        Dictionary<CategoryEnum, List<Product>> dividedProductList;
        List<Product> productList;

        public ByCategory()
        { 
            InitializeComponent();
            DataContext = this;
            dividedProductList = DivideProductListByCategory(orderRepository.GetOrderHistoryList());
            productList = productRepository.GetProduct();

            SetupView();
        }

        private void SetupView()
        {
            lbCategory.SelectedIndex = 0;
        }

        private Dictionary<CategoryEnum, List<Product>> DivideProductListByCategory(List<Order> orderHistoryList)
        {
            Dictionary<CategoryEnum, List<Product>> tempDividedOrderHistoryList = new Dictionary<CategoryEnum, List<Product>>();

            //Eum의 길이
            int length = System.Enum.GetValues(typeof(CategoryEnum)).Length;

            //orderList to product mapping
            List<Product> tempProductList = new List<Product>();
            
            foreach (Order order in orderHistoryList)
            {
                tempProductList.AddRange(order.Products);
            }
            
            //divide products by category
            int count = 0;
            while (count <= length)
            {
                CategoryEnum tempCategoryEnum = (CategoryEnum) count;

                List<Product> dividedProductList = tempProductList.Where(x => x.Category == tempCategoryEnum).ToList();

                tempDividedOrderHistoryList.Add(tempCategoryEnum, dividedProductList);

                count++;
            }

            return tempDividedOrderHistoryList;
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);

            if (lbi.Content.ToString() == "버거")
            {
                int totalMargin = 0;
                foreach (Product product in dividedProductList[CategoryEnum.Bugger])
                {
                    totalMargin += product.Price;
                }
                
                statisticsInfo.Text = "총" + dividedProductList[CategoryEnum.Bugger].Count + "개 판매, 총" + totalMargin + "원";

                lbMenus.ItemsSource = mappingCellCount(productList, CategoryEnum.Bugger);
            }
            else if (lbi.Content.ToString() == "음료")
            {
                int totalMargin = 0;
                foreach (Product product in dividedProductList[CategoryEnum.Drink])
                {
                    totalMargin += product.Price;
                }

                statisticsInfo.Text = "총" + dividedProductList[CategoryEnum.Drink].Count + "개 판매, 총" + totalMargin + "원";


                lbMenus.ItemsSource = mappingCellCount(productList, CategoryEnum.Drink);
            }
            else if (lbi.Content.ToString() == "사이드 메뉴")
            {
                int totalMargin = 0;
                foreach (Product product in dividedProductList[CategoryEnum.Side])
                {
                    totalMargin += product.Price;
                }

                statisticsInfo.Text = "총" + dividedProductList[CategoryEnum.Side].Count + "개 판매, 총" + totalMargin + "원";


                lbMenus.ItemsSource = mappingCellCount(productList, CategoryEnum.Side);
            }
        }

        private List<Product> mappingCellCount(List<Product> productList, CategoryEnum category)
        {
            var categoryMenuList = productList.Where(x => x.Category == category).ToList();

            foreach (Product product in categoryMenuList)
            {
                product.TotalCellCount = dividedProductList[category].Where(x => x.name == product.name).ToList().Count();
                product.TotalCellPriceCount = product.TotalCellCount * product.Price;
            }

            return categoryMenuList;
        }
    }
}
