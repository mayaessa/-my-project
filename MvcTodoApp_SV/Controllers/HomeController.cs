
using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class HomeController : Controller
    {
     
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "تدرب على MVC Design Pattern", IsComplete = false },
            new TaskItem { Id = 2, Title = "تدرب على N-tier Architecture", IsComplete = false },
            new TaskItem { Id = 3, Title = "تدرب على استخدام git", IsComplete = false },
        };

        /// <summary>
        /// يعرض القائمة الرئيسية للمهام
        /// </summary>
        public IActionResult Index()
        {
            return View(tasks);
        }

        /// <summary>
        /// إضافة مهمة جديدة
        /// </summary>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int newId = tasks.Max(t => t.Id) + 1;
                var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false };
                tasks.Add(newTask);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// تعيين مهمة كمكتملة
        /// </summary>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var foundTask = tasks.FirstOrDefault(t => t.Id == id);
            if (foundTask != null)
                foundTask.IsComplete = true;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// تعديل عنوان المهمة
        /// </summary>
        /// <param name="id">معرف المهمة</param>
        /// <param name="newTitle">العنوان الجديد</param>
        [HttpPost]
        public IActionResult EditTask(int id, string newTitle)
        {
      
            var foundTask = tasks.FirstOrDefault(t => t.Id == id);

           
            if (foundTask != null && !string.IsNullOrWhiteSpace(newTitle))
            {
               
                foundTask.Title = newTitle;
            }

            return RedirectToAction("Index");
        }
    }
}