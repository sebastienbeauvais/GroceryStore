
using GroceryStore.Models.Interfaces;


namespace GroceryStore.Models
{
    public class StoreItem : IStoreItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
