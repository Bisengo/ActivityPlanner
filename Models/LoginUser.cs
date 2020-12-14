using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityPlanner.Models
{
    public class LoginUser
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password")]
        public string LoginPassword {get;set;}
    }

}
