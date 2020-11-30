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
        private readonly Order order;

        private readonly OrderNetWorkManager orderNetWorkManager = App.netWorkManagerController.GetOrderNetWorkManager();

        public FinishPaymentPage(Order order)
        {
            InitializeComponent();
            this.order = order;
            SetupView();
            Exit();
        }

        private void SetupView()
        {
            price.Text = "금액 : " + order.GetTotalPrice() + "원";
            orderNumber.Text = "주문번호 : " + order.Index;
            orderNetWorkManager.PostOrderInfo(order);
        }

        private async void Exit()
        {
            await Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(5)));
            if (NavigationService == null) { return; }
            GotoHome();
        }

        private void GotoHome()
        {
            while (true)
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
