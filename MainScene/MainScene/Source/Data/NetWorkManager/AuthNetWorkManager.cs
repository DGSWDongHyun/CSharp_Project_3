using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Source.Data.NetWorkManager
{
    public class AuthNetWorkManager: BaseNetWorkManager
    {
        private string GetLoginInfo()
        {
            JObject json = new JObject();
            JArray menuList = new JArray();

            json.Add("MSGType", 0);
            json.Add("id", "2215");
            json.Add("Content", "");
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Menus", "");

            return JsonConvert.SerializeObject(json);
        }

        public void PostLogin()
        {
            Send(GetLoginInfo());
        }
    }
}
