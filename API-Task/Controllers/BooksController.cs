using API_Task.Data;
using API_Task.DTOs.Book;
using API_Task.DTOs.Category;
using API_Task.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = _context.Books.ToList();

            return new JsonResult(books.ToList());
        }

        [HttpPost]
        public IActionResult Create(DTOBookCreate data)
        {
            if (!ModelState.IsValid) return BadRequest("Name is not specified");

            Book newB = new Book()
            {
                Author = data.Author,
                Name = data.Name,
                CategoryId = data.CategoryId,
                CostPrice = data.CostPrice,

            };

            _context.Books.Add(newB);
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update(DTOBookUpdate data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Book? existing = _context.Books.FirstOrDefault(x => x.Id == data.Id);

            if (existing is null) return NotFound("Category Not Found");

            existing.UpdatedAt = DateTime.Now;
            existing.Name = data.Name;
            existing.CostPrice = data.CostPrice;
            existing.Price = data.Price;
            existing.Author = data.Author;
            existing.CategoryId = existing.CategoryId;

            _context.Books.Update(existing);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DTOBookDelete data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Book? existing = _context.Books.FirstOrDefault(x => x.Id == data.Id);

            if (existing is null) return NotFound("Category Not Found");


            _context.Books.Remove(existing);

            _context.SaveChanges();

            return NoContent();

        }
    }
}
