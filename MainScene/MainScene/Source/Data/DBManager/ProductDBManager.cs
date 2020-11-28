using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.DBManagerImpl
{
    public interface ProductDBManager
    {
        List<Product> GetProduct();

        bool ModifyProduct(List<Product> products);
    }
}
