using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIspit.Data;
using MVCIspit.Models;

namespace MVCIspit.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            // Fetch TodoList items associated with the specific user
            List<TodoList> todoList = _dbContext.TodoList
                .Where(t => t.UserId == userId)
                .ToList();

            return View(todoList);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(TodoList todoList)
        {
            var userId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            { 
                todoList.UserId = userId;   

                _dbContext.TodoList.Add(todoList);
                _dbContext.SaveChanges();
            }

                return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Detail(int id) {
        //    TodoList todo = _dbContext.TodoList.FirstOrDefault((t) => t.Id == id);

        //    if(todo == null) return NotFound(); 

        //    return View(todo);
        //}
        [HttpGet]
        public IActionResult Detail(int id)
        {
            TodoList todo = _dbContext.TodoList
                .Include(t => t.Tasks) // Eagerly load the tasks
                .FirstOrDefault(t => t.Id == id);

            if (todo == null)
                return NotFound();

            return View(todo);
        }


    }
}
