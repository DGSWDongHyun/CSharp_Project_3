using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Source.View.Pages
{
    public class PagesURI
    {
        private PagesURI(Uri value) { Value = value; }

        public Uri Value { get; set; }

        public static PagesURI ByCategoryPage { get { return new PagesURI(new Uri("Source/View/Pages/Admin/ByCategoryPage.xaml", UriKind.Relative)); } }
        public static PagesURI ByDatePage { get { return new PagesURI(new Uri("Source/View/Pages/Admin/ByDatePage.xaml", UriKind.Relative)); } }
        public static PagesURI ByMemberPage { get { return new PagesURI(new Uri("Source/View/Pages/Admin/ByMemberPage.xaml", UriKind.Relative)); } }
        public static PagesURI BySeatPage { get { return new PagesURI(new Uri("Source/View/Pages/Admin/BySeatPage.xaml", UriKind.Relative)); } }


        public static PagesURI MenuPickPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Menu/MenuPickPage.xaml", UriKind.Relative)); } }
        public static PagesURI CardPaymentPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Payment/CardPaymentPage.xaml", UriKind.Relative)); } }
        public static PagesURI CashPaymentPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Payment/CashPaymentPage.xaml", UriKind.Relative)); } }
        public static PagesURI FinishPaymentPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Payment/FinishPaymentPage.xaml", UriKind.Relative)); } }
        public static PagesURI PlacePickPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Place/PlacePickPage.xaml", UriKind.Relative)); } }
        public static PagesURI SeatPickPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/Place/SeatPickPage.xaml", UriKind.Relative)); } }
        public static PagesURI HomePage { get { return new PagesURI(new Uri("Source/View/Pages/Main/HomePage.xaml", UriKind.Relative)); } }
        public static PagesURI LoginPage { get { return new PagesURI(new Uri("Source/View/Pages/Main/LoginPage.xaml", UriKind.Relative)); } }
    }
}
