using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActivityPlanner.Validations;

namespace ActivityPlanner.Models
{
    public class User
    {
        [Key] //Primary Key for User class
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage="First Name must be 2 characters or more")]
        public string FirstName {get;set;}


        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage="Last Name must be 2 characters or more")]
        public string LastName {get;set;}

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Email")]
        public string Email {get;set;}


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        [StrongPassword]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password", ErrorMessage="Password & Confirmation do not match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //====== SETTING 1 : M RELATIONSHIPS =======
        //A User can plan many Activities
        //An Activity can be planned only by one User
        //1:M COLLECTION NAV PROP of the dependent entity type (Activity)
        // NOT STORED IN THE DATABASE
        //Below is the list of activities a given user planned (created)
        public List<Activy> MyPlanned { get; set; } 

        //====== SETTING M : M RELATIONSHIPS =======
        //A User can take part in many activities
        //An Activity can be enjoyed by many Users
        //M:M COLLECTION NAV PROP of the joigning entity type
        // NOT STORED IN THE DATABASE
        //Below is the list of activities a given user will take part into
        public List<Assoc> MyActs { get; set; }

    }
}