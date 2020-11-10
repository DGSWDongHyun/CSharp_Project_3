using MainScene.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MainScene.Repository
{
    public class OrderRepository
    {
        public List<Order> GetOrderHistoryList()
        {
            List<Order> tempOrderList = new List<Order>();

            var products = new List<Product>();

            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "치킨버거", Image = @"/Assets/ch.png", Price = 6200, Count = 1});
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "리치치즈징거버거", Image = @"/Assets/bbq_c.png", Price = 5600, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "블랙라벨폴인치즈버거", Image = @"/Assets/bl_c.png", Price = 8000, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "징거더블다운맥스", Image = @"/Assets/bbq_c.png", Price = 9200, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "이탈리안타워버거", Image = @"/Assets/italian.png", Price = 6700, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "치킨불고기버거", Image = @"/Assets/bbq_c.png", Price = 8200, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "커넬통다리버거", Image = @"/Assets/bbq_c.png", Price = 7400, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "타워버거", Image = @"/Assets/bbq_c.png", Price = 7700, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "커넬통다리버거", Image = @"/Assets/bbq_c.png", Price = 6400, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "치킨불고기버거", Image = @"/Assets/bbq_c.png", Price = 5600, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "이탈리안타워버거", Image = @"/Assets/bbq_c.png", Price = 6900, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "징거더블다운맥스", Image = @"/Assets/bbq_c.png", Price = 8200, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "리치치즈징거버거", Image = @"/Assets/bbq_c.png", Price = 7000, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Bugger, name = "블랙라벨폴인치즈버거", Image = @"/Assets/bbq_c.png", Price = 7500, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Drink, name = "콜라", Image = @"/Assets/cola.png", Price = 2000, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Drink, name = "사이다", Image = @"/Assets/cyida.png", Price = 2000, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Side, name = "닭껍질 튀김", Image = @"/Assets/crustch.png", Price = 3200, Count = 1 });
            products.Add(new Product() { Category = CategoryEnum.Side, name = "치킨 텐더", Image = @"/Assets/tender.png", Price = 4000, Count = 1 });

            tempOrderList.Add(new Order(1, new Table() { tablenum = 1, UsedTime = DateTime.Now }, new Payment(true, "12", DateTime.Now), products));
            tempOrderList.Add(new Order(2, new Table() { tablenum = 2, UsedTime = DateTime.Now }, new Payment(true, "11", DateTime.Now), products));
            tempOrderList.Add(new Order(3, new Table() { tablenum = 3, UsedTime = DateTime.Now }, new Payment(true, "12", DateTime.Now), new List<Product>()));
            tempOrderList.Add(new Order(4, new Table() { tablenum = 4, UsedTime = DateTime.Now }, new Payment(true, "14", DateTime.Now), new List<Product>()));

            return tempOrderList;
        }
    }
}
