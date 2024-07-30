using GroceryStore.Business.Interfaces;


namespace GroceryStore.Business.Service
{
    public class StoreManager : IStoreManager
    {
        public void ShowStoreMenu()
        {
            Console.WriteLine("1. Show store inventory");
            Console.WriteLine("2. Add item(s) to cart");
            Console.WriteLine("3. Show items in your cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Leave store");
        }
        public void HandleUserInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    //TODO - list store inventory
                    break;
                case "2":
                    //TODO - add item to cart
                    break;
                case "3":
                    //TODO - get cart items
                    break;
                case "4":
                    //TODO - checkout
                    break;
            }

        }
    }
}
