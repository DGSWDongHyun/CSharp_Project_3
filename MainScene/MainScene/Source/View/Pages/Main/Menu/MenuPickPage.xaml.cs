using MainScene.Model;
using MainScene.Repository;
using MainScene.Source.View.Pages.Main.Place;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MainScene.Source.View.Pages.Main
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuPickPage : Page
    {
        private readonly ProductRepository productRepository = App.repositoryController.GetProductRepository();
        private List<Product> productList;
        private readonly List<Product> selectProductList = new List<Product>();
        private readonly Order order = new Order();
        private int totalPrice;

        public MenuPickPage()
        {
            InitializeComponent();

            SetupData();
            SetupView();
        }

        private void SetupView()
        {
            lbMenus.ItemsSource = productList;
            lbSelected.ItemsSource = selectProductList;
            lbCategory.SelectedIndex = 0;
        }

        private void SetupData()
        {
            productList = productRepository.GetProduct();
        }


        private void LbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedIndex = (sender as ListBox).SelectedIndex;
            UpdateMenuList((CategoryEnum)SelectedIndex);
        }

        private void UpdateMenuList(CategoryEnum categoryEnum)
        {
            lbMenus.ItemsSource = productList.Where(x => x.Category == categoryEnum).ToList();
        }


        private void LbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMenus.SelectedIndex == -1) { return; }
            Product selectedProduct = lbMenus.SelectedItem as Product;

            if (selectProductList.Where(x => x.name == selectedProduct.name).Count() > 0) { return; } //이미 리스트에 값이 있으면 함수종료

            orderButton.IsEnabled = true;
            selectedProduct.Count = 1;

            totalPrice += selectedProduct.FinalPrice;
            selectProductList.Add(selectedProduct);
            SetSelectMenuInfo();
        }

        private void ButtonOrder(object sender, RoutedEventArgs e)
        {
            order.Products = selectProductList;
            NavigationService.Navigate(new PlacePickPage(order));
            //lbMenus.SelectedItem = null;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            if (selectProductList.Count > 0) {
                var result = System.Windows.Forms.MessageBox.Show("뒤로갈겨?", "이스터에그여ㅎ", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No) { return; }
            }
            NavigationService.GoBack();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Product item = ((Button)sender).DataContext as Product;
            if (item == null) { return; }

            item.Count++;

            totalPrice += item.FinalPrice;
            SetSelectMenuInfo();
        }

        private void ButtonSubstract(object sender, RoutedEventArgs e)
        {
            Product item = ((Button)sender).DataContext as Product;
            if (item == null) { return; }

            if (item.Count > 1) { item.Count--; }
            else{ selectProductList.Remove(item); }

            totalPrice -= item.FinalPrice;
            SetSelectMenuInfo();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Product item = ((Button)sender).DataContext as Product;
            if (item == null) { return; }

            selectProductList.Remove(item);

            totalPrice -= item.TotalCellPrice;
            SetSelectMenuInfo();
        }

        private void ButtonDeleteAll(object sender, RoutedEventArgs e)
        {
            if (selectProductList.Count > 0)
            {
                var result = System.Windows.Forms.MessageBox.Show("전부다 지울겨?", "이스터에그여ㅎ", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No) { return; }
            }

            orderButton.IsEnabled = false;

            selectProductList.Clear();
            totalPrice = 0;
            SetSelectMenuInfo();
        }

        private void SetSelectMenuInfo()
        {
            valueOrder.Content = "가격 : " + totalPrice + "원";
            lbSelected.Items.Refresh();
        }
    }
}
