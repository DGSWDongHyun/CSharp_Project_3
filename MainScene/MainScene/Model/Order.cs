using System.Collections.Generic;
using System.Dynamic;

namespace MainScene.Model
{
    public class Order
    {
        public int OrderIdx { get; set; }
        public bool IsTakeout { get; set; }
        public Table Table { get; set; }
        public Payment Payment { get; set; }
        public List<Product> Products { get; set; }

        public Order(int OrderIdx, Table table, Payment payment,List<Product> products)
        {
            this.OrderIdx = OrderIdx;
            this.IsTakeout = table == null;
            this.Table = table;
            this.Payment = payment;
            this.Products = products;

        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;
            foreach (Product product in Products)
            {
                totalPrice += product.Price;
            }


            return totalPrice;
        }

        public Order() { }
    }
}
