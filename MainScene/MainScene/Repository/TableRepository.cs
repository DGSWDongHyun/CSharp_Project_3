using MainScene.Model;
using System;
using System.Collections.Generic;


namespace MainScene.Repository
{
    public class TableRepository
    {
        public List<Table> GetTable()
        {
            List<Table> table = new List<Table>();

            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 1 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 2 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 3 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 4 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 5 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 6 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 7 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 8 });
            table.Add(new Table() { UsedTime = DateTime.Now, tablenum = 9 });

            return table;
        }
    }
}
