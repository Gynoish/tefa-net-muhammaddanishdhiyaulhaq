using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TodoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Todo> GetTodos()
        {
            return context.Todos.OrderByDescending(c => c.Id).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = context.Todos.Find(id);
            if(todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult CreateTodo(TodoDto todoDto)
        {
            //submitted data is valid

            var otherTodo = context.Todos.FirstOrDefault(c => c.Deskripsi == todoDto.Deskripsi);
            if (otherTodo != null)
            {
                ModelState.AddModelError("Deskripsi", "Sudah Ada Deskripsi yang Serupa");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }


            var todo = new Todo
            {
                Judul = todoDto.Judul,
                Deskripsi = todoDto.Deskripsi,
                CreateAt = DateTime.Now,
            };

            context.Todos.Add(todo);
            context.SaveChanges();

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public IActionResult EditTodo(int id, TodoDto todoDto)
        {
            var otherTodo = context.Todos.FirstOrDefault(c => c.Id != id && c.Deskripsi == todoDto.Deskripsi);
            if (otherTodo != null)
            {
                ModelState.AddModelError("Deskripsi", "Sudah Ada Deskripsi yang Serupa");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var todo = context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Judul = todoDto.Judul;
            todo.Deskripsi = todoDto.Deskripsi;

            context.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            context.Todos.Remove(todo);
            context.SaveChanges();

            return Ok(todo);
        }
    }
}
