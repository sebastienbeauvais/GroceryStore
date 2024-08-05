using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;

namespace GroceryStore.DataAccess.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private static List<Item> _items = new List<Item>();
        public IEnumerable<Item> GetStoreInventory()
        {
            return _items;
        }
        public List<Item> InitializeStoreInventory() 
        {
            _items = new List<Item>
            {
                new Item { Id = 1, Name = "Apple", Price = 0.50 },
                new Item { Id = 2, Name = "Banana", Price = 0.20 },
                new Item { Id = 3, Name = "Carrot", Price = 0.10 },
                new Item { Id = 4, Name = "Tomato", Price = 0.30 },
                new Item { Id = 5, Name = "Milk", Price = 1.50 },
                new Item { Id = 6, Name = "White Bread", Price = 3.00 },
                new Item { Id = 7, Name = "Whole Wheat Bread", Price =3.50 },
                new Item { Id = 8, Name = "Eggs (12)", Price = 7.99 },
                new Item { Id = 9, Name = "Eggs (6)", Price = 4.50},
                new Item { Id = 10, Name = "Coffee Beans", Price = 3.39 },
                new Item { Id = 11, Name = "Brown Sugar", Price = 4.59 },
                new Item { Id = 12, Name = "Oatmeal", Price = 5.99 },
                new Item { Id = 13, Name = "Peanut Butter", Price = 2.50 },
                new Item { Id = 14, Name = "Oat Milk", Price = 4.50 },
                new Item { Id = 15, Name = "Cheddar Cheese", Price = 4.49 },
                new Item { Id = 16, Name = "Salmon", Price = 15.99 },
                new Item { Id = 17, Name = "Chicken", Price = 12.99 },
                new Item { Id = 18, Name = "Wagyu Beed", Price = 105.99 }
            };
            return _items;
        }
    }
}
