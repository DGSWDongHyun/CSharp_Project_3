using MainScene.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MainScene.SocketManager
{
    class SocketManager
    {
        private void SetOrderInfo(Order Order, int orderIdx)
        {
            JObject json = new JObject();
            JArray menuList = new JArray();

            json.Add("MSGType", 2);
            json.Add("id", "2210");
            json.Add("Content", "");
            json.Add("ShopName", "맥도날드");
            json.Add("OrderNumber", orderIdx);
            json.Add("Menus", menuList);

            String data = JsonConvert.SerializeObject(json);
        }
    }
}
