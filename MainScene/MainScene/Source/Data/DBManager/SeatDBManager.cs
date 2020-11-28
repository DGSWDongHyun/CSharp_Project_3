using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.DBManagerImpl
{
    public interface SeatDBManager
    {
        List<Seat> GetSeatList();

        List<Seat> GetUsedSeatList();
    }
}
