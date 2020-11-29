using MainScene.Source.Data.NetWorkManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Source.Data.Util
{
    public class NetWorkManagerController
    {
        private AuthNetWorkManager authNetWorkManagerInstance = null;
        private OrderNetWorkManager orderNetWorkManagerInstance = null;

        public AuthNetWorkManager GetAuthNetWorkManager()
        {
            if (authNetWorkManagerInstance == null)
            {
                authNetWorkManagerInstance = new AuthNetWorkManager();
            }
            return authNetWorkManagerInstance;
        }
        public OrderNetWorkManager GetOrderNetWorkManager()
        {
            if (orderNetWorkManagerInstance == null)
            {
                orderNetWorkManagerInstance = new OrderNetWorkManager();
            }
            return orderNetWorkManagerInstance;
        }
    }
}
