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
        private TableRepository tableRepositoryInstance = null;
        private UserRepository userRepositoryInstance = null;

        public OrderRepository GetOrderRepository()
        {
            if (orderRepositoryInstance == null)
            {
                orderRepositoryInstance = new OrderRepository();
            }
            return orderRepositoryInstance;
        }
        public ProductRepository GetProductRepository()
        {
            if (productRepositoryInstance == null)
            {
                productRepositoryInstance = new ProductRepository();
            }
            return productRepositoryInstance;
        }
        public TableRepository GetTableRepository()
        {
            if (tableRepositoryInstance == null)
            {
                tableRepositoryInstance = new TableRepository();
            }
            return tableRepositoryInstance;
        }
        public UserRepository GetUserRepository()
        {
            if (userRepositoryInstance == null)
            {
                userRepositoryInstance = new UserRepository();
            }
            return userRepositoryInstance;
        }

    }
}
