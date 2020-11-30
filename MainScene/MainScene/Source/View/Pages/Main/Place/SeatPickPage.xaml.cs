using MainScene.Model;
using MainScene.Repository;
using MainScene.Source.View.Pages.Main.Payment;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Seat = MainScene.Model.Seat;

namespace MainScene.Source.View.Pages.Main.Place
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeatPickPage : Page
    {
        SeatRepository TableRepository = App.repositoryController.GetTableRepository();
        public System.Collections.IList SelectedItems { get; }
        Order order = new Order();
        Timer timer = new System.Timers.Timer(100);


        public SeatPickPage(Order order)
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
                if (seat._canuse)
                {
                    order.Seat = seat;
                    order.IsTakeout = false;
                }
                else
                {
                    return;
                }
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {   
            if(order.IsTakeout != true)
            {
                timer.Stop();
                NavigationService.Navigate(new PaymentPickPage(order));
            }
            else
            {
                MessageBox.Show("테이블을 선택해주세요");
            }
            
        }
    }
}
