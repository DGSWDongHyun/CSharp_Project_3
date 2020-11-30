using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;

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
                if ((int)(UsedTime - DateTime.Now).TotalSeconds + 59 < 0)
                {
                    return " ";
                }
                else
                {
                    int totalsec = (int)(UsedTime - DateTime.Now).Seconds + 59;
                    canuse = false;
                    return Convert.ToString(totalsec);
                }
            }
            set
            {
                OnPropertyChanged(nameof(ust));
            }
        }

        public bool _canuse = true; //사용할수 있는지 없는지 확인

        public int seatNum { get; set; }

        public bool canuse
        {
            get
            {
                return _canuse;
            }
            set
            {
                _canuse = value;
                OnPropertyChanged(nameof(canuse));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
