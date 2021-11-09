using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFModels
{
    public class Order
    {
        
        
        private List<Line_Item> _lineItems = new List<Line_Item>();
        public int OrderList {get; set; }
        public decimal TotalPrice {get; set; }

        public List<Line_Item> ItemList{get{return _lineItems;} set{_lineItems = value;} }
        //public string ItemList{get; set; }

        public int CustomerID {get; set; }

        public int StoreID {get; set; }

        public virtual Customer OrderCustomer { get; set; }
        public virtual StoreFront OrderStore { get; set; }

        public virtual ICollection<Line_Item> LineItems { get; set; }

         public override string ToString()
        {
            var outputString = $"ListName: {OrderList}\nTotalPrice: {TotalPrice}\nCustomerID: {CustomerID}\nStoreID: {StoreID}";

            foreach (var item in ItemList)
            {
                outputString += item.LineStoreID;
            }

            return outputString;
            //var outputString = *existing return string
            //foreach (var item in list)
            //{
            //    ouputString += item.*whatever*
            //}


        }

    }
}

