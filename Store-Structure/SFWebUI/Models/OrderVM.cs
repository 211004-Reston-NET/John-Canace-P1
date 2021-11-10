using SFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Models
{
    public class OrderVM
    {

        public OrderVM()
        {

        }
        public OrderVM(Order o_rder)
        {
            this.OrderList = o_rder.OrderList;
            this.TotalPrice = o_rder.TotalPrice;
            this.CustomerID = o_rder.CustomerID;
            this.StoreID = o_rder.StoreID;
        }


        public int OrderList { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int StoreID { get; set; }
    }
}