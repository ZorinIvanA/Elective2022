using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using Books.Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Books.Infrastructure
{
    public class BooksRepository : RepositoryBase, IBooksRepository
    {
        public Book[] GetAll()
        {
            return ExecuteCommandWithQuery(
                $"SELECT id, Name FROM Books").ToArray();
        }

        public Book GetById(int id)
        {
            var books = ExecuteCommandWithQuery($"SELECT id, Name FROM Books WHERE id={id}");

            return books.FirstOrDefault();
        }

        public void Insert(Book book)
        {
            ExecuteCommand($"INSERT INTO Books(Name, Author_id) VALUES ('{book.Name}', {book.AuthorId})");
        }

        public void Update(Book book)
        {
            ExecuteCommand($"UPDATE Books SET Name = '{book.Name}', Author_Id= {book.AuthorId} WHERE Id={book.Id}");
        }

        public void Delete(int id)
        {
            ExecuteCommand($"DELETE FROM Books WHERE Id={id}");
        }
    }
}
