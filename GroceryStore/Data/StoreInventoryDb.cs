using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Data
{
    public class StoreInventoryDb : IStoreInventoryDb
    {
        public List<IStoreItem> Inventory { get; } = new List<IStoreItem>
        {
            new StoreItem { Id = 1, Name = "Apple", Price = 0.50 },
            new StoreItem { Id = 2, Name = "Banana", Price = 0.20 },
            new StoreItem { Id = 3, Name = "Carrot", Price = 0.10 },
            new StoreItem { Id = 4, Name = "Tomato", Price = 0.30 },
            new StoreItem { Id = 5, Name = "Milk", Price = 1.50 },
            new StoreItem { Id = 6, Name = "White Bread", Price = 3.00 },
            new StoreItem { Id = 7, Name = "Whole Wheat Bread", Price = 3.50 },
            new StoreItem { Id = 8, Name = "Eggs (12)", Price = 7.99 },
            new StoreItem { Id = 9, Name = "Eggs (6)", Price = 4.50 },
            new StoreItem { Id = 10, Name = "Coffee Beans", Price = 3.39 },
            new StoreItem { Id = 11, Name = "Brown Sugar", Price = 4.59 },
            new StoreItem { Id = 12, Name = "Oatmeal", Price = 5.99 },
            new StoreItem { Id = 13, Name = "Peanut Butter", Price = 2.50 },
            new StoreItem { Id = 14, Name = "Oat Milk", Price = 4.50 },
            new StoreItem { Id = 15, Name = "Cheddar Cheese", Price = 4.49 },
            new StoreItem { Id = 16, Name = "Salmon", Price = 15.99 },
            new StoreItem { Id = 17, Name = "Chicken", Price = 12.99 },
            new StoreItem { Id = 18, Name = "Wagyu Beed", Price = 105.99 }
        };

    }
}
