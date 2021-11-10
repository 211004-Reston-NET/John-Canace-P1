using SFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Models
{
    public class StoreFrontVM
    {

        public StoreFrontVM()
        {

        }
        public StoreFrontVM(StoreFront s_ront)
        {
            this.StoreFrontId = s_ront.StoreFrontID;
            this.StoreFrontName = s_ront.StoreFrontName;
            this.StoreFrontAddress = s_ront.StoreFrontAddress;
            this.ProductsList = s_ront.ProductsList;
        }


        public int StoreFrontId { get; set; }

        [Required]
        public string StoreFrontName { get; set; }

        [Required]
        public string StoreFrontAddress { get; set; }

        [Required]
        public string ProductsList { get; set; }
    }
}