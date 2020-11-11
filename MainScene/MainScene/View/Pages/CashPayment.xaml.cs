﻿using MainScene.Model;
using MainScene.View.Pages;
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

namespace MainScene.View 
{ 

    /// <summary>
    /// CashPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashPayment : Page
    {
        Order order;
        public CashPayment(Order order)
        {
            InitializeComponent();
            this.order = order;
            price.Text = "총 금액 : " + allPrices() + "원";
            tbCash.Focusable = true;
            tbCash.Focus();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private int allPrices()
    {
        int prices = 0;
        for (int i = 0; i < order.Products.Count; i++)
        {
            Product products = order.Products[i];
            prices += (products.Price * products.Count);
        }
        return prices;
    }

        private void finishPayment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinishPayment(order));
        }
    }
}
