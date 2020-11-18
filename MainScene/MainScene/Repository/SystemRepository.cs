using MainScene.DBManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Repository
{
    public class SystemRepository
    {
        private SystemDBManager systemDBManager;
        public SystemRepository(SystemDBManager systemDBManager)
        {
            this.systemDBManager = systemDBManager;
        }

        public Stopwatch GetRunningTime() => systemDBManager.getRunningTime();

        public bool SaveRunningTime(Stopwatch runningTime) => systemDBManager.SaveRunningTime(runningTime);
    }
}
