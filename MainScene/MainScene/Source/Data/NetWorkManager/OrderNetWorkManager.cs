using MainScene.Model;
using MainScene.Source.Data.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace MainScene.Source.Data.NetWorkManager
{
    public class OrderNetWorkManager : BaseNetWorkManager
    {
        private string ConvertOrderInfo(Order order)
        {
            JObject data = new JObject();
            JArray menuList = new JArray();


            foreach (Product product in order.Products)
            {
                JObject menu = new JObject();

                menu.Add("Name", product.name);
                menu.Add("Count", product.Count);
                menu.Add("Price", product.FinalPrice);

                menuList.Add(menu);
            }

            data.Add("MSGType", 2);
            data.Add("Id", "2215");
            data.Add("Group", Properties.Settings.Default.isGroupMsg);
            data.Add("Content", "");
            data.Add("ShopName", "KFC");
            data.Add("OrderNumber", order.Index.ToString("000"));
            data.Add("Menus", menuList);

            return JsonConvert.SerializeObject(data);
        }

        private string ConvertMessage(string message)
        {
            JObject data = new JObject();
            data.Add("MSGType", 1);
            data.Add("Id", "2215");
            data.Add("Content", message);
            data.Add("ShopName", "KFC");
            data.Add("OrderNumber", "");
            data.Add("Menus", "");

            return JsonConvert.SerializeObject(data);
        }

        public void PostOrderInfo(Order order)
        {
            Send(ConvertOrderInfo(order));
        }

        public void PostTotalSalse(string message)
        {
            Send(ConvertMessage(message));
        }
    }

}
