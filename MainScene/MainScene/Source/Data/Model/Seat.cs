using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainScene.Model
{
    public class Seat : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }

        public int OrderIndex { get; set; }

        public DateTime UsedTime
        {
            get; set;
        }
        [NotMapped]
        public string ust
        {
            get
            {
                if ((int)(UsedTime - DateTime.Now).TotalSeconds + 60 < 0)
                {
                    return " ";
                }
                else
                {
                    int totalsec = (int)(UsedTime - DateTime.Now).Seconds + 60;
                    canuse = false;
                    return Convert.ToString(totalsec);
                }
            }
            set
            {
                OnPropertyChanged(nameof(ust));
            }
        }

        public bool canuse = true; //사용할수 있는지 없는지 확인

        public int seatNum { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

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
