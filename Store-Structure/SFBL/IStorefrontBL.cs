using System.Collections.Generic;
using SFModels;

namespace SFBL
{
    public interface IStoreFrontBL
    {
        /// <summary>
        /// This will return a list of storefronts stored in the database
        /// It will also capitalize every name of the storefront
        /// </summary>
        /// <returns>It will return a list of storefronts</returns>
        List<StoreFront> GetAllStoreFronts();

        StoreFront GetStoreFrontByID(int s_id);

        
    }

    public interface ICustomerBL
    {        
        
        
        //Return list of customers stored in Database
        List<Customer> GetAllCustomers();

        //Adds a customer to the database
        Customer AddCustomer(Customer c_omer);

        Customer GetCustomerByID(int c_id);

        //Order AddOrder(Customer s_customer, Order o_rder);
    }

    public interface ILine_ItemBL
    {        
        
        
        //Return list of customers stored in Database
        List<Line_Item> GetAllLine_Items(int l_storeID);

        //Adds a customer to the database
        Line_Item GetLine_ItemByID(int l_item);
    }

    public interface IOrderBL
    {        
        
        
        //Return list of customers stored in Database
        List<Order> GetAllOrders(int o_id);
    }

    public interface IProductBL
    {        
        
        
        //Return list of customers stored in Database
        List<Product> GetAllProducts();

        //Adds a customer to the database
        Product AddProduct(Product p_duct);

        Product GetProductByID(int p_prodID);

        Product GetStoreFrontInventory(int s_id);

        Product UpdateQuantity(Product l_qua, int p_howMuchAdded);
    }
}