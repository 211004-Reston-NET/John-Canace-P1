using SFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Models
{
    public class CustomerVM
    {

        public CustomerVM()
        {

        }
        public CustomerVM(Customer c_omer)
        {
            this.CustomerName = c_omer.CustomerName;
            this.CustomerAddress = c_omer.CustomerAddress;
            this.CustomerEmail = c_omer.CustomerEmail;
            this.CustomerPhoneNumber = c_omer.CustomerPhoneNumber;
            this.CustomerID = c_omer.CustomerID;
            
        }


        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public string CustomerPhoneNumber { get; set; }

        public int CustomerID { get; set; }
    }
}
