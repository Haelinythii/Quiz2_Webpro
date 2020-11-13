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
                            "<td>" + a.TaskName + "</td>";
                            if (a.deadline.Year == 1)
                            {
                                result +=
                                "<td>" + "-" + "</td>";
                            }
                            else
                            {
                                result +=
                                "<td>" + a.deadline + "</td>";
                            }
                            result += "<td>" + "Edit  |   Delete" + "</td>" +
                                "</tr>";
                        }
                        ViewData["task"] = result;
                        ViewData["taskList"] = data;
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

        public ActionResult CreateTask(task task)
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    int uid = Convert.ToInt32(Session["userID"]);
                    task.idUser = uid;
                    database.tasks.Add(task);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditTask(int id)
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    var data = database.tasks.Where(c => c.id == id).First();
                    database.tasks.Remove(data);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int id)
        {
            if (ModelState.IsValid)
            {
                using (bewaretaskaspEntities3 database = new bewaretaskaspEntities3())
                {
                    var data = database.tasks.Where(c => c.id == id).First();
                    database.tasks.Remove(data);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}