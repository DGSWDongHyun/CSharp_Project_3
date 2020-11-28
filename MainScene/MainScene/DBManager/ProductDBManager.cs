﻿using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScene.DBManagerImpl
{
    public interface ProductDBManager
    {
        List<Product> GetProduct();

        bool ModifyProduct(List<Product> products);
    }
}
