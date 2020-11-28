using MainScene.DBManagerImpl;
using MainScene.Model;
using System.Collections.Generic;

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
    }
}
