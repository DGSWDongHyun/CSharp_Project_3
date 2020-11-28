using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.Util
{
    [Serializable]
    class SaveManager
    {
        string idText = string.Empty;

        public SaveManager(string id)
        {
            this.idText = id;
        }
        public string getId()
        {
            return idText;
        }
    }
}
