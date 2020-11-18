using MainScene.DBManager;
using MainScene.DBManagerImpl;
using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainScene.Repository
{
    public class ProductRepository
    {
        private ProductDBManager productDBManager;
        public ProductRepository(ProductDBManager productDBManager)
        {
            this.productDBManager = productDBManager;
        }

        public List<Product> GetProduct() => productDBManager.GetProduct();
    }
}
