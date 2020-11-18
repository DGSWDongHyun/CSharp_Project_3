using MainScene.DBManager;
using MainScene.DBManagerImpl;
using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
