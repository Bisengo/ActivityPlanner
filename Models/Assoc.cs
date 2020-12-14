using System.ComponentModel.DataAnnotations;

namespace ActivityPlanner.Models
{
    //This is the joigning entity / table (class)
    public class Assoc
    {
        //Primary Key
        [Key]
        public int AssocId { get; set; }

        //Foreign Keys
        public int UserId  {get; set;}
        public int ActivyId { get; set; }

        // Navigation Properties
        // NOT STORED IN THE DATABASE
        public User ActEnjoyer { get; set;}
        public Activy UserChoice { get; set; }

    }
}