using System;
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
using System.Windows.Shapes;
using MainScene.Model;
using System.Collections;
using MainScene.Repository;
using MainScene.Util;

namespace MainScene.View.Windows
{
    /// <summary>
    /// ProductManagerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductManagerWindow : Window
    {
        ProductRepository productRepository = App.repositoryController.GetProductRepository();
        private List<Product> foodProduct;
        private Product foodSelected;
        private int position;
        Order order;
        public ProductManagerWindow()
        {
            InitializeComponent();

            foodProduct = productRepository.GetProduct();

            order = new Order();

            lbMenus.ItemsSource = foodProduct;
            lbCategory.SelectedIndex = 0;
        }

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
            if (lbMenus.SelectedIndex == -1) return;

            Product product = lbMenus.SelectedItem as Product;

            if (product == null) return;
            
            foodSelected = product;
            selectedText.Text = foodSelected.name;

        }

        private void ChangeDiscount(object sender, RoutedEventArgs e)
        {
            if (foodSelected == null)
                return;

            for (int i = 0; i < foodProduct.Count; i++)
            {
                if(foodProduct[i].Index == foodSelected.Index)
                {
                    if(foodProduct[i].Price > Convert.ToInt32(discountPrice.Text.ToString()))
                    {
                        foodProduct[i].DiscountPrice = Convert.ToInt32(discountPrice.Text.ToString());
                    }
                    else
                    {
                        MessageBox.Show("할인 적용에 실패했습니다.");
                        return;
                    }
                }
            }
            if (productRepository.ModifyProduct(foodProduct))
            {
                MessageBox.Show("할인이 적용되었습니다. 할인된 금액 : " + discountPrice.Text.ToString());
            }
            else
            {
                MessageBox.Show("할인 적용에 실패했습니다.");
            }
        }
        //Category, Menus SelectionChanged methods.

    }
}
