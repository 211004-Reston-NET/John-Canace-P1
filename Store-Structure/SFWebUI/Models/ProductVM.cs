using SFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Models
{
    public class ProductVM
    {

        public ProductVM()
        {

        }
        public ProductVM(Product p_duct)
        {
            this.ProductName = p_duct.ProductName;
            this.ProductID = p_duct.ProductID;
            this.ProductPrice = p_duct.ProductPrice;
            this.ProductDescription = p_duct.ProductDescription;
            this.ProductCategory = p_duct.ProductCategory;
            this.StoreStoreID = p_duct.StoreStoreID;
            this.Quantity = p_duct.ProductQuantity;
        }


        public string ProductName { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        public string ProductDescription { get; set; }

        public int StoreStoreID { get; set; }

        public int Quantity { get; set; }
    }
}