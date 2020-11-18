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
            get;set;
        }
        
        [NotMapped]
        public int ust
        {
            get
            {
                return (int)(UsedTime - DateTime.Now).TotalSeconds;
            }
            set
            {
                OnPropertyChanged("ust");
            }
        }
        
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
