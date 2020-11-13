using MainScene.Model;
using MainScene.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainScene.RepositoryImpl
{
    class SettlementRepositoryImpl: SettlementRepository
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
            var orderHistoryList = GetOrderHistoryList().Where(x => x.Payment.paymentType == PayMentType.Card);
            var totalSales = 0;
            foreach (Order order in orderHistoryList)
            {
                totalSales += order.GetTotalDiscountPrice();
            }
            return totalSales;
        }
        //현금매출액
        public int GetCacheSales()
        {
            var orderHistoryList = GetOrderHistoryList().Where(x => x.Payment.paymentType == PayMentType.Cache);
            var totalSales = 0;
            foreach (Order order in orderHistoryList)
            {
                totalSales += order.GetTotalDiscountPrice();
            }
            return totalSales;
        }
        private List<Order> GetOrderHistoryList()
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
    }
}

