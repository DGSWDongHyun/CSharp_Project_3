using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Seat = MainScene.Model.Seat;
using MainScene.Repository;
using System.Diagnostics;
using System.Windows;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeatPage : Page
    {
        SeatRepository TableRepository = App.repositoryController.GetTableRepository();
        int selecttablenum = 0;
        public System.Collections.IList SelectedItems { get; }
        Order order = new Order();
        
        public SeatPage(Order order)
        {   
            InitializeComponent();
            List<Seat> seat = TableRepository.GetSeatList();
            this.seatListbox.ItemsSource = seat;

            this.order = order;
        }

        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Payment(order));
        }

        private void ListBoxItem_Selected(object sender, SelectionChangedEventArgs e)
        {

            Seat seat = seatListbox.SelectedItem as Seat;

            order.Seat = seat;

            //MessageBox.Show(selecttablenum.ToString());
        }
    }
}
