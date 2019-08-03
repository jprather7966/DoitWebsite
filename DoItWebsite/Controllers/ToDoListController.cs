using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoItWebsite.Models;

namespace DoItWebsite.Controllers
{
    public class ToDoListController : Controller
    {
        public IActionResult Index()
        {
            TaskRepository repo = new TaskRepository();
            List<TaskModel> AllTasks = repo.GetAllTasks();
            return View(AllTasks);
        }
        public IActionResult NewTask()
        {
            return View();
        }

        public IActionResult Add(TaskModel task)
        {
            TaskRepository repo = new TaskRepository();
            repo.AddTaskToDatabase(task);
            return RedirectToAction("Index", "ToDoList");
        }
    }
}