using GroceryStore.Business.Interfaces;
using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;

namespace GroceryStore.Business.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public IEnumerable<Item> GetStoreInventory()
        {
            
            if (_inventoryRepository.GetStoreInventory().Count() > 0)
            {
                return _inventoryRepository.GetStoreInventory();
            }
            else
            {
                InitializeStoreInventory();
                return _inventoryRepository.GetStoreInventory();
            }

        }
        public List<Item> InitializeStoreInventory()
        {
            return _inventoryRepository.InitializeStoreInventory();
        }
        //Future implementation AddItemToInventory
    }
}
