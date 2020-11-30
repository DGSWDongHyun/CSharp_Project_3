using MainScene.Model;
using MainScene.Source.Data.NetWorkManager;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MainScene.Source.View.Pages.Main.Payment
{
    /// <summary>
    /// FinishPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FinishPaymentPage : Page
    {
        Order order;

        OrderNetWorkManager orderNetWorkManager = App.netWorkManagerController.GetOrderNetWorkManager();

        public FinishPaymentPage(Order order)
        {
            InitializeComponent();
            this.order = order;
            price.Text = "금액 : " + order.GetTotalPrice() + "원";
            orderNumber.Text = "주문번호 : " + order.Index;
            orderNetWorkManager.PostOrderInfo(order);
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
    }
}
