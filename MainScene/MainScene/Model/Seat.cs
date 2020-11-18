using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int index { get; set; }
        public DateTime UsedTime { get; set; } //사용된 시간을 받음
        
        public int seatNum { get; set; }

        //public bool IsUsingNow()
        //{
        //    TimeSpan span = DateTime.Now - UsedTime;
        //    if(span.Minutes < 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
