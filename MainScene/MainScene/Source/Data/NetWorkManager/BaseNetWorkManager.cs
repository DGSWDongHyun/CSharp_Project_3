using MainScene.Source.Data.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace MainScene.Source.Data.NetWorkManager
{
    public class BaseNetWorkManager
    {
        public bool Send(string data)
        {
            try
            {
                NetworkStream netWorkStream = App.tcpClient.GetStream();

                byte[] sendData = Encoding.UTF8.GetBytes(data);
                netWorkStream.Write(sendData, 0, sendData.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Recive(ReciveHandler reciveHandler)
        {
            try
            {
                NetworkStream netWorkStream = App.tcpClient.GetStream();

                byte[] bytes = new byte[256];
                int i;
                while ((i = netWorkStream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    var message = Encoding.UTF8.GetString(bytes, 0, i);
                    reciveHandler.ReciveData(message);
                }
            }
            catch {
                reciveHandler.ReciveData("오류빌생");
            }
        }

        public bool Connect()
        {
            App.tcpClient = new TcpClient();
            var result = App.tcpClient.BeginConnect(Constants.SERVER_URL, Constants.SERVER_PORT, null, null);
            var success =  result.AsyncWaitHandle.WaitOne(1000, true);

            if (success) { App.tcpClient.EndConnect(result); }

            return success;
        }
    }

    public interface ReciveHandler
    {
        void ReciveData(string data);
    }

}
