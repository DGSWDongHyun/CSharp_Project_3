using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Repository
{
    public interface SettlementRepository
    {
        int GetTotalSales();

        int GetDiscount();

        int GetSales();

        int GetCardSales();

        int GetCacheSales();
    }
}
