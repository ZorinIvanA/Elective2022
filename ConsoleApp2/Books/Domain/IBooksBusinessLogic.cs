namespace Books.Domain
{
    public interface IBooksBusinessLogic
    {
        Book[] GetAll();
        Book GetById(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int id);
        void GiveBook(GivenBook book);
    }
}
