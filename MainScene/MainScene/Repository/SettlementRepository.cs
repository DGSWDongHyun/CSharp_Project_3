using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainScene.Repository
{
    public class SettlementRepository
    {
        //총매출액
        public int GetTotalSales()
        {
            var orderHistoryList = GetOrderHistoryList();
            var totalSales = 0;
            foreach (Order order in orderHistoryList)
            {
                totalSales += order.GetTotalPrice();
            }
            return totalSales;
        }
        //할인액
        public int GetDiscount()
        {
            var orderHistoryList = GetOrderHistoryList();
            var totalDiscount = 0;
            foreach (Order order in orderHistoryList)
            {
                totalDiscount += order.GetTotalDiscountPrice();
            }
            return totalDiscount;
        }
        //순수 매출액
        public int GetSales()
        {
            return GetTotalSales() - GetDiscount();
        }
        //카드매출액
        public int GetCardSales()
        {
            var orderHistoryList = GetOrderHistoryList().Where(x => x.Payment.paymentType == PayMentType.Card).ToList();
            var totalSales = 0;
            foreach (Order order in orderHistoryList)
            {
                totalSales += order.GetTotalPrice();
            }
            return totalSales;
        }
        //현금매출액
        public int GetCacheSales()
        {
            var orderHistoryList = GetOrderHistoryList().Where(x => x.Payment.paymentType == PayMentType.Cache).ToList();
            var totalSales = 0;
            foreach (Order order in orderHistoryList)
            {
                totalSales += order.GetTotalPrice();
            }
            return totalSales;
        }
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

            foreach (var order in orderList)
            {
                order.Payment = GetPaymeent(order.Index);
                order.Products = GetOrderedProductList(order.Index);
            }

            return orderList;
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
    }
}

