using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Seat = MainScene.Model.Seat;
using MainScene.Repository;
using System.Diagnostics;
using System.Windows;
using System.Timers;
using System.Windows.Threading;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeatPage : Page
    {
        SeatRepository TableRepository = App.repositoryController.GetTableRepository();
        public System.Collections.IList SelectedItems { get; }
        Order order = new Order();
        Timer timer = new System.Timers.Timer(100);
    

        public SeatPage(Order order)
        {
            InitializeComponent();

            timer.Elapsed += new ElapsedEventHandler(seattime);
            timer.Start();

            this.order = order;
        }

        public void seattime(object sender, ElapsedEventArgs e)
        {
            List<Seat> seatList = TableRepository.GetSeatList(); //우리매장에 있는 테이블 정보
            List<Seat> usedSeatList = TableRepository.GetUsedSeatList(); //사용된 테이블 정보
            

            foreach (var usedSeat in usedSeatList)
            {
                foreach (var seat in seatList)
                {
                    if (usedSeat.seatNum == seat.seatNum)
                    {
                        seat.UsedTime = usedSeat.UsedTime;
                    }
                }
            }
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
             {
                seatListbox.ItemsSource = seatList;
             }));
        }

        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListBoxItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            Seat seat = seatListbox.SelectedItem as Seat;
            if (seat != null)
            {
                if (seat.canuse)
                {
                    order.Seat = seat;
                }
                else
                {
                    return;
                }
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Payment(order));
        }
    }
}
