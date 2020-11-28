using System.Diagnostics;

namespace MainScene.DBManager
{
    public interface SystemDBManager
    {
        Stopwatch getRunningTime();

        bool SaveRunningTime(Stopwatch runningTime);
    }
}
