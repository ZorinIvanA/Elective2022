using Books.Domain;

namespace Books.Infrastructure
{
    public class GivenBookRepository : RepositoryBase, IGivenBooksRepository
    {
        public void Insert(GivenBook book)
        {
            ExecuteCommand($"INSERT INTO GivenBooks(customer, book_id, given_date, period) VALUES ('{book.Customer}', {book.Book.Id}, '{book.GivenDate}', {book.GivenPeriod})");
        }
    }
}
