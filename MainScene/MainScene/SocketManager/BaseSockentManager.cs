using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.SocketManager
{
    class BaseSockentManager
    {
        public void send(string data)
        {
            TcpClient sockClient = new TcpClient("127.0.0.1", 9090);
            NetworkStream netWorkStream = sockClient.GetStream();

            byte[] sendData = Encoding.UTF8.GetBytes(data);

            netWorkStream.Write(sendData,0, data.Length);
        }

        public void reciver()
        {
            TcpClient sockClient = new TcpClient("127.0.0.1", 9090);
            NetworkStream netWorkStream = sockClient.GetStream();

            try
            {
                byte[] bytes = new byte[256];
                string data = null;


                int i;
                while ((i = netWorkStream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TCP READ ERROr");
            }
        }
    }
}
