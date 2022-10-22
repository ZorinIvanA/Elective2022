using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public IActionResult Get()
        {
            var connectionString =
                "server=DESKTOP-Q9NL26Q\\SQLEXPRESS;database=Books;Integrated Security=true;";


            using (var connection = new SqlConnection(connectionString))
            {
                var books = new List<Book>();
                connection.Open();

                using (var sqlCommand = new SqlCommand("SELECT id, Name FROM Books", connection))
                {         
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                        });
                    }
                }

                connection.Close();

                return Ok(books);
            }
        }
    }
}
