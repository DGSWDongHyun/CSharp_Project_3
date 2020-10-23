using System.Windows.Controls;
using System;
using MainScene.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MainScene.Repository;
using MainScene.Util;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        ProductRepository productRepository = App.repositoryController.GetProductRepository();
        private List<Product> foodProduct;
        private List<Product> foodSelected;
        private int position;
        Order order;
        private int price;

        public Page2()
        {
            InitializeComponent();
            foodProduct = productRepository.GetProduct();
            foodSelected = new List<Product>();
            order = new Order();
            lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Bugger).ToList();
            lbSelected.ItemsSource = foodSelected;

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            order.Products = foodSelected;
           
            NavigationService.Navigate(new Page3(order));
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



        private void lbCategory_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {   
           ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
           if(lbi.Content.ToString() == "버거")
            {
              lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Bugger).ToList();
            }else if(lbi.Content.ToString() == "음료")
            {
                lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Drink).ToList();
            }else if(lbi.Content.ToString() == "사이드 메뉴")
            {
                lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Side).ToList();
            }
        }

        private void lbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbMenus.SelectedIndex == -1) return;
          
            Product product = lbMenus.SelectedItem as Product;

            if (product == null) return;

            if(foodSelected.Count == 0)
            {
                price += product.Price;
                valueOrder.Content = "가격 : " + price;

                foodSelected.Add(product);
                lbSelected.Items.Refresh();
            }
            else
            {
                for (int i = 0; i < foodSelected.Count; i++)
                {
                    if (!product.name.Equals(foodSelected[i].name))
                    {
                        price += product.Price;
                        valueOrder.Content = "가격 : " + price;

                        foodSelected.Add(product);
                        lbSelected.Items.Refresh();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
        }

        private void Count_Button_Add(object sender, RoutedEventArgs e)
        {
            Product item =  ((Button)sender).DataContext as Product;

            if (item == null) return;

         
            price += item.Price;
            valueOrder.Content = "가격 : " + price;

            item.Count++;
            lbSelected.Items.Refresh();


        }
        private void  Count_Button_Substract(object sender, RoutedEventArgs e)
        {
            Product item = ((Button)sender).DataContext as Product;

            if (item == null) return;

            if(item.Count > 1) {
                item.Count--;
            } else {
                price -= item.Price;
                valueOrder.Content = "가격 : " + price;
                foodSelected.Remove(item);
            }
            lbSelected.Items.Refresh();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foodSelected.Clear();
            lbSelected.Items.Refresh();
        }

        private void lbSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            position = lbSelected.SelectedIndex;
        }
    }
}
