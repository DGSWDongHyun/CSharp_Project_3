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
        ProductRepository productRepository = App.repositoryController.GetProductRepository();
        private List<Product> foodProduct;
        private List<Product> foodSelected;
        private int position;
        Order order;
        private int price;

        public MenuPickPage() // initialize page
        {
            InitializeComponent();

            foodProduct = productRepository.GetProduct();
            foodSelected = new List<Product>();
            order = new Order();

            lbMenus.ItemsSource = foodProduct;
            lbSelected.ItemsSource = foodSelected;
            lbCategory.SelectedIndex = 0;

        }

        // Selected Changed when get each products
        private void lbSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            position = lbSelected.SelectedIndex;
        }
        // Selected Changed when get each products

        //Category, Menus SelectionChanged methods.
        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi.Content.ToString() == "버거")
            {
                lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Bugger).ToList();
            }
            else if (lbi.Content.ToString() == "음료")
            {
                lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Drink).ToList();
            }
            else if (lbi.Content.ToString() == "사이드 메뉴")
            {
                lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Side).ToList();
            }
        }

        private void lbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderButton.IsEnabled = true;
            if (lbMenus.SelectedIndex == -1) return;

            Product product = lbMenus.SelectedItem as Product;

            if (product == null) return;
            product.Count = 1;

            if (foodSelected.Count == 0)
            {
                price += product.FinalPrice;

                foodSelected.Add(product);
                RefreshItemWithPrice();
            }
            else
            {
                for (int i = 0; i < foodSelected.Count; i++)
                {
                    if (!product.name.Equals(foodSelected[i].name))
                    {
                        if (i == foodSelected.Count - 1)
                        {
                            price += product.FinalPrice;

                            foodSelected.Add(product);
                            RefreshItemWithPrice();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
        //Category, Menus SelectionChanged methods.

        //Button functions on page

        private void ButtonOrder(object sender, System.Windows.RoutedEventArgs e) // order button
        {
            if (foodSelected.Count == 0)
            {
                System.Windows.MessageBox.Show("제품을 선택해주세요.");
            }
            else
            {
                order.Products = foodSelected;
                NavigationService.Navigate(new PlacePickPage(order));
            }
            lbMenus.SelectedItem = null;
        }

        private void ButtonGoBack(object sender, System.Windows.RoutedEventArgs e) // go back button
        {
            if (foodSelected.Count > 0)
            {
                var result = System.Windows.Forms.MessageBox.Show("뒤로갈겨?", "이스터에그여ㅎ", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            NavigationService.GoBack();
        }

        //Button functions on page

        //Button functions on each item

        private void ButtonAdd(object sender, RoutedEventArgs e) // add button ( count each products )
        {
            Product item = ((Button)sender).DataContext as Product;

            if (item == null) return;


            item.Count++;
            price += item.FinalPrice;
            RefreshItemWithPrice();
        }

        private void ButtonSubstract(object sender, RoutedEventArgs e) // substract button ( count each products also. )
        {
            Product item = ((Button)sender).DataContext as Product;

            if (item == null) return;

            if (item.Count > 1)
            {
                item.Count--;
            }
            else
            {
                item.Count = 1;
                foodSelected.Remove(item);
            }
            price += -(item.FinalPrice);
            RefreshItemWithPrice();

        }

        private void ButtonDelete(object sender, RoutedEventArgs e) // delete each item
        {
            Product item = ((Button)sender).DataContext as Product;

            if (item == null) return;


            price -= (item.FinalPrice * item.Count);
            item.Count = 1;
            foodSelected.Remove(item);

            RefreshItemWithPrice();

        }

        private void ButtonDeleteAll(object sender, RoutedEventArgs e) // delete all items 
        {
            if (foodSelected.Count > 0)
            {
                var result = System.Windows.Forms.MessageBox.Show("전부 지울겨?", "이스터에그여ㅎ", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            for (int i = 0; i < foodSelected.Count; i++)
                foodSelected[i].Count = 1;
            foodSelected.Clear();
            price = 0;
            RefreshItemWithPrice();

            orderButton.IsEnabled = false;
        }
        //Button function on items

        //Refresh item Prices when after done count process
        private void RefreshItemWithPrice()
        {
            valueOrder.Content = "가격 : " + price + "원";
            lbSelected.Items.Refresh();
        }
        //Refresh item Prices when after done count process
    }
}
