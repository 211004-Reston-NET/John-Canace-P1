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

        Customer AddCustomer(Customer c_omer);

        List<Customer> GetAllCustomers();

        Customer GetCustomerByID(int c_id);

        Line_Item GetLine_ItemByID(int i_item);
        List<Line_Item> GetAllLine_Items(int l_storeID);

        List<Order> GetAllOrders(int o_id);

        Product AddProduct(Product P_duct);

        List<Product> GetAllProducts();

        Product GetStoreFrontInventory(int s_id);

        Product GetProductByID(int p_prodID);

        Product UpdateQuantity(Product p_qua);


    }
}