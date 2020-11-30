using LiveCharts;
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
        private readonly OrderRepository orderRepository = App.repositoryController.GetOrderRepository();

        private Dictionary<CategoryEnum, List<Product>> orderedProductByCategory;
        private readonly SeriesCollection piechartData = new SeriesCollection();

        public ByCategoryPage()
        {
            InitializeComponent();

            SetupData();
            SetupView();
        }

        private void SetupView()
        {
            InitGraph();
            lbCategory.SelectedIndex = 0; //첫번째 카테고리 선택
        }

        private void SetupData()
        {
            DataContext = this;
            orderedProductByCategory = orderRepository.GetOrderedProductByCategory();
        }

        private void InitGraph()
        {
            piechart.Series = new SeriesCollection
            {

               new PieSeries
               {
                Title = "버거",
                Values = new ChartValues<double> { orderedProductByCategory[CategoryEnum.Bugger].Count },
                DataLabels = true,
                },
                new PieSeries
                {
                    Title = "음료",
                    Values = new ChartValues<double> { orderedProductByCategory[CategoryEnum.Drink].Count },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "사이드 메뉴",
                    Values = new ChartValues<double> { orderedProductByCategory[CategoryEnum.Side].Count },
                    DataLabels = true,
                  },
            };
        }

        private void UpdateGraph(List<Product> products)
        {
            piechart_cell.Series.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Count != 0 && CheckDuplicateItem(products[i], i, products))
                {
                    piechartData.Add(new PieSeries
                    {
                        Title = products[i].name,
                        Values = new ChartValues<double> { products[i].Count },
                        DataLabels = true,
                    });
                }
            }
            piechart_cell.Series = piechartData;

        }

        private int GetMarginByCategory(CategoryEnum categoryEnum)
        {
            int totalMargin = 0;
            foreach (Product product in orderedProductByCategory[categoryEnum])
            {
                totalMargin += product.FinalPrice;
            }
            return totalMargin;
        }

        private void UpdateStatisticsInfo(CategoryEnum categoryEnum)
        {
            int totalMargin = GetMarginByCategory(categoryEnum);
            int totalCellCount = orderedProductByCategory[categoryEnum].Count;

            statisticsInfo.Text = ("총" + totalCellCount + "개 판매, 총" + totalMargin + "원");
        }

        private bool CheckDuplicateItem(Product product, int index, List<Product> products)
        {
            for(int i = 0; i < index; i++)
            {
                if(products[i].name == product.name)
                {
                    continue;
                }
            }

            for(int i = index; i < products.Count; i++)
            {
                if(products[i].name == product.name)
                {
                    continue;
                }
            }
            return true;
        }

        private void LbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedIndex = (sender as ListBox).SelectedIndex;

            UpdateStatisticsInfo((CategoryEnum)SelectedIndex);
            UpdateGraph(orderedProductByCategory[(CategoryEnum)SelectedIndex]);
        }
    }
}
