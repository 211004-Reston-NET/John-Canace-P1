using System;
using System.Collections.Generic;
using SFBL;
using SFModels;

namespace SFUI
{
    public class StoreOrders : IMenu
    {
        private IOrderBL _rderBL;

        public StoreOrders(IOrderBL o_rderBL)
        {
            _rderBL = o_rderBL;
        }

        public void Menu()
        {
            Console.WriteLine("Order List");
            List<Order>listofRder = _rderBL.GetAllOrders(StoreFrontSingleton.StoreFrontID);

            foreach(Order rder in listofRder)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rder);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return MenuType.StoreFrontShown;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreInventory;
            }
        } 
    }
}