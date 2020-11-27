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
        Timer timer = new System.Timers.Timer(100);

        
        public SeatPage(Order order)
        {
            InitializeComponent();

            List<Seat> seatList = TableRepository.GetSeatList(); //우리매장에 있는 테이블 정보
            List<Seat> usedSeatList = TableRepository.GetUsedSeatList(); //사용된 테이블 정보

            timer.Elapsed += new ElapsedEventHandler(seattime);
            timer.Start();

            this.order = order;
            this.seatListbox.ItemsSource = seatList;
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
                        Debug.WriteLine(seat.ust);
                    }
                }
            }
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
