using System;

namespace MainScene.Model
{
    public class Payment
    {
        public bool IsTakeout { get; set; }
        public User User { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}
