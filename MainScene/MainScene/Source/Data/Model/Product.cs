using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Product
    {
        [Key]
        public int Index { get; set; }
        public int? OrderIndex { get; set; }
        public CategoryEnum Category { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public string name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int IsDiscount { get; set; }
        public int TotalCellPriceCount { get {
                return Count * FinalPrice;
            } set { } }
        [NotMapped]
        public int FinalPrice { get { return Price - DiscountPrice; } set { } }
    }

    public enum CategoryEnum
    {
        Bugger,
        Drink,
        Side
    }
}
