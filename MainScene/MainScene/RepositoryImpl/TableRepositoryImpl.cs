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
    class TableRepositoryImpl: TableRepository
    {
        public List<Seat> GetTable()
        {
            var tableList = new List<Seat>();
            string dbName = "Table.db";

            using (var dbContext = new TableContext())
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
                            new Seat() { UsedTime = DateTime.Now, tablenum = 1 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 2 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 3 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 4 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 5 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 6 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 7 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 8 },
                            new Seat() { UsedTime = DateTime.Now, tablenum = 9 }

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

public class TableContext : DbContext
{
    public DbSet<Seat> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Table.db");
}

