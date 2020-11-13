using BewareTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BewareTask.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    int uid = Convert.ToInt32(Session["userID"]);
                    var data = database.tasks.Where(c => c.idUser == uid).ToList();
                    if (data.Count() > 0)
                    {
                        string result = "";
                        int x = 1;
                        foreach (var a in data)
                        {
                            result += "<tr>" +
                            "<td>" + (x++).ToString() + "</td>" +
                            "<td>" + a.TaskName + "</td>" +
                            "<td>" + a.deadline + "</td>" +
                            "<td>" + "Edit  |   Delete" + "</td>" +
                            "</tr>";
                        }
                        ViewData["task"] = result;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            return View();
        }
    }
}