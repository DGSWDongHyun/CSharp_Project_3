using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.Repository
{
    public interface ProductRepository
    {
        List<Product> GetProduct();
    }
}
