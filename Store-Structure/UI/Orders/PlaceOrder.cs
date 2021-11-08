using System;
using SFModels;
using SFBL;
using System.Collections.Generic;
using SFUI;

namespace SFUI
{   
    public class PlaceOrder : IMenu
    {
        private static Customer _omer = new Customer();
        private static Order _rder = new Order();
        private static Line_Item _item = new Line_Item();
        private static StoreFront _ront = new StoreFront();
        private IOrderBL _orderOrders;
        private ILine_ItemBL _orderLineItems;
        private ICustomerBL _orderCustomer;
        private IStoreFrontBL _orderStorefront;
        public PlaceOrder(IOrderBL o_orderBL, ICustomerBL o_customerBL, ILine_ItemBL o_lineItems, IStoreFrontBL o_storeFrontBL)
        {
            _orderOrders = o_orderBL;
            _orderCustomer = o_customerBL;
            _orderLineItems = o_lineItems;
            _orderStorefront = o_storeFrontBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Order");
            Console.WriteLine("CustomerID - " + _rder.CustomerID);
            Console.WriteLine("StoreFrontName - "+ _rder.StoreID);
            Console.WriteLine("List of Products - "+ _rder.ItemList);
            Console.WriteLine("TotalPrice - "+ _rder.TotalPrice);
            Console.WriteLine("[5] - Add Order");
            Console.WriteLine("[4] - Input value for CustomerName");
            Console.WriteLine("[3] - Input value for StoreFrontID");
            Console.WriteLine("[2] - Input values into list of Products");
            Console.WriteLine("[1] - Calculate Order's TotalPrice");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                try
                {
                    //_omerBL.AddCustomer(_omer);
                    Console.WriteLine("You have been added.");
                    return MenuType.PlaceOrder;
                }
                catch (System.Exception)
                {
                    
                    Console.WriteLine("You must input value to all fields above");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrder;
                }
                case "4":
                try
                {
                    Console.WriteLine("Input CustomerID");
                    _rder.CustomerID = Int32.Parse(Console.ReadLine());
                    return MenuType.PlaceOrder;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("You can only type numbers!");
                    return MenuType.PlaceOrder;
                }
                case "3":
                try{
                    Console.WriteLine("Input StoreFrontID");
                    _rder.StoreID = Int32.Parse(Console.ReadLine());
                    return MenuType.PlaceOrder;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("You can only type numbers!");
                    return MenuType.PlaceOrder;
                }
                case "2":
                    Console.WriteLine("Input Product IDs");
                    _omer.CustomerEmail = Console.ReadLine();
                    return MenuType.PlaceOrder;
                case "1":
                    Console.WriteLine("Type in the value for the Phone Number");
                    _omer.CustomerPhoneNumber = Console.ReadLine();
                    return MenuType.PlaceOrder;
                case "0":
                    return MenuType.PlaceOrder;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrder;
            }
        }
    }
}










//List<Line_Item> = listofLineItems = Line_Item.GetAllLine_Items(StoreFrontSingleton.order.StoreID);