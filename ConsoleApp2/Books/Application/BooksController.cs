using Books.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksBusinessLogic _booksBusinessLogic;

        public BooksController(IBooksBusinessLogic logic)
        {
            if (logic == null)
                throw new ArgumentNullException(nameof(logic));

            _booksBusinessLogic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusinessLogic.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_booksBusinessLogic.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            _booksBusinessLogic.Insert(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            _booksBusinessLogic.Update(book);
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            _booksBusinessLogic.Delete(bookId);
            return Ok();
        }

        [HttpPost("give")]
        public IActionResult GiveBook(GivenBook book)
        {
            _booksBusinessLogic.GiveBook(book);

            return Ok();
        }
    }
}
