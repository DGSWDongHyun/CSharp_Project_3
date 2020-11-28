using MainScene.DBManagerImpl;
using MainScene.Model;
using System.Collections.Generic;

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

        public bool ModifyProduct(List<Product> products) => productDBManager.ModifyProduct(products);
    }
}
