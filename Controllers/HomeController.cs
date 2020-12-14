using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ActivityPlanner.Models;
using ActivityPlanner.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ActivityPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext { get; set; }

        // Initializing a PasswordHasher object, providing our User class as its type
        private PasswordHasher<User> regHasher = new PasswordHasher<User>();
        // Initializing a PasswordHasher object, providing our LoginUser class as its type
        private PasswordHasher<LoginUser> logHasher = new PasswordHasher<LoginUser>();

        public  User GetUserInDb()
        {
            return dbContext.Users.FirstOrDefault( u =>  u.UserId == HttpContext.Session.GetInt32("loggedinId"));
        }
        //Injecting our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        //Method for registering a new user (User object called reg.Register)
        [HttpPost("register")]
        public IActionResult Register(UserForm reg)
        {
             //Checking if email is already in use
             // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a user exists with provided email
                if(dbContext.Users.Any(u => u.Email == reg.Register.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided error message
                    ModelState.AddModelError("Email", "Email already in use. Find another one!");
            
                    // returning user to the registration form
                    return View("Index");
                }

                 // hashing newuser's password. The hashed password is reghash
                string reghash = regHasher.HashPassword(reg.Register, reg.Register.Password);
                // allocating the hashed password to newuser
                reg.Register.Password = reghash;
                
                // Save your user object to the database 
                // keeping newuser ID in session
                // and redirecting
                dbContext.Users.Add(reg.Register);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("loggedinId", reg.Register.UserId);
                return RedirectToAction("Dashboard");
            }
             // else if (!ModelState.IsValid)
             // returns user to the registration form
            return View("Index");
        } 

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                ViewBag.User = userInDb;
                List<Activy> AllActs = 
                    dbContext.Activies
                        .Include(a => a.Organizer)
                        .Include(a => a.Attendees)
                        .ThenInclude(asc => asc.ActEnjoyer)
                        .Where(a => a.ActDateTime >= DateTime.Now)
                        .OrderBy(a => a.CreatedAt)
                        .ToList();
                return View (AllActs); 
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(UserForm log)
        {
            if(ModelState.IsValid)
            {
	            // Checking if email exists in database
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == log.Login.LoginEmail);
                if(userInDb != null)
                {
                    // Checking if password matches user's password in database
                    var result = logHasher.VerifyHashedPassword(log.Login, userInDb.Password, log.Login.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("Login.LoginEmail", "Incorrect Email / Password");
                        ModelState.AddModelError("Login.LoginPassword", "Incorrect Email / Password");
                        return View("Index");
                    }
                    else
                    {
	                    // the user has been authenticated
	                    // We keep his/her UserId in Session
                        HttpContext.Session.SetInt32("loggedinId", userInDb.UserId);
                        return Redirect("Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login.LoginEmail", "Email Not Found, Check Your Spelling or register first?");
                    return View("Index");
                }
            }
            else
            {
                // else if (!ModelState.IsValid)
                // returns user to index.cshtml
                return View("Index");
            }
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                //we are using ViewBag
                //return View(userInDb);
                ViewBag.User = userInDb;
                return View();
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }


        // function converting the duration into number of day
        // depending on the duration unit: days, hours or minutes
        public static int DuraCalculation(Activy oneact)
        {
            if(oneact.DurationUnit == "Days")
            {
                oneact.NumberDays = oneact.Duration;
            }
            else if(oneact.DurationUnit == "Hours")
            {
                oneact.NumberDays = oneact.Duration/24;
            }
            else
            {
                oneact.NumberDays = oneact.Duration/(60 * 24);
            }
            return oneact.NumberDays;
        }

        // function checking a new activity is not clashing 
        // with an already booked activity
        // to be used in the "create act" method below
        public static bool IsTimeSlotAlreadyBooked (Activy newact, List<Activy> BookedActivities)
        {
            newact.NumberDays = DuraCalculation(newact);
            DateTime testStart = newact.ActDateTime;
            DateTime testEnd = newact.ActDateTime.AddDays(newact.NumberDays);
            foreach (var a in BookedActivities)
            {
                a.NumberDays = DuraCalculation(a);
                DateTime start = a.ActDateTime;
                DateTime end = a.ActDateTime.AddDays(a.NumberDays);
                // no part of the testStart or testEnd can overlap this block of time
                if (start <= testEnd && testStart <= end)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost("create/act")]
        public IActionResult CreateAct(Activy newact)
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                if(ModelState.IsValid)
                {
                    newact.UserId = userInDb.UserId;
                    dbContext.Activies.Add(newact);
                    dbContext.SaveChanges();
                    return Redirect("/dashboard");
                }
                else
                {
                    return View("New");
                }
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }

        [HttpGet("join/{activityId}")]
        public IActionResult Join(int activityId)
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                Assoc joigning = new Assoc();
                joigning.UserId = userInDb.UserId;
                joigning.ActivyId = activityId;
                dbContext.Assocs.Add(joigning);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Logout");
            }           
        }

        [HttpGet("leave/{activityId}")]
        public IActionResult Leave(int activityId)
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                Assoc leaving = dbContext.Assocs.FirstOrDefault(a => a.UserId == userInDb.UserId && a.ActivyId == activityId);
                dbContext.Assocs.Remove(leaving);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Logout");
            }           
        }

        [HttpGet("cancel/{activityId}")]
        public IActionResult Cancel(int activyId)
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                Activy cancelling = dbContext.Activies.FirstOrDefault(a => a.ActivyId == activyId);
                dbContext.Activies.Remove(cancelling);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Logout");
            } 
        }

        [HttpGet("show/{activityId}")]
        public IActionResult Show(int activityId)
        {
            User userInDb = GetUserInDb(); 
            if(userInDb != null)
            {
                ViewBag.User = userInDb;
                Activy Show = dbContext.Activies
                    .Include(a => a.Organizer)
                    .Include(a => a.Attendees)
                    .ThenInclude(asc => asc.ActEnjoyer)
                    .FirstOrDefault(a => a.ActivyId == activityId);
                return View(Show);
            }
            else
            {
                return RedirectToAction("Logout");
            } 
        }
    }
}
