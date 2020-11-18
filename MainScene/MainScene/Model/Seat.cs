using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }
        
        public int OrderIndex { get; set; }

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
