using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Project.Model
{
    public class Order
    {
        public int OrderIdx { get; set; }
        public bool IsTakeout { get; set; }
        public Table Table { get; set; }
        public Payment Payment { get; set; }
        public List<Product> Products { get; set; }
    }
}
