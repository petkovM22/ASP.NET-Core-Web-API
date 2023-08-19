using HomeworkClass03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkClass03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpGet("getOneBook")]
        public ActionResult<List<Book>> GetOneBook(int? index)
        {
            try
            {
                if ( index == null || index >= StaticDb.Books.Count)
                {
                    return BadRequest("Invalid index.");
                }

                Book getOneBook = StaticDb.Books.FirstOrDefault(x => x.Id == index);
                return Ok(getOneBook);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpGet("getByFilterAuthorOrTitle")]
        public ActionResult<List<Book>> GetByAuthorOrTitle(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StaticDb.Books;
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> bookTitle = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return Ok(bookTitle);
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> bookAuthor = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return Ok(bookAuthor);
                }

                List<Book> filteredBooks = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())
                                                                  && x.Title.ToLower().Contains(title.ToLower())).ToList();
                return Ok(filteredBooks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpPost]
        public IActionResult AddBooks([FromBody] Book book)
        {
            try
            {
                if(string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("The book must have an author.");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("The book must have a title.");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }
    }
}
