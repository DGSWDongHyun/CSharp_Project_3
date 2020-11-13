using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.RepositoryImpl
{
    public class OrderRepositoryImpl : OrderRepository
    {
        public List<Order> GetOrderHistoryList()
        {
            var orderList = new List<Order>();
            string dbName = "Order.db";
            using (var dbContext = new OrderContext())
            {
                if (File.Exists(dbName))
                {
                    orderList.AddRange(dbContext.Order);
                }
            }
            return orderList;
        }

        public int GetLastOrderNumber()
        {
            var lastOrderNumber = 0;
            string dbName = "Order.db";
            using (var dbContext = new OrderContext())
            {
                if (File.Exists(dbName))
                {
                    lastOrderNumber = dbContext.Order.Last().index;
                }
            }
            return lastOrderNumber;
        }

        public bool SaveOrder(Order order)
        {
            var orderList = new List<Order>();
            string dbName = "Order.db";
            using (var dbContext = new OrderContext())
            {
                if (File.Exists(dbName))
                {
                    dbContext.Order.Add(order);
                    dbContext.SaveChanges();
                }
                else
                {
                    dbContext.Database.EnsureCreated();

                    dbContext.Order.Add(order);
                    dbContext.SaveChanges();
                }
            }
            return true ;
        }
    }
}

public class   OrderContext : DbContext
{
    public DbSet<Order> Order { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Order.db");
}
