using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Varun_Banking.Models
{
    public enum AccountType
    {
        Saving,
        Current
    }
    public class VarunBank
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Customer Full Name")]
        [Required(ErrorMessage = "Please provide name of the register")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please select type of account")]
        [Display(Name = "Type of Account")]
        public AccountType AccountType { get; set; }

        [Display(Name = "Do you want us to contact")]
        public bool Contact { get; set; }

        [Required(ErrorMessage = "Please Provide the Mobile No")]
        [Display(Name = "Contact Number")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide the Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Enter the amount Rs")]
        [Range(5000, 100000, ErrorMessage = "Minimum balance in 5000")]
        public int Amount { get; set; }
    }
}
