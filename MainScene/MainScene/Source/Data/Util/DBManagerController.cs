using MainScene.DBManager;
using MainScene.DBManagerImpl;

namespace MainScene.Source.Data.Util
{
    public class DBManagerController
    {
        private OrderDBManager orderDBManagerInstance = null;
        private ProductDBManager productDBManagerInstance = null;
        private SeatDBManager seatDBManagerInstance = null;
        private SystemDBManager systemDBManager = null;

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

        public SystemDBManager getSystemDBManager()
        {
            if (systemDBManager == null)
            {
                systemDBManager = new SystemDBManagerImpl();
            }
            return systemDBManager;
        }
    }
}
