using System.Collections.Generic;

namespace MainScene.Model
{
    public class Order
    {
        public int OrderIdx { get; set; }
        public bool IsTakeout { get; set; }
        public Table Table { get; set; }
        public Payment Payment { get; set; }
        public List<Product> Products { get; set; }

        public Order(int OrderIdx, bool IsTakeOut, Table table, Payment payment,List<Product> products)
        {
            this.OrderIdx = OrderIdx;
            this.IsTakeout = IsTakeOut;
            this.Table = table;
            this.Payment = payment;
            this.Products = products;

        }

        public Order() { }
    }
}
