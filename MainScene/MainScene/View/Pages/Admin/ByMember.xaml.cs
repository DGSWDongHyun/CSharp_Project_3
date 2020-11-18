﻿using MainScene.Model;
using MainScene.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainScene.View.Pages.Admin
{
    /// <summary>
    /// ByMember.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ByMember : Page
    {
        private OrderRepository orderRepository = App.repositoryController.GetOrderRepository();
        private ProductRepository productRepository = App.repositoryController.GetProductRepository();

        List<string> orderedUserCodeList;
        List<Order> orderHistoryList;
        List<Product> productList;

        public ByMember()
        {
            InitializeComponent();
            
            orderHistoryList = orderRepository.GetOrderHistoryList();

            orderedUserCodeList = GetOrderedUserCodeList(orderHistoryList);

            setupView();
        }


        private void setupView()
        {
            lbMember.ItemsSource = orderedUserCodeList;
            lbMember.SelectedIndex = 0;
        }


        private void lbMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string userCode = lbMember.SelectedItem as string;

            var productLisyByMember = GetDividedProductList(userCode, orderHistoryList);

            productList = productRepository.GetProduct();



            foreach (Product product in productList)
            {
                product.TotalCellCount = productLisyByMember.Where(x => x.name == product.name).Count();
                product.TotalCellPriceCount = product.TotalCellCount * product.Price;
            }


            int totalMargin = 0;
            foreach (Product product in productLisyByMember)
            {
                totalMargin += product.Price;
            }

            statisticsInfo.Text = "총" + productLisyByMember.Count + "개 판매, 총" + totalMargin + "원";

            lbMenus.ItemsSource = productList;
        }

        private List<Product> GetDividedProductList(string userCode, List<Order> orderHistoryList)
        {
            List<Product> orderedProductList = new List<Product>();

            var devidedOrderList = orderHistoryList.Where(x => x.Payment.UserCode.Equals(userCode)).ToList();

            foreach(var devidedOrder in devidedOrderList)
            {
                orderedProductList.AddRange(devidedOrder.Products);
            }
            return orderedProductList;
        }

        private List<string> GetOrderedUserCodeList(List<Order> orderHistoryList)
        {
            List<string> orderedUserCodeList = new List<string>();
            List<string> tempOrderedUserCodeList = new List<string>();

            foreach (Order order in orderHistoryList)
            {
                tempOrderedUserCodeList.Add(order.Payment.UserCode);
            }

            return tempOrderedUserCodeList.Distinct().ToList();
        }
    }
}
