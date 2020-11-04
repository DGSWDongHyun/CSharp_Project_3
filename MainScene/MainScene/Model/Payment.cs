using System;

namespace MainScene.Model
{
    public class Payment
    {
        public bool IsTakeout { get; set; }
        public String UserCode { get; set; }
        public DateTime PaymentTime { get; set; }

        public Payment() { }

        public Payment(bool isTakeout, String userCode, DateTime paymentTime)
        {
            this.IsTakeout = isTakeout;
            this.UserCode = userCode;
            this.PaymentTime = paymentTime;
        }
    }
}
