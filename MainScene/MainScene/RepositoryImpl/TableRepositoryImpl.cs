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
        public List<Table> GetTable()
        {
            var tableList = new List<Table>();
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
                        dbContext.Table.AddRange(new Table[]
                        {
                            new Table() { UsedTime = DateTime.Now, tablenum = 1 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 2 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 3 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 4 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 5 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 6 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 7 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 8 },
                            new Table() { UsedTime = DateTime.Now, tablenum = 9 }

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
    public DbSet<Table> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Table.db");
}

