using MainScene.Repository;
using MainScene.RepositoryImpl;
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
        private TableRepository tableRepositoryInstance = null;
        private SettlementRepository settlementRepositoryInstance = null;

        public OrderRepository GetOrderRepository()
        {
            if (orderRepositoryInstance == null)
            {
                orderRepositoryInstance = new OrderRepositoryImpl();
            }
            return orderRepositoryInstance;
        }
        public ProductRepository GetProductRepository()
        {
            if (productRepositoryInstance == null)
            {
                productRepositoryInstance = new ProductRepositoryImpl();
            }
            return productRepositoryInstance;
        }
        public TableRepository GetTableRepository()
        {
            if (tableRepositoryInstance == null)
            {
                tableRepositoryInstance = new TableRepositoryImpl();
            }
            return tableRepositoryInstance;
        }

        public SettlementRepository GetSettlementRepository()
        {
            if (settlementRepositoryInstance == null)
            {
                settlementRepositoryInstance = new SettlementRepositoryImpl();
            }

            return settlementRepositoryInstance;
        }

    }
}
