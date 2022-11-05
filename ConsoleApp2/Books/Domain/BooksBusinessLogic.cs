﻿using System;

namespace Books.Domain
{
    public class BooksBusinessLogic : IBooksBusinessLogic
    {
        IBooksRepository _booksRepository;
        public BooksBusinessLogic(IBooksRepository repository)
        {
            _booksRepository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public void Delete(int id)
        {
            _booksRepository.Delete(id);
        }

        public Book[] GetAll()
        {
            return _booksRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _booksRepository.GetById(id);
        }

        public void Insert(Book book)
        {
            _booksRepository.Insert(book);
        }

        public void Update(Book book)
        {
            _booksRepository.Update(book);
        }
    }
}
