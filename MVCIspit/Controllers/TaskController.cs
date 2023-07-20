using Microsoft.AspNetCore.Mvc;
using MVCIspit.Data;
using MVCIspit.Models;

namespace MVCIspit.Controllers
{
    public class TaskController : Controller
    {
        public ApplicationDbContext _dbContext;

        public TaskController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int id)
        {
            if (id == 0) return NotFound();

            var todoList = _dbContext.TodoList.FirstOrDefault(o => o.Id == id);

            if (todoList == null) return NotFound();

            return View(todoList.Tasks);

       
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewData["TodoId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tasks task )
        {

            Tasks newTask = new Tasks() {
                Name = task.Name,   
                TodoId = task.TodoId,
                IsCompleted = false
            };

            _dbContext.Task.Add(newTask);
            _dbContext.SaveChanges();
            
            //return View();
            return RedirectToAction("Detail", "Todo", new { id = task.TodoId });
        }

       public IActionResult Detail(int id)
        {
            Tasks task = _dbContext.Task.FirstOrDefault(t => t.Id == id);     

            return View(task);
        }
        [HttpPost]
        public IActionResult Update(Tasks task) {
            
            Tasks dbTask = _dbContext.Task.FirstOrDefault(t => t.Id == task.Id);

            if (dbTask == null) return NotFound();

            dbTask.Name = task.Name;
            dbTask.TodoId = task.TodoId;
            dbTask.IsCompleted = task.IsCompleted;
            dbTask.Id = task.Id;
            
            _dbContext.Update(dbTask);
            _dbContext.SaveChanges(true);

            return RedirectToAction("Detail", "Todo", new { id = task.TodoId });
        }

    }
}
