using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }
        public bool IsTakeout { get; set; }

        [NotMapped]
        public Seat Seat { get; set; }
        [NotMapped]
        public Payment Payment { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach (Product product in Products)
            {
                totalPrice += product.FinalPrice;
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
