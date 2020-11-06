namespace MainScene.Model
{
    public class Product
    {
        public CategoryEnum Category { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public string name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int IsDiscount { get; set; }
        public int TotalCellCount { get; set; }
        public int TotalCellPriceCount { get; set; }
    }

    public enum CategoryEnum
    {
        Bugger,
        Drink,
        Side
    }
}
