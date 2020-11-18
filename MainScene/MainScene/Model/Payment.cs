using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }
        public int OrderIndex { get; set; }
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