using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MainScene.DBManager
{
    public interface SystemDBManager
    {
        Stopwatch getRunningTime();

        bool SaveRunningTime(Stopwatch runningTime);
    }
}
