using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainScene.View.Windows
{
    /// <summary>
    /// Adminwindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Adminwindow : Window
    {
        public Adminwindow()
        {
            InitializeComponent();

            WindowStyle = WindowStyle.None; //Window의 타이틀, 버튼(Minimized, Maximized 등) 제거
            WindowState = WindowState.Maximized; // 모니터의 해상도 크기로 변경
            ResizeMode = ResizeMode.NoResize; // Window의 크기를 변경 불가s
        }
    }
}
