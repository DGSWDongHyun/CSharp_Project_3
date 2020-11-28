using MainScene.Model;
using System.Collections.Generic;

namespace MainScene.DBManagerImpl
{
    public interface OrderDBManager
    {
        List<Order> GetOrderList();

        List<Product> GetOrderedProductList(int orderIdx);

        Payment GetPaymeent(int orderIdx);

        Seat GetUsedSeat(int orderIdx);


        bool SaveOrder(Order order);

        bool SaveOrderedProduct(List<Product> products, int orderIndex);

        bool SavePayment(Payment payment, int orderIndex);

        bool SaveUsedSeat(Seat seat, int orderIndex);
    }
}
