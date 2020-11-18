using MainScene.Model;
using System;
using System.Collections.Generic;


namespace MainScene.Repository
{
    public interface TableRepository
    {
        List<Seat> GetTable();
    }
}
