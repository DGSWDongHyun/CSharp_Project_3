using MainScene.Model;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Table = MainScene.Model.Table;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tablepage : Page
    {
        private List<Table> lstFood = new List<Table>()
        {
            new Table(){Idx = 1},

        };


        public Tablepage()
        {
            InitializeComponent();
        }
    }
}
