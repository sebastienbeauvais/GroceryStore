﻿using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;


namespace GroceryStore.Presentation
{
    class GroceryStore
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grocery Store! Please let us know what you would like to do\n");

            #region Class Instatiation
            //SOME CLASSES
            IStoreManager storeManager = new StoreManager();
            #endregion

            string userInput = "default";
            while (userInput != "5")
            {
                storeManager.ShowStoreMenu();
                userInput = Console.ReadLine();
                storeManager.HandleUserInput(userInput);
            }

            Console.WriteLine("Thank you for coming to the store. Please come again!");
            return;
        }
    }
}