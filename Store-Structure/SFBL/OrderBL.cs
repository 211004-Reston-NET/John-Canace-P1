using System;
using System.Collections.Generic;
using SFDL;
using SFModels;

namespace SFBL
{


    public class OrderBL :IOrderBL
    {
        private IRepository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// But later on the lecture, we can then switch our SFDL project to point to an actual database in the cloud and we don't have to touch anything else to
        /// have the implementation
        /// </summary>
        /// <param name="p_repo">It will pass in a Respository object</param>
        public OrderBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public List<Order> GetAllOrders(int o_id)
        {
            return _repo.GetAllOrders(o_id);
        }

        public Order AddOrder(Order o_order)
        {
            return _repo.AddOrder(o_order);
        }
    }
}