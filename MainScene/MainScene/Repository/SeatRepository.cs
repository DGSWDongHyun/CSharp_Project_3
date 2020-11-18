using MainScene.Model;
using System;
using System.Collections.Generic;


namespace MainScene.Repository
{
    public interface SeatRepository
    {
        List<Seat> GetSeatList();
    }
}
