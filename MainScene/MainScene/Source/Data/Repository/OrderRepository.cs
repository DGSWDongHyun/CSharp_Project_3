using MainScene.DBManagerImpl;
using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainScene.Repository
{
    public class OrderRepository
    {
        private OrderDBManager orderDBManager;

        public OrderRepository(OrderDBManager orderDBManager) => this.orderDBManager = orderDBManager;

        public List<Order> GetOrderHistoryList()
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

        public int SaveOrder(Order order)
        {
            var IsSuccessSaveOrder = orderDBManager.SaveOrder(order);
            var IsSuccessSaveProduct = orderDBManager.SaveOrderedProduct(order.Products, order.Index);
            var IsSuccessSavePayment = orderDBManager.SavePayment(order.Payment, order.Index);
            var IsSuccessSaveSeat = order.IsTakeout ? true : orderDBManager.SaveUsedSeat(order.Seat, order.Index);

            return (IsSuccessSaveOrder && IsSuccessSaveProduct && IsSuccessSavePayment && IsSuccessSaveSeat) ? order.Index : -1;
        }

        public Dictionary<CategoryEnum, List<Product>> GetOrderHistoryByCategory()
        {
            return DivideProductListByCategory(GetOrderHistoryList());
        }

        public List<Order> GetOrderListByDate(DateTime date)
        {
            var orderlist = GetOrderHistoryList().Where(x => x.Payment.PaymentTime.Year == date.Year &&
                                                        x.Payment.PaymentTime.Month == date.Month &&
                                                        x.Payment.PaymentTime.Day == date.Day).ToList();


            return orderlist;
        }

        private Dictionary<CategoryEnum, List<Product>> DivideProductListByCategory(List<Order> orderHistoryList)
        {
            Dictionary<CategoryEnum, List<Product>> tempDividedOrderHistoryList = new Dictionary<CategoryEnum, List<Product>>();

            //Eum의 길이
            int length = System.Enum.GetValues(typeof(CategoryEnum)).Length;

            //orderList to product mapping
            List<Product> tempProductList = new List<Product>();

            foreach (Order order in orderHistoryList)
            {
                tempProductList.AddRange(order.Products);
            }

            //divide products by category
            int count = 0;
            while (count <= length)
            {
                CategoryEnum tempCategoryEnum = (CategoryEnum)count;

                List<Product> dividedProductList = tempProductList.Where(x => x.Category == tempCategoryEnum).ToList();

                tempDividedOrderHistoryList.Add(tempCategoryEnum, dividedProductList);

                count++;
            }

            return tempDividedOrderHistoryList;
        }
    }
}
