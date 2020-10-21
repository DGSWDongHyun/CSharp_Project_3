using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Table = MainScene.Model.Table;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tablepage : Page
    {
       public Tablepage()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(

                new Uri("View/Pages/Payment.xaml", UriKind.Relative)

                );
        }
    }
}
