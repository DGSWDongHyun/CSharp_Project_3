using MainScene.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MainScene.Repository
{
    public interface OrderRepository
    {
        List<Order> GetOrderHistoryList();
    }
}
