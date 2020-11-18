using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.RepositoryImpl
{
    class SeatRepositoryImpl: SeatRepository
    {
        public List<Seat> GetSeatList()
        {
            var tableList = new List<Seat>();
            string dbName = "Seat.db";

            using (var dbContext = new SeatContext())
            {
                if (File.Exists(dbName))
                {
                    tableList.AddRange(dbContext.Table);
                }
                else
                {
                    dbContext.Database.EnsureCreated();

                    if (!dbContext.Table.Any())
                    {
                        dbContext.Table.AddRange(new Seat[]
                        {
                            new Seat() { UsedTime = DateTime.Now, seatNum = 1 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 2 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 3 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 4 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 5 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 6 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 7 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 8 },
                            new Seat() { UsedTime = DateTime.Now, seatNum = 9 }

                        });

                        dbContext.SaveChanges();
                    }
                    tableList.AddRange(dbContext.Table);
                }
            }
            return tableList;
        }
    }
}

public class SeatContext : DbContext
{
    public DbSet<Seat> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Seat.db");
}

