﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            admv.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream:MainScene/MainScene/View/Pages/Page1.xaml.cs
            if (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
            NavigationService.Navigate(

                new Uri("View/Pages/Page2.xaml", UriKind.Relative)

                );
=======
            NavigationService.Navigate(PagesURI.MenuPickPage.Value);
>>>>>>> Stashed changes:MainScene/MainScene/Source/View/Pages/Main/HomePage.xaml.cs
        }

        private void admv_MediaEnded(object sender, RoutedEventArgs e)
        {
            admv.Position = new TimeSpan(0, 0, 1);
            admv.Play();
        }
    }
}