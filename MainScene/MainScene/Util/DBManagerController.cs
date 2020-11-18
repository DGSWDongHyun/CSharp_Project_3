using MainScene.DBManager;
using MainScene.DBManagerImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Util
{
    public class DBManagerController
    {
        private OrderDBManager orderDBManagerInstance = null;
        private ProductDBManager productDBManagerInstance = null;
        private SeatDBManager seatDBManagerInstance = null;

        public OrderDBManager GetOrderDBManager()
        {
            if (orderDBManagerInstance == null)
            {
                orderDBManagerInstance = new OrderDBManagerImpl();
            }
            return orderDBManagerInstance;
        }
        public ProductDBManager GetProductDBManager()
        {
            if (productDBManagerInstance == null)
            {
                productDBManagerInstance = new ProductDBManagerImpl();
            }
            return productDBManagerInstance;
        }
        public SeatDBManager GetSeatDBManager()
        {
            if (seatDBManagerInstance == null)
            {
                seatDBManagerInstance = new SeatDBManagerImpl();
            }
            return seatDBManagerInstance;
        }
    }
}
