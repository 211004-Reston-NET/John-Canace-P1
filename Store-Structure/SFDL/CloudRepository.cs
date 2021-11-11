using System.Collections.Generic;
using System.Linq;
using SFDL;
using Model = SFModels;
using System;
using System.Collections;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SFDL{

     public class CloudRespository : IRepository
    {
        private _211004restonnetdemoContext _context;
        //private string _jsonString;
        public CloudRespository(_211004restonnetdemoContext p_context) 
        {
            _context = p_context;
        }

        public List<Model.StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.ToList();
        }

        public Model.StoreFront GetStoreFrontByID(int s_id)
        {
                      return _context.StoreFronts.Find(s_id);            
        }

        public Model.Product GetStoreFrontInventory(int s_id)
        {
            return _context.Products.Find(s_id);
        }    

       public Model.Customer AddCustomer(Model.Customer c_omer)
       {
           _context.Customers.Add(c_omer);

           _context.SaveChanges();

           return c_omer;
       }

       public List<Model.Customer> GetAllCustomers()
       {
           return _context.Customers.ToList();
       }

       public Model.Customer GetCustomerByID(int c_id)
        {
                return _context.Customers.Find(c_id);            
        }
       
       public List<Model.Line_Item> GetAllLine_Items(int l_storeID)
       {
           return _context.LineItems.ToList();
       }

       public Model.Line_Item GetLine_ItemByID(int l_item)
        {
            return _context.LineItems.Find(l_item); 
        }

       public List<Model.Order> GetAllOrders(int o_id)
       {
           return _context.OrderLists.ToList();
        }

       public Model.Product AddProduct(Model.Product p_duct)
       {
           _context.Products.Add(p_duct);
        
           _context.SaveChanges();
           
           return p_duct;
       }

       public List<Model.Product> GetAllProducts()
       {
           return _context.Products.ToList();
       }

       public Model.Product GetProductByID(int p_prodID)
       {
           return _context.Products.Find(p_prodID);
       }

       public Model.Product UpdateQuantity(Model.Product p_qua)
        {
            _context.Products.Update(p_qua);

            _context.SaveChanges();

            return p_qua;
        }

    }
    
}