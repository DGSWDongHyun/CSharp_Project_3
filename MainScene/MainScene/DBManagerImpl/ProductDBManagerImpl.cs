using MainScene.DBManagerImpl;
using MainScene.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainScene.DBManager
{
    public class ProductDBManagerImpl : ProductDBManager
    {
        public List<Product> GetProduct()
        {
            var productList = new List<Product>();
            string dbName = "Product.db";

            using (var dbContext = new ProductContext())
            {
                if (File.Exists(dbName))
                {
                    productList.AddRange(dbContext.Product);
                }
                else
                {
                    dbContext.Database.EnsureCreated();

                    if (!dbContext.Product.Any())
                    {
                        dbContext.Product.AddRange(new Product[]
                        {
                            new Product() { Category = CategoryEnum.Bugger, name = "치킨버거", Image = @"/Assets/ch.png", Price = 6200, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "리치치즈징거버거", Image = @"/Assets/bbq_c.png", Price = 5600, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "블랙라벨폴인치즈버거", Image = @"/Assets/bl_c.png", Price = 8000, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "징거더블다운맥스", Image = @"/Assets/bbq_c.png", Price = 9200, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "이탈리안타워버거", Image = @"/Assets/italian.png", Price = 6700, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "치킨불고기버거", Image = @"/Assets/bbq_c.png", Price = 8200, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "커넬통다리버거", Image = @"/Assets/bbq_c.png", Price = 7400, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "타워버거", Image = @"/Assets/bbq_c.png", Price = 7700, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "커넬통다리버거", Image = @"/Assets/bbq_c.png", Price = 6400, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "치킨불고기버거", Image = @"/Assets/bbq_c.png", Price = 5600, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "이탈리안타워버거", Image = @"/Assets/bbq_c.png", Price = 6900, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "징거더블다운맥스", Image = @"/Assets/bbq_c.png", Price = 8200, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "리치치즈징거버거", Image = @"/Assets/bbq_c.png", Price = 7000, Count = 1 },
                            new Product() { Category = CategoryEnum.Bugger, name = "블랙라벨폴인치즈버거", Image = @"/Assets/bbq_c.png", Price = 7500, Count = 1 },
                            new Product() { Category = CategoryEnum.Drink, name = "콜라", Image = @"/Assets/cola.png", Price = 2000, Count = 1 },
                            new Product() { Category = CategoryEnum.Drink, name = "사이다", Image = @"/Assets/cyida.png", Price = 2000, Count = 1 },
                            new Product() { Category = CategoryEnum.Side, name = "닭껍질 튀김", Image = @"/Assets/crustch.png", Price = 3200, Count = 1 },
                            new Product() { Category = CategoryEnum.Side, name = "치킨 텐더", Image = @"/Assets/tender.png", Price = 4000, Count = 1 }
                        });

                        dbContext.SaveChanges();
                    }
                    productList.AddRange(dbContext.Product);
                }
            }
            return productList;
        }

        public bool ModifyProduct(List<Product> products)
        {
            string dbName = "Product.db";
            try
            {
                using (var dbContext = new ProductContext())
                {
                    if (!File.Exists(dbName))
                    {
                        dbContext.Database.EnsureCreated();
                    }
                    foreach(Product prooduct in products)
                    {
                        dbContext.Product.Update(prooduct);
                        dbContext.SaveChanges();
                    }
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

public class ProductContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Product.db");
}