using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MainScene.Model
{
    public class Order
    {
        [Key]
        public int index { get; set; }
        public int OrderIdx { get; set; }
        public bool IsTakeout { get; set; }
        public Table Table { get; set; }
        public Payment Payment { get; set; }
        public List<Product> Products { get; set; }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach (Product product in Products)
            {
                totalPrice += product.Price;
            }


            return totalPrice;
        }

        public int GetTotalDiscountPrice()
        {
            var totalPrice = 0;
            foreach (Product product in Products)
            {
                totalPrice += product.DiscountPrice;
            }


            return totalPrice;
        }
    }
}
