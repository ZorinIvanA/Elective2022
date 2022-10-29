using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var repository = new BooksRepository();

            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var repository = new BooksRepository();

            return Ok(repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            var repository = new BooksRepository();
            repository.Insert(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            var repository = new BooksRepository();
            repository.Update(book);
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            var repository = new BooksRepository();
            repository.Delete(bookId);
            return Ok();            
        }
    }
}
