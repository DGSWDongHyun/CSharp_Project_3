using System;

namespace MainScene.Model
{
    public class Table
    {
        public DateTime UsedTime { get; set; } //사용된 시간을 받음
        public int tablenum { get; set; }

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
