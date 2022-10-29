using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace Books
{
    public class BooksRepository
    {
        private string GetConnectionString()
        {
            return "server=DESKTOP-Q9NL26Q\\SQLEXPRESS;database=Books;Integrated Security=true;";
        }

        public List<Book> GetAll()
        {
            var connectionString = GetConnectionString();
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
                return books;
            }
        }

        public Book GetById(int id)
        {
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                var books = new List<Book>();
                connection.Open();

                using (var sqlCommand = new SqlCommand($"SELECT id, Name FROM Books WHERE id={id}", connection))
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

                return books.FirstOrDefault();
            }
        }

        public void Insert(Book book)
        {
            var connectionString = GetConnectionString();


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandText =
                    $"INSERT INTO Books(Name, Author_id) VALUES ('{book.Name}', {book.AuthorId})";

                using (var sqlCommand = new SqlCommand(commandText, connection))
                {
                    var reader = sqlCommand.ExecuteNonQuery();
                }

                connection.Close();                
            }
        }

        public void Update(Book book)
        {
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandText =
                    $"UPDATE Books SET Name = '{book.Name}', Author_Id= {book.AuthorId} WHERE Id={book.Id}";

                using (var sqlCommand = new SqlCommand(commandText, connection))
                {
                    var reader = sqlCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void Delete(int id)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandText =
                    $"DELETE FROM Books WHERE Id={id}";

                using (var sqlCommand = new SqlCommand(commandText, connection))
                {
                    var reader = sqlCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
