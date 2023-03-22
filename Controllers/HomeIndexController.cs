using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class HomeIndexController : Controller
    {
        // GET: HomeIndex
        //Registration Part starts

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Registration(User u)
        {
            if (ModelState.IsValid)
            {
                ZeroHungerEntities5 db = new ZeroHungerEntities5();
                var email = (from b in db.Users where b.Email == u.Email select b.Email).FirstOrDefault();
                var phone = (from b in db.Users where b.Phone == u.Phone select b.Phone).FirstOrDefault();
                if(email != null)
                {
                    ModelState.AddModelError("Error", "Email already exist");
                }
                else if(phone != null)
                {
                    ModelState.AddModelError("Error", "Phone already exist");
                }
                else
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                    Session["Success"] = "Registration successful";
                    return RedirectToAction("Login", "HomeIndex");
                }
            }
            return View(u);
        }
        //Registration Part end



        //Login Part starts

        [HttpGet]
        public ActionResult Login()
        {
            return View(new login());
        }

        [HttpPost]
        public ActionResult Login(login lo)
        {
            if (ModelState.IsValid)
            {
                ZeroHungerEntities5 db = new ZeroHungerEntities5();
                var user = (from b in db.Users where b.Email == lo.Email && b.Password == lo.Password && b.Type == lo.Type select b).SingleOrDefault();
                if (user != null)
                {
                    Session["Email"] = lo.Email;
                    ViewBag.email = Session["Email"];
                    if (lo.Type == "Admin")
                    {
                        return RedirectToAction("Home", "HomeIndex");
                    }
                    if (lo.Type == "Resturant")
                    {
                        return RedirectToAction("Index","HomeIndex");
                    }
                    else
                    {
                        return RedirectToAction("DHome", "HomeIndex");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("Error", "Incorrect! Email, password or user type");
                }
            }
            return View(lo);
        }

        //Login Part end



        //Logout Part action starts

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "HomeIndex");
            
        }

        //Logout Part action end

        



        //Admin Part actions Starts

        public ActionResult Home()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }


        public ActionResult RaInfo()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        public ActionResult RiInfo()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        public ActionResult Order()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Orders.ToList();
            return View(data);
        }

        public ActionResult AProfiles()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        public ActionResult AProfilesEdit()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult AProfilesEdit(User u)
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var email = (from b in db.Users where b.Email == u.Email select b.Email).FirstOrDefault();
            var phone = (from b in db.Users where b.Phone == u.Phone select b.Phone).FirstOrDefault();
            if (phone != null)
            {
                ModelState.AddModelError("Error", "Phone already exist");
            }
            else
            {
                db.Entry(User).CurrentValues.SetValues(u);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeIndex");
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult UserEdit(int id)
        {

            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var Order = (from u in db.Orders
                         where u.Id == id
                         select u).SingleOrDefault();

            return View(Order);
        }
        [HttpPost]
        public ActionResult UserEdit(Order o)
        {
            if (ModelState.IsValid)
            {
                ZeroHungerEntities5 db = new ZeroHungerEntities5();
                var user = (from O in db.Orders
                            where O.Id == o.Id
                            select O).SingleOrDefault();

                db.Entry(user).CurrentValues.SetValues(o);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(o);
        }

        //Admin Part actions Starts






        //Resturant Part Starts


        public ActionResult Index()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Orders.ToList();
            return View(data);
        }
        public ActionResult Profiles()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult ProfilesEdit()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Users.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult ProfilesEdit(User u)
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var email = (from b in db.Users where b.Email == u.Email select b.Email).FirstOrDefault();
            var phone = (from b in db.Users where b.Phone == u.Phone select b.Phone).FirstOrDefault();
            if (phone != null)
            {
                ModelState.AddModelError("Error", "Phone already exist");
            }
            else
            {
                db.Entry(User).CurrentValues.SetValues(u);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeIndex");
            }
            return View(u);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Order());
        }

        [HttpPost]
        public ActionResult Create(Order o)
        {
            if (ModelState.IsValid)
            {
                ZeroHungerEntities5 db = new ZeroHungerEntities5(); 
                db.Orders.Add(o);
                db.SaveChanges();
                Session["Success"] = "Registration successful";
                return RedirectToAction("Index", "HomeIndex");
            }
            return View(o);
        }

        public ActionResult Status()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Orders.ToList();
            return View(data);
        }
        
        public ActionResult cancel(int id)
        {

            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var Order = (from u in db.Orders
                         where u.Id == id
                         select u).FirstOrDefault();
            db.Orders.Remove(Order);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }
        


        //Resturant Part Starts





        //Delivery Part Starts

        public ActionResult DHome()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Orders.ToList();
            return View(data);
        }

        public ActionResult Delivery()
        {
            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var data = db.Orders.ToList();
            return View(data);
        }


        

        [HttpGet]
        public ActionResult ReqEdit(int id)
        {

            ZeroHungerEntities5 db = new ZeroHungerEntities5();
            var Order = (from u in db.Orders
                         where u.Id == id
                         select u).SingleOrDefault();

            return View(Order);
        }
        [HttpPost]
        public ActionResult ReqEdit(Order o)
        {
            if (ModelState.IsValid)
            {
                ZeroHungerEntities5 db = new ZeroHungerEntities5();
                var user = (from O in db.Orders
                            where O.Id == o.Id
                            select O).SingleOrDefault();

                db.Entry(user).CurrentValues.SetValues(o);
                db.SaveChanges();
                return RedirectToAction("DHome");
            }
            return View(o);
        }

        //Delivery Part ends


    }
}