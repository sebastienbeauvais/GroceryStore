using GroceryStore.DataAccess.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface IInventoryService
    {
        IEnumerable<Item> GetStoreInventory();
        List<Item> InitializeStoreInventory();
        //Future implementation AddItemToInventory
    }
}
