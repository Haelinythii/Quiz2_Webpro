using BewareTask.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BewareTask.Controllers
{
    public class UserController : Controller
    {

        public ActionResult CreateUser(user usr)
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    var check = database.users.FirstOrDefault(s => s.email == usr.email);
                    if (check == null)
                    {
                        database.Configuration.ValidateOnSaveEnabled = false;
                        database.users.Add(usr);
                        database.SaveChanges();
                        return RedirectToAction("Login", "Home", new { area = "" });
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                        return RedirectToAction("Register", "Home", new { area = "" });
                    }
                }
            }
            return RedirectToAction("Register", "Home", new { area = "" });
        }

        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    var data = database.users.Where(s => s.email.Equals(email) && s.password.Equals(password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["email"] = data.FirstOrDefault().email;
                        Session["userID"] = data.FirstOrDefault().id;
                        return RedirectToAction("Index", "Task", new { area = "" });
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login", "Home", new { area = "" });
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}