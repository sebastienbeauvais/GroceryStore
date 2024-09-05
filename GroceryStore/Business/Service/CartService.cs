using GroceryStore.Business.Interfaces;
using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;

namespace GroceryStore.Business.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public IEnumerable<CartItem> GetItemsInCart()
        {
            if(_cartRepository.GetItemsInCart().Count() > 0)
            {
                return _cartRepository.GetItemsInCart();
            }
            else
            {
                InitializeStoreCart();
                return _cartRepository.GetItemsInCart();
            }
        }

        public List<CartItem> InitializeStoreCart()
        {
            return _cartRepository.InitializeStoreCart();
        }
    }
}
