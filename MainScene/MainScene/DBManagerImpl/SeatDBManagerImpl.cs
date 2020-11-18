using MainScene.DBManagerImpl;
using MainScene.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.DBManager
{
    public class SeatDBManagerImpl: SeatDBManager
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
                            new Seat() { seatNum = 1 },
                            new Seat() { seatNum = 2 },
                            new Seat() { seatNum = 3 },
                            new Seat() { seatNum = 4 },
                            new Seat() { seatNum = 5 },
                            new Seat() { seatNum = 6 },
                            new Seat() { seatNum = 7 },
                            new Seat() { seatNum = 8 },
                            new Seat() { seatNum = 9 }

                        });

                        dbContext.SaveChanges();
                    }
                    tableList.AddRange(dbContext.Table);
                }
            }
            return tableList;
        }

        public List<Seat> GetUsedSeatList()
        {
            var usedSeatList = new List<Seat>();
            string dbName = "UsedSeat.db";

            using (var dbContext = new UsedSeatContext())
            {
                if (File.Exists(dbName))
                {
                    usedSeatList.AddRange(dbContext.UsedSeat);
                }
            }
            return usedSeatList.ToList();
        }
    }
}
public class SeatContext : DbContext
{
    public DbSet<Seat> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Seat.db");
}

public class UsedSeatContext : DbContext
{
    public DbSet<Seat> UsedSeat { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=UsedSeat.db");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(f => f.Index)
            .HasDefaultValue(1)
            .ValueGeneratedOnAdd();
    }
}

