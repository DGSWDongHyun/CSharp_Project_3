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
    public class OrderDBManagerImpl: OrderDBManager
    {
        public List<Order> GetOrderList()
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

        public List<Product> GetOrderedProductList(int orderIdx)
        {
            var productList = new List<Product>();
            string dbName = "Order.db";

            using (var dbContext = new OrderedProductContext())
            {
                if (File.Exists(dbName))
                {
                    productList.AddRange(dbContext.Product);
                }
            }
            return productList.Where(x => x.OrderIndex == orderIdx).ToList();
        }

        public Payment GetPaymeent(int orderIdx)
        {
            var paymentList = new List<Payment>();
            string dbName = "Payment.db";

            using (var dbContext = new PaymentContext())
            {
                if (File.Exists(dbName))
                {
                    paymentList.AddRange(dbContext.Payment);
                }
            }
            return paymentList.Where(x => x.OrderIndex == orderIdx).First();
        }

        public Seat GetUsedSeat(int orderIdx)
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
            return usedSeatList.Where(x => x.OrderIndex == orderIdx).First();
        }


        public bool SaveOrder(Order order)
        {
            string dbName = "Order.db";
            try
            {
                using (var dbContext = new OrderContext())
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }
                    dbContext.Order.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SaveOrderedProduct(List<Product> products, int orderIndex)
        {
            string dbName = "OrderedProduct.db";

            foreach (var product in products)
            {
                product.Index = 0;
                product.OrderIndex = orderIndex;

                try
                {
                    using (var dbContext = new OrderedProductContext())
                    {
                        if (!File.Exists(dbName))
                        {
                            dbContext.Database.EnsureCreated();
                        }
                        dbContext.Product.Add(product);
                        dbContext.SaveChanges();
                    }
                }
                catch
                {
                    return false;
                }
               
            }

            return true;
        }

        public bool SavePayment(Payment payment, int orderIndex)
        {
            string dbName = "Payment.db";
            try
            {
                using (var dbContext = new PaymentContext())
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }

                    payment.OrderIndex = orderIndex;
                    dbContext.Payment.Add(payment);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SaveUsedSeat(Seat seat, int orderIndex)
        {
            string dbName = "UsedSeat.db";

            seat.Index = 0;
            seat.OrderIndex = orderIndex;

            try
            {
                using (var dbContext = new UsedSeatContext())
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }
                    dbContext.UsedSeat.Add(seat);
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

public class PaymentContext : DbContext
{
    public DbSet<Payment> Payment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Payment.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>()
            .Property(f => f.Index)
            .ValueGeneratedOnAdd();
    }
}

public class OrderedProductContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=OrderedProduct.db");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(f => f.Index)
            .HasDefaultValue(1)
            .ValueGeneratedOnAdd();
    }
}

public class OrderContext : DbContext
{
    public DbSet<Order> Order { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Order.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .Property(f => f.Index)
            .ValueGeneratedOnAdd();
    }
}