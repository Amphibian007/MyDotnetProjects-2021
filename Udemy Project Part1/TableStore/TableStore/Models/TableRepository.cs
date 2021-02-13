using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableStore.Models
{
    public class TableRepository
    {
        public static List<Table> GetAll()
        {
            List<Table> allTables = new List<Table>()
            {
                new Table
                {
                    Id=1,
                    Name="Large table",
                    Category="Wooden",
                    Price=350
                },
                new Table
                {
                    Id=2,
                    Name="Small table",
                    Category="Plastic",
                    Price=250
                },
                new Table
                {
                    Id=3,
                    Name="Medium table",
                    Category="RFL",
                    Price=550
                },
                new Table
                {
                    Id=4,
                    Name="Dinning table",
                    Category="Plastic",
                    Price=650
                },
                new Table
                {
                    Id=5,
                    Name="Table of the month",
                    Category="Wooden",
                    Price=450
                },
            };
            return allTables;
        }
        public static Table GetSingleItem(string linkName)
        {
            var allTables = TableRepository.GetAll();
            foreach(var item in allTables)
            {
                if (item.LinkName == linkName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
