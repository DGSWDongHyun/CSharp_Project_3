using MainScene.DBManagerImpl;
using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.Repository
{
    public class SeatRepository
    {
        private SeatDBManager seatDBManager;

        public SeatRepository(SeatDBManager seatDBManager)
        {
            this.seatDBManager = seatDBManager;
        }

        public List<Seat> GetUsedSeatList() => seatDBManager.GetUsedSeatList();

        public List<Seat> GetSeatList() => seatDBManager.GetSeatList();
    }
}
