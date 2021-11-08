using System.Collections.Generic;
using SFModels;

namespace SFDL
{
    public interface IRepository
    {
        /// <summary>
        /// This will return a list of storefronts stored in the database
        /// </summary>
        /// <returns>It will return a list of storefronts</returns>
        List<StoreFront> GetAllStoreFronts();

        StoreFront GetStoreFrontByID(int s_id);

        
    }

    public interface ICRepository
    {
        Customer AddCustomer(Customer c_omer);

        List<Customer> GetAllCustomers();

        Customer GetCustomerByID(int c_id);

        //Order AddOrder(Customer s_customer,Order o_rder);
    }

    public interface ILRepository
    {
        Line_Item GetLine_ItemByID(int i_item);
        List<Line_Item> GetAllLine_Items(int l_storeID);
    }

    public interface IORepository  
    {   
        List<Order> GetAllOrders(int o_id);
    }

    public interface IPRepository
    {
        Product AddProduct(Product P_duct);

        List<Product> GetAllProducts();

        List<Product> GetStoreFrontInventory(int s_id);

        Product GetProductByID(int p_prodID);

        Product UpdateQuantity(Product p_qua);
    }
}