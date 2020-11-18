using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.DBManagerImpl
{
    public interface SeatDBManager
    {
        List<Seat> GetSeatList();

        List<Seat> GetUsedSeatList();
    }
}
