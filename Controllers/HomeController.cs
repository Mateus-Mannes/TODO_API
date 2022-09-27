using TodoApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using System.Linq;

namespace TodoApp.Controllers {
    [ApiController]
    public class HomeController : ControllerBase {
        [HttpGet("/")]
        public async Task<IActionResult> GetListAsync([FromServices] TodoAppDbContext db)
            => await db.Todos.AsNoTracking().ToListAsync();

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetAsync([FromServices] TodoAppDbContext db, int id){
            var todo = await db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(todo == null) return NotFound();
            return todo;
        }

        [HttpPost("/")]
        public async Task<IActionResult> CreateAsync([FromServices] TodoAppDbContext db, [FromBody] Todo todo){
            await db.Todos.AddAsync(todo);
            await db.SaveChangesAsync();
            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("/")]
        public async Task<IActionResult> UpdateAsync([FromServices] TodoAppDbContext db, [FromBody] Todo todo){
            var tod = await db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(tod == null) return NotFound();
            db.Todos.Update(todo);
            await db.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] TodoAppDbContext db, int id){
            var todo = await db.Todos.FirstOrDefaultAsync(x => x.Id ==id);
            if(todo == null) return NotFound();
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            return Ok(todo);
        }
    }
}