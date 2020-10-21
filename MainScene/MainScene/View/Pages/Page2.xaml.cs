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

        public Page2()
        {
            InitializeComponent();
            foodProduct = productRepository.GetProduct();
            foodSelected = new List<Product>();
            lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Bugger).ToList();
            //lbSelected.ItemsSource = foodSelected;

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(

           new Uri("View/Pages/Page3.xaml", UriKind.Relative)

           );
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
            if(lbMenus.SelectedIndex == -1)
            {
                return;
            }

            Product product = lbMenus.SelectedItem as Product;

            if (product == null) return;
#if false //  바인딩이 되어 있을 경우
            foodSelected.Add(product);

#else //바인딩이 안되어 있을 경우
            lbSelected.Items.Add(product);       
#endif
            //int Selected_index = lbMenus.SelectedIndex;
            //foodSelected.Add(foodProduct[Selected_index]);
        }
    }
}
