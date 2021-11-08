using System;
using System.Collections.Generic;
using SFBL;
using SFModels;

namespace SFUI
{
    public class ShowStoreFront : IMenu
    {
        public static StoreFront _findront = new StoreFront();
        //private static StoreFront _ront = new StoreFront();
        private IStoreFrontBL _rontBL;
        private IProductBL _ductBL;
        public ShowStoreFront(IStoreFrontBL p_rontBL, IProductBL p_ductBL)
        {
            _rontBL = p_rontBL;
            _ductBL = p_ductBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Storefronts");
            List<StoreFront> listOfStoreFronts = _rontBL.GetAllStoreFronts();

            foreach (StoreFront ront in listOfStoreFronts)
            {
                Console.WriteLine("====================");
                Console.WriteLine(ront);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[2] - Increase Product Quantity");
            Console.WriteLine("[1] - Search StoreFront");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            List<StoreFront> listOfStoreFronts = _rontBL.GetAllStoreFronts();
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    Console.WriteLine("Enter the Product ID");
                    try
                    {
                        int ProductID = Int32.Parse(Console.ReadLine());
                        Product proFound = _ductBL.GetProductByID(ProductID);

                        Console.WriteLine("How much you want to add?");
                        int addedRating = Int32.Parse(Console.ReadLine());

                        _ductBL.UpdateQuantity(proFound, addedRating);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please input a number and not a character!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowStoreFront;
                    }
                        return MenuType.ShowStoreFront;
                case "1":
                try
                {
                    Console.WriteLine("Input StoreFront Name");
                    string inputname = Console.ReadLine();
                    foreach (StoreFront ront in listOfStoreFronts)
                    {
                        if (inputname == ront.StoreFrontName)
                        {
                            StoreFrontSingleton.StoreFrontID = ront.StoreFrontID;
                        }

                    }
                    //_findront.StoreFrontName = Console.ReadLine();
                    return MenuType.StoreFrontShown;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("That is not an address!");
                    return MenuType.ShowStoreFront;
                }
                case "0":
                    return MenuType.StoreMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowStoreFront;
            }
        }
    }
}