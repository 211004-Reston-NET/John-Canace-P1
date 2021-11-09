using System;
using System.Text.RegularExpressions;

namespace SFModels
{
    public class Line_Item
    {
        
        private Product _prods;
        private int _quant;
        public string lineItemName;

        public string lineItemList {get; set; }
        
        public int LineStoreID {get; set;}
        
        public int LineOrderListID {get; set;} 

        public int lineItemProductNameID {get; set;}

        public Product Product {get{return _prods;}set{_prods = value;}}

        public int Quantity { get{return _quant;} set{_quant = value;} }

        //public virtual Product LineItemname { get; set; }
        public virtual Order LineOrderList { get; set; }
        public virtual StoreFront LineStore { get; set; }

        public override string ToString()
        {
            return $"ProductID: {lineItemProductNameID}\nQuantity: {Quantity}";
            //return $"Quantity: {Quantity}";
        }

    }
}

