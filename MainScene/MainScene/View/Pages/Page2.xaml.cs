using System.Windows.Controls;
using System;
using MainScene.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MainScene.Repository;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        private List<Product> foodProduct = new ProductRepository().GetProduct();

        public Page2()
        {
            InitializeComponent();
            lbMenus.ItemsSource = foodProduct.Where(x => x.Category == CategoryEnum.Bugger).ToList();
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
    }
}
