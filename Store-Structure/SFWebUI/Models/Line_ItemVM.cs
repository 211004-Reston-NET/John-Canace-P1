using SFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Models
{
    public class Line_ItemVM
    {

        public Line_ItemVM()
        {

        }
        public Line_ItemVM(Line_Item l_item)
        {
            this.lineItemProductNameID = l_item.lineItemProductNameID;
            this.lineItemList = l_item.lineItemList;
            this.lineStoreID = l_item.LineStoreID;
            this.lineOrderListID = l_item.LineOrderListID;
            this.lineItemQuantity = l_item.Quantity;
        }


        public int lineItemProductNameID { get; set; }

        [Required]
        public string lineItemList { get; set; }

        [Required]
        public int lineStoreID { get; set; }

        [Required]
        public int lineOrderListID { get; set; }

        public int lineItemQuantity {  get; set;}

        public int OrderList { get; set;  }
    }
}