using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace MainScene.View.Pages
{
    /// <summary>
    /// FinishPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FinishPayment : Page
    {
        Order order;


        public FinishPayment(Order order)
        {
            InitializeComponent();
            this.order = order;
            price.Text = "금액 : " + allPrices() + "원";
            Exit();
        }

        private async void Exit()
        {
            await Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(5)));
            if (NavigationService == null) { return; }
            goHome();
        }

        private void goHome()
        {
            while (true)
            {
                if (!NavigationService.CanGoBack)
                {
                    break;
                }
                else
                {
                    NavigationService.GoBack();
                }
            }
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
    }
}
