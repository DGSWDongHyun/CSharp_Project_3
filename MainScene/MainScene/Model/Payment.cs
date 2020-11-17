using System;
using System.ComponentModel.DataAnnotations;

namespace MainScene.Model
{
    public class Payment
    {
        [Key]
        public int index { get; set; }
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