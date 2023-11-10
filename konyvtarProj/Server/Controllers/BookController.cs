using konyvtarProj.Server.Data;
using konyvtarProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace konyvtarProj.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public BookController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetBooks()
            {
                var books = await _context.Boooks.ToListAsync();
                return Ok(books);
            }

        [HttpGet("{LibNumber}")]
        public async Task<ActionResult<Books>> GetBookDetails(int id)
        {
            var book = await _context.Boooks.FirstOrDefaultAsync(x => x.LibNumber == id);
            
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook (Books book)
        {
            _context.Boooks.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookDetails),book,book.LibNumber);
        }

        [HttpPut("{LibNumber}")]
        public async Task<IActionResult> UpdateBook(Books book,int id)
        {
            var bookEx = await _context.Boooks.FirstOrDefaultAsync(x => x.LibNumber == id);

            if(bookEx == null)
            {
                return NotFound();
            }
            bookEx.Name = book.Name;
            bookEx.Author = book.Author;
            bookEx.Publisher = book.Publisher;
            bookEx.PublishDate = book.PublishDate;  
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("LibNumber")]
        public async Task<IActionResult> Deletebook(int id)
        {
            var bookEx = await _context.Boooks.FirstOrDefaultAsync(x => x.LibNumber == id);

            if (bookEx == null)
            {
                return NotFound();
            }
            _context.Boooks.Remove(bookEx);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
