﻿using LiveCharts;
using LiveCharts.Wpf;
using MainScene.Model;
using MainScene.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MainScene.Source.View.Pages.Admin
{
    /// <summary>
    /// ByCategory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByCategoryPage : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();
        SeriesCollection piechartData;
        Dictionary<CategoryEnum, List<Product>> dividedProductList;
        List<Product> productList;

        public ByCategoryPage()
        {
            InitializeComponent();
            DataContext = this;
            dividedProductList = DivideProductListByCategory(orderRepository.GetOrderHistoryList());
            productList = productRepository.GetProduct();

            InitGraph();
            SetupView();
        }

        private void SetupView()
        {
            lbCategory.SelectedIndex = 0;
            DataContext = this;


        }

        private void InitGraph()
        {

            piechart.Series = new SeriesCollection
            {

               new PieSeries
               {
                Title = "버거",
                Values = new ChartValues<double> {dividedProductList[CategoryEnum.Bugger].Count},
                DataLabels = true,
                },
                new PieSeries
                {
                    Title = "음료",
                    Values = new ChartValues<double> {dividedProductList[CategoryEnum.Drink].Count},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "사이드 메뉴",
                    Values = new ChartValues<double> {dividedProductList[CategoryEnum.Side].Count},
                    DataLabels = true,
                  },
            };

            piechartData = new SeriesCollection
            {


            };
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
                CategoryEnum tempCategoryEnum = (CategoryEnum)count;

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

                UpdateGraph(mappingCellCount(productList, CategoryEnum.Bugger));

            }
            else if (lbi.Content.ToString() == "음료")
            {
                int totalMargin = 0;
                foreach (Product product in dividedProductList[CategoryEnum.Drink])
                {
                    totalMargin += product.Price;
                }

                statisticsInfo.Text = "총" + dividedProductList[CategoryEnum.Drink].Count + "개 판매, 총" + totalMargin + "원";
                UpdateGraph(mappingCellCount(productList, CategoryEnum.Drink));

            }
            else if (lbi.Content.ToString() == "사이드 메뉴")
            {
                int totalMargin = 0;
                foreach (Product product in dividedProductList[CategoryEnum.Side])
                {
                    totalMargin += product.Price;
                }

                statisticsInfo.Text = "총" + dividedProductList[CategoryEnum.Side].Count + "개 판매, 총" + totalMargin + "원";
                UpdateGraph(mappingCellCount(productList, CategoryEnum.Side));
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
        private void UpdateGraph(List<Product> products)
        {
            piechart_cell.Series.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].TotalCellCount != 0)
                {
                    piechartData.Add(new PieSeries
                    {
                        Title = products[i].name,
                        Values = new ChartValues<double> { products[i].TotalCellCount },
                        DataLabels = true,
                    });
                }
            }
            piechart_cell.Series = piechartData;
        }
    }
}
