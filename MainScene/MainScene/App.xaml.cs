using System.Windows;
using System.Net.Sockets;
using MainScene.Source.Data.Util;

namespace MainScene
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static TcpClient tcpClient { get; set; }

        public static NetWorkManagerController netWorkManagerController = new NetWorkManagerController();
        public static RepositoryController repositoryController = new RepositoryController();
        public static DBManagerController dbManagerController = new DBManagerController();
    }
}
