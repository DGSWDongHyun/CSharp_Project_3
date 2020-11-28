﻿ using System;
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

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            admv.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
            NavigationService.Navigate(

                new Uri("View/Pages/Page2.xaml", UriKind.Relative)

                );
        }

        private void admv_MediaEnded(object sender, RoutedEventArgs e)
        {
            admv.Position = new TimeSpan(0, 0, 1);
            admv.Play();
        }
    }
}