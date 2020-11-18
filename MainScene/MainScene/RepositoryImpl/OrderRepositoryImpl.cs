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

            foreach(var order in orderList)
            {
                order.Payment = GetPaymeent(order.Index);
                order.Products = GetOrderedProductList(order.Index);
            }

            return orderList;
        }

        public int SaveOrder(Order order)
        {
            string dbName = "Order.db";

            using (var dbContext = new OrderContext())
            {

                try
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }

                    dbContext.Order.Add(order);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
                
            }
            SaveOrderedProduct(order.Products, order.Index);
            SavePayment(order.Payment, order.Index);
            return order.Index ;
        }

        private Payment GetPaymeent(int orderIdx)
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

        private List<Product> GetOrderedProductList(int orderIdx)
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

        private bool SaveOrderedProduct(List<Product> products, int orderIndex)
        {
            string dbName = "OrderedProduct.db";

            foreach (var product in products)
            {
                product.Index = 0;
                product.OrderIndex = orderIndex;
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
            return true;
        }

        private bool SavePayment(Payment payment, int orderIndex)
        {
            string dbName = "Payment.db";

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

            return true;
        }
    }
}

public class PaymentContext : DbContext
{
    public DbSet<Payment> Payment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>  options.UseSqlite("Data Source=Payment.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>()
            .Property(f => f.Index)
            .ValueGeneratedOnAdd();
    }
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

public class   OrderContext : DbContext
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
