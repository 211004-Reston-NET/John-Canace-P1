using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SFModels;

namespace SFDL
{
    //The repository class has a bunch of methods that we will use to get or store information from the database
    //Does not actually hold the data itself
    public class ORepository : IORepository
    {
        //Filepath need to reference from the startup project (RRUI) and hence why we need to go back a folder and cd into RRDL
        private const string _filepath = "./../SFDL/Database/Order.json";
        private string _jsonString;

        


        public List<Order> GetAllOrders(int o_id)
        {
            throw new NotImplementedException();
        }

        //Order IORepository.AddOrder(Customer s_customer, Order o_rder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}