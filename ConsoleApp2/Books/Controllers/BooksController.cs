using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private IBooksRepository _booksRepository;

        public BooksController(IBooksRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _booksRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_booksRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            _booksRepository.Insert(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            if (book == null || book.Name == null || book.Name == string.Empty)
                return BadRequest("Неправильный формат данных о книге! Введите данные о книге в правильном формате.");

            _booksRepository.Update(book);
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            _booksRepository.Delete(bookId);
            return Ok();
        }
    }
}
