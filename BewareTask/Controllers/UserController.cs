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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult CreateUser()
        //{
        //    using(bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
        //    {
                
        //    }
        //}
    }
}