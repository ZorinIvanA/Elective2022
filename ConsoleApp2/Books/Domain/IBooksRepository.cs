namespace Books.Domain
{
    public interface IBooksRepository
    {
        Book[] GetAll();
        Book GetById(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
