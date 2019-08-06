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
        public IActionResult ViewTask(int id)
        {
            TaskRepository repo = new TaskRepository();
            TaskModel Task = repo.GetTask(id);


            if (Task == null)
            {
                return View("TaskNotFound");
            }
            return View("Task", Task);

        }
        public IActionResult UpdateTask(int id)
        {
            TaskRepository repo = new TaskRepository();
            TaskModel task = repo.GetTask(id);
            return View(task);
        }
        public IActionResult Update(TaskModel task)
        {
            TaskRepository repo = new TaskRepository();
            repo.UpdateTask(task);
            return RedirectToAction("ViewTask", "TodoList", new { id = task.Id });
        }
        public IActionResult DeleteTask(int id)
        {
            TaskRepository repo = new TaskRepository();
            repo.DeleteTaskFromDatabase(id);
            return RedirectToAction("Index", "TodoList");
        }
    }
}