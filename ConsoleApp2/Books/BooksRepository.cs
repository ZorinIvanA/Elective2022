using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

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
            return this.ExecuteCommandWithQuery($"SELECT id, Name FROM Books");
        }

        public Book GetById(int id)
        {
            var books = this.ExecuteCommandWithQuery($"SELECT id, Name FROM Books WHERE id={id}");

            return books.FirstOrDefault();
        }

        private List<Book> ExecuteCommandWithQuery(string command)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandText = command;
                List<Book> books = new List<Book>();

                using (var sqlCommand = new SqlCommand(commandText, connection))
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

        public void Insert(Book book)
        {
            this.ExecuteCommand($"INSERT INTO Books(Name, Author_id) VALUES ('{book.Name}', {book.AuthorId})");
        }

        public void Update(Book book)
        {
            this.ExecuteCommand($"UPDATE Books SET Name = '{book.Name}', Author_Id= {book.AuthorId} WHERE Id={book.Id}");
        }

        public void Delete(int id)
        {
            this.ExecuteCommand($"DELETE FROM Books WHERE Id={id}");
        }

        private void ExecuteCommand(string command)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandText = command;

                using (var sqlCommand = new SqlCommand(commandText, connection))
                {
                    var reader = sqlCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
