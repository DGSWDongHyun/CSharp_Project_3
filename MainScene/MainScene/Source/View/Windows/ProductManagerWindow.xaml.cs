using MainScene.Model;
using MainScene.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MainScene.Source.View.Windows
{
    /// <summary>
    /// ProductManagerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductManagerWindow : Window
    {
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();
        private List<Product> foodProduct;
        private Product foodSelected;

        public ProductManagerWindow()
        {
            InitializeComponent();

            foodProduct = productRepository.GetProduct();

            lbMenus.ItemsSource = foodProduct;
            lbCategory.SelectedIndex = 0;
        }

        private void LbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = (sender as ListBox).SelectedIndex;
            lbMenus.ItemsSource = foodProduct.Where(x => x.Category == (CategoryEnum)selectedIndex).ToList();
        }

        private void LbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                if (foodProduct[i].Index == foodSelected.Index)
                {
                    if (foodProduct[i].Price > Convert.ToInt32(discountPrice.Text.ToString()))
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
    }
}
