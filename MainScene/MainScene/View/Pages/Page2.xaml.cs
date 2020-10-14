using System.Windows.Controls;
using System;
using KFC_Project.Model;
using System.Collections;
using System.Collections.Generic;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        private List<Product> foodProduct = new List<Product>()
        {
            new Product(){ Category = CategoryEnum.Bugger, name = "치킨버거", Image = @"/Assets/기네스머쉬룸와퍼.png" },
        };
        public Page2()
        {
            InitializeComponent();
        }

 

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(

           new Uri("View/Pages/Page3.xaml", UriKind.Relative)

           );
        }
    }
}
