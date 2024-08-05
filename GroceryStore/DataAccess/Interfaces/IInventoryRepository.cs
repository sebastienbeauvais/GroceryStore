using GroceryStore.DataAccess.Models;

namespace GroceryStore.DataAccess.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<Item> GetStoreInventory();
        List<Item> InitializeStoreInventory();
    }
}
