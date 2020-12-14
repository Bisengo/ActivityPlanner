using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActivityPlanner.Validations;

namespace ActivityPlanner.Models
{
    public class Activy
    {
        [Key] //Primary Key for Activity class
        public int ActivyId { get;set; }

        [Required(ErrorMessage="Title is required")]
        [MinLength(2,ErrorMessage="Title must be at least 2 characters")]
        public string Title { get;set; }

        [Required(ErrorMessage = "Activity Date & Time is required")]
        [Display(Name = "Date and Time")]
        [NoPastDate]
        public DateTime ActDateTime {get;set;}

        [Required(ErrorMessage="Duration is required")]
        [Display(Name = "Activity Duration")]
        public int Duration { get; set;}

        public string DurationUnit { get; set; }
        
        [Required(ErrorMessage="Description is required")]
        [MinLength(10,ErrorMessage="Title must be at least 10 characters")]
        public string Description { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        [NotMapped]
        public int NumberDays { get; set;}

    //====== SETTING 1 : M RELATIONSHIP (ORGANIZING, PLANNING) =======
        //A User can plan (organize) many Activities
        //An Activity can be planned only by one User
        //Foreign Key = Principal Key of the principal entity (User)
        public int UserId  {get;set;}

        //REFERENCE NAV PROP of the principal entity type (User)
        // NOT STORED IN THE DATABASE
        public User Organizer { get; set; }

        
    //====== SETTING M : M RELATIONSHIP (TAKING PART) =======
        //A User can take part in many Activities
        //An Activity can be enjoyed by many Users
        //M:M COLLECTION NAV PROP of the joigning entity type
        // NOT STORED IN THE DATABASE
        //Below is the list of users who will take part in a given soccer activity
        public List<Assoc> Attendees { get; set; }
    }
}