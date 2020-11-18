using MainScene.Util;
using System.Windows;

namespace MainScene
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static RepositoryController repositoryController = new RepositoryController();
        public static DBManagerController dbManagerController = new DBManagerController();
    }
}
