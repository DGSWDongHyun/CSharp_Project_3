using MainScene.DBManager;
using System.Diagnostics;

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
