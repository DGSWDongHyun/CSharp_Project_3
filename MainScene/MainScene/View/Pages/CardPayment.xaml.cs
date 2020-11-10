using System;
using MainScene.Model;
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
    /// CardPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPayment : Page
    {
        Order order;
        public CardPayment(Order order)
        {
            InitializeComponent();
            webcam.CameraIndex = 0;
            this.order = order;
            price.Text = "총 금액 : " + allPrices() + "원";
        }
        private void webcam_QrDecoded(object sender, string e)
        {
            tbRecog.Text = "인식된 카드번호 : "+e;
        }

        private void tbRecog_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private int allPrices()
        {
            int prices = 0;
            for(int i = 0; i < order.Products.Count; i++)
            {
                Product products = order.Products[i];
                prices += (products.Price * products.Count);
            }
            return prices;
        }
    }
}
