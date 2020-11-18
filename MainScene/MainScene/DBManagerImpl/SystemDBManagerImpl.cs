using MainScene.DBManager;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MainScene.DBManagerImpl
{
    class SystemDBManagerImpl : SystemDBManager
    {
        public Stopwatch getRunningTime()
        {
            Stopwatch runningTime = null;
            string dbName = "RunningTime.db";

            using (var dbContext = new RunningTimeContext())
            {
                if (File.Exists(dbName))
                {
                    runningTime = dbContext.RunningTime.ToList().First().Time;
                }
                return runningTime;
            }
        }

        public bool SaveRunningTime(Stopwatch runningTime)
        {
            string dbName = "RunningTime.db";

            try
            {
                using (var dbContext = new RunningTimeContext())
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }

                    dbContext.RemoveRange();
                    dbContext.RunningTime.Add(new RunningTime()
                    {
                        Time = runningTime
                    });
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

public class RunningTime{
    [Key]
    public int Index;
    public Stopwatch Time;
}


public class RunningTimeContext : DbContext
{
    public DbSet<RunningTime> RunningTime { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=RunningTime.db");
}