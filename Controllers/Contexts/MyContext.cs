using Microsoft.EntityFrameworkCore;
using ActivityPlanner.Models;


namespace ActivityPlanner.Contexts
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

	    // LoginUser class does not go into the database
	    // "users" table is represented by this DbSet "Users"
        public DbSet<User> Users {get;set;}
        public DbSet<Activy> Activies {get;set;}
        public DbSet<Assoc> Assocs {get;set;}
    }
}
