using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SFModels;

namespace SFDL
{
    //The repository class has a bunch of methods that we will use to get or store information from the database
    //Does not actually hold the data itself
    public class Repository : IRepository
    {
        //Filepath need to reference from the startup project (RRUI) and hence why we need to go back a folder and cd into RRDL
        private const string _filepath = "./../SFDL/Database/StoreFront.json";
        private string _jsonString;

        public StoreFront AddStoreFront(StoreFront s_ront)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<StoreFront> listOfStoreFronts = GetAllStoreFronts();

            //We added the new restaurant from the parameter 
            listOfStoreFronts.Add(s_ront);

            _jsonString = JsonSerializer.Serialize(listOfStoreFronts, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the storefront.json
            File.WriteAllText(_filepath,_jsonString);

            //Will return a storefront object from the parameter
            return s_ront;
        }


        public List<StoreFront> GetAllStoreFronts()
        {
            //File class will just read everything in the StoreFront.json and put it in a string
            _jsonString = File.ReadAllText(_filepath);

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }

        public StoreFront GetStoreFrontByID(int s_id)
        {
            throw new NotImplementedException();
        }

        public Product GetStoreFrontInventory(int s_id)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product p_duct)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Product> listOfProduct = GetAllProducts();

            //We added the new restaurant from the parameter 
            listOfProduct.Add(p_duct);

            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the storefront.json
            File.WriteAllText(_filepath,_jsonString);

            //Will return a storefront object from the parameter
            return p_duct;
        }


        public List<Product> GetAllProducts()
        {
            //File class will just read everything in the StoreFront.json and put it in a string
            _jsonString = File.ReadAllText(_filepath);

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Product>>(_jsonString);
        }

        public Product UpdateQuantity(Product p_qua)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int p_prodID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders(int o_id)
        {
            throw new NotImplementedException();
        }

        public Line_Item GetLine_ItemByID(int l_item)
        {
            throw new NotImplementedException();
        }



        public List<Line_Item> GetAllLine_Items(int l_storeID)
        {
            switch (l_storeID)
            {
                case 1:
                    _jsonString = File.ReadAllText(_filepath + "GeorgeWarehouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);

                case 2:
                    _jsonString = File.ReadAllText(_filepath + "TimToolHouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);

                default:
                    _jsonString = File.ReadAllText(_filepath + "GeorgeWarehouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);


            }
        }

        public Customer AddCustomer(Customer c_omer)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Customer> listOfCustomer = GetAllCustomers();

            //We added the new restaurant from the parameter 
            listOfCustomer.Add(c_omer);

            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions { WriteIndented = true });

            //This is what adds the storefront.json
            File.WriteAllText(_filepath, _jsonString);

            //Will return a storefront object from the parameter
            return c_omer;
        }


        public List<Customer> GetAllCustomers()
        {
            //File class will just read everything in the StoreFront.json and put it in a string
            _jsonString = File.ReadAllText(_filepath);

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public Customer GetCustomerByID(int c_id)
        {
            throw new NotImplementedException();
        }
    }
}