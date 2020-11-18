using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainScene.Model;
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
using System.Diagnostics;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Page3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page3 : Page
    {
        Order order = new Order();
        public Page3(Order order)
        {
            InitializeComponent();
            this.order = order;      
        }


        private void SelectStore(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Tablepage(order));

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Takeout_Click(object sender, RoutedEventArgs e)
        {
            Model.Seat table = new Model.Seat();
            table.tablenum = 0;
            order.IsTakeout = true;
            NavigationService.Navigate(new Payment(order));    
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

