using MainScene.DBManagerImpl;
using MainScene.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainScene.Repository
{
    public class SettlementRepository
    {
        private OrderDBManager orderDBManager;

        public SettlementRepository(OrderDBManager orderDBManager)
        {
            this.orderDBManager = orderDBManager;
        }

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

        private List<Order> GetOrderHistoryList()
        {
            var orderList = orderDBManager.GetOrderList();

            foreach (var order in orderList)
            {
                order.Payment = orderDBManager.GetPaymeent(order.Index);
                order.Products = orderDBManager.GetOrderedProductList(order.Index);
                order.Seat = order.IsTakeout ? null : orderDBManager.GetUsedSeat(order.Index);
            }

            return orderList;
        }
    }
}

