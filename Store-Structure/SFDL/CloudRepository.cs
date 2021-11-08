using System.Collections.Generic;
using System.Linq;
using Entity = SFDL.Entities;
using Model = SFModels;
using System;
using System.Collections;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SFDL{

     public class CloudRespository : IRepository, ICRepository, ILRepository, IORepository, IPRepository
    {
        private Entity._211004restonnetdemoContext _context;
        //private string _jsonString;
        public CloudRespository(Entity._211004restonnetdemoContext p_context) 
        {
            _context = p_context;
        }

        public List<Model.StoreFront> GetAllStoreFronts()
        {
            //Method Syntax
            return _context.StoreFronts.Select(ront => 
                new Model.StoreFront()
                {
                    StoreFrontName = ront.StoreName,
                    StoreFrontID = ront.StoreStoreId,
                    StoreFrontAddress = ront.StoreAddress,
                }
            ).ToList();
        }

        public Model.StoreFront GetStoreFrontByID(int s_id)
        {
                
                Entity.StoreFront storToFind = _context.StoreFronts.FirstOrDefault(Store => Store.StoreStoreId == s_id);

                return new Model.StoreFront(){
                    StoreFrontName = storToFind.StoreName,
                    StoreFrontID = storToFind.StoreStoreId,
                    StoreFrontAddress = storToFind.StoreAddress,
                        
                };            
        }

        public List<Model.Product> GetStoreFrontInventory(int s_id)
        {
               var result = (from pro in _context.Products 
                                where pro.StoreStoreId == s_id 
                                select pro);
                
                List<Model.Product> listofproducts = new List<Model.Product>();

                foreach (Entity.Product pro in result)
                {
                    listofproducts.Add(new Model.Product(){
                        ProductID = pro.ProductProductnameId,
                        ProductName = pro.ProductName,
                        ProductPrice = pro.ProductPrice,
                        ProductCategory = pro.ProductCategory,
                        ProductDescription = pro.ProductDescription,
                        ProductQuantity = pro.ProductQuantity
                    });
                }
                return listofproducts;
        }    

       public Model.Customer AddCustomer(Model.Customer c_omer)
       {
           _context.Customers.Add
           (
               new Entity.Customer()
               {
                   CustomerName = c_omer.CustomerName,
                   CustomerAddress = c_omer.CustomerAddress,
                   CustomerEmail = c_omer.CustomerEmail,
                   CustomerPhone = c_omer.CustomerPhoneNumber,
               }
           );
           _context.SaveChanges();

           return c_omer;
       }

       public List<Model.Customer> GetAllCustomers()
       {
           return _context.Customers.Select(omer =>
                new Model.Customer()
                {
                    CustomerName = omer.CustomerName,
                    CustomerAddress = omer.CustomerAddress,
                    CustomerEmail = omer.CustomerEmail,
                    CustomerPhoneNumber = omer.CustomerPhone,
                    CustomerID = omer.CusCustomerId 
                }
            ).ToList();
       }

       public Model.Customer GetCustomerByID(int c_id)
        {
                Entity.Customer custToFind = _context.Customers.FirstOrDefault(Customer => Customer.CusCustomerId == c_id);

                return new Model.Customer(){
                    CustomerName = custToFind.CustomerName,
                    CustomerAddress = custToFind.CustomerAddress,
                    CustomerEmail = custToFind.CustomerEmail,
                    CustomerPhoneNumber = custToFind.CustomerPhone,
                    CustomerID = custToFind.CusCustomerId
                        
                };            
        }
       
       public List<Model.Line_Item> GetAllLine_Items(int l_storeID)
       {
           return _context.LineItems.Where(item => item.LineStore.StoreStoreId == l_storeID)
           .Select(item =>
                new Model.Line_Item()
                {
                    Product = new Model.Product(){
                        ProductName = item.LineItemname.ProductName,
                        ProductCategory = item.LineItemname.ProductCategory,
                        ProductDescription = item.LineItemname.ProductDescription,
                        ProductPrice = item.LineItemname.ProductPrice,
                        ProductQuantity = item.LineItemname.ProductQuantity,
                        ProductID = item.LineItemname.ProductProductnameId
                    },
                        lineItemProductNameID = item.LineItemnameId,
                        LineOrderListID = item.LineOrderListId,
                        LineStoreID = item.LineStoreId,
                        Quantity = item.LineItemquantity
                }
           ).ToList();
       }

       public Model.Line_Item GetLine_ItemByID(int l_item)
        {
            Entity.LineItem itemToFind = _context.LineItems.Find(l_item);
            
            return new Model.Line_Item(){
                lineItemProductNameID = itemToFind.LineItemnameId,
                LineOrderListID = itemToFind.LineOrderListId,
                LineStoreID = itemToFind.LineStoreId,
                Quantity = itemToFind.LineItemquantity,
                //This is the super ugly code that I avoided during demo that you need right now
                //So if you are lazy instead of doing a mapper class
                //This is all you need to do
                //Select statement to convert each element to Model.Review
                //ToList to convert it into a List collection instead of IEnumerable
                
            };
        }

       public List<Model.Order> GetAllOrders(int o_id)
       {
           //Entity.OrderList der= _context.OrderLists.Find(o_id);

           //return new List<Model.Order>(){
               //OrderList = der.OrderOrderListId,
                        //TotalPrice = der.OrderTotalprice,
                        //CustomerID = der.OrderCustomerId,
                        //StoreID = der.OrderStoreId,
           //}
           
           var result = (from ord in _context.OrderLists 
                                where ord.OrderStoreId == o_id 
                                select ord);
                
                List<Model.Order> listoforders = new List<Model.Order>();

                foreach (Entity.OrderList der in result)
                {
                    listoforders.Add(new Model.Order(){
                        OrderList = der.OrderOrderListId,
                        TotalPrice = der.OrderTotalprice,
                        CustomerID = der.OrderCustomerId,
                        StoreID = der.OrderStoreId,
                        ItemList = der.LineItems.Select(der => new Model.Line_Item(){
                            LineOrderListID = der.LineOrderListId,
                            LineStoreID = der.LineStoreId,
                            lineItemProductNameID = der.LineItemnameId,
                            Quantity = der.LineItemquantity

                        }).ToList()
                    });
                }
                return listoforders;
        }

       public Model.Product AddProduct(Model.Product p_duct)
       {
           _context.Products.Add
           (
               new Entity.Product()
               {
                   ProductProductnameId = p_duct.ProductID,
                   ProductName = p_duct.ProductName,
                   ProductPrice = p_duct.ProductPrice,
                   ProductDescription = p_duct.ProductDescription,
                   StoreStoreId = p_duct.StoreStoreID,
                   ProductCategory = p_duct.ProductCategory
               }
           );
           _context.SaveChanges();
           
           return p_duct;
       }

       public List<Model.Product> GetAllProducts()
       {
           return _context.Products.Select(duct =>
            new Model.Product()
            {
                ProductID = duct.ProductProductnameId,
                ProductName = duct.ProductName,
                ProductPrice = duct.ProductPrice,
                ProductDescription = duct.ProductDescription,
                ProductCategory = duct.ProductCategory
            }
            ).ToList();
       }

       public Model.Product GetProductByID(int p_prodID)
       {
           var result = _context.Products.AsNoTracking().FirstOrDefault<Entity.Product>(prod => prod.ProductProductnameId == p_prodID);
           return new Model.Product()
           {
               ProductName = result.ProductName,
               ProductPrice = result.ProductPrice,
               ProductDescription = result.ProductDescription,
               ProductCategory = result.ProductCategory,
               ProductID = result.ProductProductnameId,
               StoreStoreID = result.StoreStoreId,
               ProductQuantity = result.ProductQuantity
           };
       }

       public Model.Product UpdateQuantity(Model.Product p_qua)
        {
            //Converts Model Review into Entity Review
            Entity.Product quaUpdated = new Entity.Product() 
            {
                ProductProductnameId = p_qua.ProductID,
                ProductCategory = p_qua.ProductCategory,
                ProductDescription = p_qua.ProductDescription,
                ProductQuantity = p_qua.ProductQuantity,
                ProductName = p_qua.ProductName,
                ProductPrice = p_qua.ProductPrice,
                StoreStoreId = p_qua.StoreStoreID

            };

            //Updates the Entity Review based on the current Id it has
            //Checks other properties of entity to see if they changed
            //If they changed it will update it
            _context.Products.Update(quaUpdated);

            //Save the changes of the review
            _context.SaveChanges();

            return p_qua;
        }

    }
    
}