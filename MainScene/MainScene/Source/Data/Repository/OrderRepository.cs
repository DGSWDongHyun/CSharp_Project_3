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
        private ProductDBManager productDBManager;

        public OrderRepository(OrderDBManager orderDBManager, ProductDBManager productDBManager) {
            this.orderDBManager = orderDBManager;
            this.productDBManager = productDBManager;
        }

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

        public Dictionary<CategoryEnum, List<Product>> GetOrderedProductByCategory()
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

        public List<string> GetOrderedUserCodeList()
        {
            var orderHistoryList = GetOrderHistoryList();
            List<string> tempOrderedUserCodeList = new List<string>();

            foreach (Order order in orderHistoryList)
            {
                tempOrderedUserCodeList.Add(order.Payment.UserCode);
            }

            return tempOrderedUserCodeList.Distinct().ToList();
        }

        public List<Order> GetOrderListBySeat(Seat seat)
        {
            var orderListByTable = GetOrderHistoryList()
                .Where(x => !x.IsTakeout)
                .Where(x => x.Seat.seatNum == seat.seatNum).ToList();

            return orderListByTable;
        }

        public List<Product> GetOrderedProductListByUser(string userCode)
        {
            var productList = productDBManager.GetProduct();
            var orderHistoryList = GetOrderHistoryList();
            List<Product> orderedProductList = new List<Product>();

            var devidedOrderList = orderHistoryList.Where(x => x.Payment.UserCode.Equals(userCode)).ToList();

            foreach (var devidedOrder in devidedOrderList)
            {
                orderedProductList.AddRange(devidedOrder.Products);
            }

            foreach(var product in productList)
            {
                product.Count = orderedProductList.Where(x => x.name == product.name).Count();
            }

            return productList;
        }

        private Dictionary<CategoryEnum, List<Product>> DivideProductListByCategory(List<Order> orderHistoryList)
        {
            Dictionary<CategoryEnum, List<Product>> tempDividedOrderHistoryList = new Dictionary<CategoryEnum, List<Product>>();
            var productList = productDBManager.GetProduct();

            //Eum의 길이
            int length = System.Enum.GetValues(typeof(CategoryEnum)).Length;

            //orderList to product mapping
            List<Product> orderedProductList = new List<Product>();

            foreach (Order order in orderHistoryList)
            {
                orderedProductList.AddRange(order.Products);
            }

            //divide products by category
            int count = 0;
            while (count <= length)
            {
                CategoryEnum tempCategoryEnum = (CategoryEnum)count;

                List<Product> dividedOrderedProductListProductList = orderedProductList.Where(x => x.Category == tempCategoryEnum).ToList();

                foreach (var product in productList)
                {
                    product.Count = dividedOrderedProductListProductList.Where(x => x.name == product.name).Count();
                }

                tempDividedOrderHistoryList.Add(tempCategoryEnum, dividedOrderedProductListProductList);

                count++;
            }

            return tempDividedOrderHistoryList;
        }  
    }
}
