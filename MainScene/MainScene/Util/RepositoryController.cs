using MainScene.DBManager;
using MainScene.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Util
{
    public class RepositoryController
    {
        private OrderRepository orderRepositoryInstance = null;
        private ProductRepository productRepositoryInstance = null;
        private SeatRepository tableRepositoryInstance = null;
        private SettlementRepository settlementRepositoryInstance = null;

        public OrderRepository GetOrderRepository()
        {
            if (orderRepositoryInstance == null)
            {
                orderRepositoryInstance = new OrderRepository(App.dbManagerController.GetOrderDBManager());
            }
            return orderRepositoryInstance;
        }
        public ProductRepository GetProductRepository()
        {
            if (productRepositoryInstance == null)
            {
                productRepositoryInstance = new ProductRepository(App.dbManagerController.GetProductDBManager());
            }
            return productRepositoryInstance;
        }
        public SeatRepository GetTableRepository()
        {
            if (tableRepositoryInstance == null)
            {
                tableRepositoryInstance = new SeatRepository(App.dbManagerController.GetSeatDBManager());
            }
            return tableRepositoryInstance;
        }

        public SettlementRepository GetSettlementRepository()
        {
            if (settlementRepositoryInstance == null)
            {
                settlementRepositoryInstance = new SettlementRepository();
            }

            return settlementRepositoryInstance;
        }

    }
}
