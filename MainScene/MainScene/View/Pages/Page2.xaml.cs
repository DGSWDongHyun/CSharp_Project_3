using System.Windows.Controls;
using System;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void PayOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(

               new Uri("View/Pages/Page3.xaml", UriKind.Relative)

               );
        }
    }
}
