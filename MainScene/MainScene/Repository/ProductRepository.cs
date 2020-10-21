using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.Repository
{
    public class ProductRepository
    {
        public List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "치킨버거", Image = @"/Assets/ch.png" });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "치킨버거", Image = @"/Assets/ch.png" });
            products.Add(new Product() { Category = CategoryEnum.Drink, name = "콜라", Image = @"/Assets/cola.png" });
            products.Add(new Product() { Category = CategoryEnum.Drink, name = "사이다", Image = @"/Assets/cyida.png" });
            products.Add(new Product() { Category = CategoryEnum.Side, name = "닭껍질 튀김", Image = @"/Assets/crustch.png" });
            products.Add(new Product() { Category = CategoryEnum.Side, name = "치킨 텐더", Image = @"/Assets/tender.png" });
      
            return products;                                                        
        }
    }
}
