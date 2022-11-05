using System;

namespace Books.Domain
{
    public interface IGivenBooksRepository
    {
        void Insert(GivenBook book);
    }
}
