using System;

namespace MainScene.Model
{
    public class Payment
    {
        public bool IsTakeout { get; set; }
        public String UserCode { get; set; }
        public DateTime PaymentTime { get; set; }
        public PayMentType paymentType { get; set; }
    }
}

public enum PayMentType
{
    Card,
    Cache
}