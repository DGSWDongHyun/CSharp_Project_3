using System;

namespace KFC_Project.Model
{
    public class Table
    {
        public int Idx { get; set; }
        public DateTime UsedTime { get; set; }

        public bool IsUsingNow()
        {
            TimeSpan span = DateTime.Now - UsedTime;
            if(span.Minutes < 5)
            {
                return true;
            }

            return false;
        }
    }
}
