using Books.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Books.Infrastructure
{
    public abstract class RepositoryBase
    {
        private string GetConnectionString()
        {
            return "server=DESKTOP-Q9NL26Q\\SQLEXPRESS;database=Books;Integrated Security=true;";
        }
        protected void ExecuteCommand(string command)
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

        protected List<Book> ExecuteCommandWithQuery(string command)
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

    }
}
