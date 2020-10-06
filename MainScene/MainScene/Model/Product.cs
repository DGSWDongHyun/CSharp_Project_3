using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Project.Model
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
    }

    public enum CategoryEnum
    {
        Bugger,
        Drink,
        Side
    }
}
