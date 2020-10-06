using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Project.Model
{
    public class Payment
    {
        public bool IsTakeout { get; set; }
        public User User { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}
