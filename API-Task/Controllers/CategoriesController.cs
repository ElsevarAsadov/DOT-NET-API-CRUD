using API_Task.Data;
using API_Task.DTOs.Category;
using API_Task.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _context.Categories.ToList();

            return new JsonResult(categories.ToList());
        }

        [HttpPost]
        public IActionResult Create(DTOCategoryCreate data)
        {
            if (!ModelState.IsValid) return BadRequest("Name is not specified");

            Category newC = new Category() {
            
                Name = data.Name,
            };

            _context.Categories.Add(newC);
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update(DTOCategoryUpdate data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Category? existing = _context.Categories.FirstOrDefault(x => x.Id == data.Id);

            if (existing is null) return NotFound("Category Not Found");

            existing.UpdatedAt = DateTime.Now;
            existing.Name = data.Name;

            _context.Categories.Update(existing);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DTOCategoryDelete data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Category? existing = _context.Categories.FirstOrDefault(x => x.Id == data.Id);

            if (existing is null) return NotFound("Category Not Found");


            _context.Categories.Remove(existing);

            _context.SaveChanges();

            return NoContent();

        }
    }
}
