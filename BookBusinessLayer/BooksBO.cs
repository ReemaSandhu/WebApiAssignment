using BookBusinessLayer.Interface;
using BookDataAccess.Interface;
using BookEntities.Entities.Models.BookCrudOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBusinessLayer
{
    public class BooksBO : IBooksBO
    {
        private readonly IBooksDA _bookdata;

        public BooksBO(IBooksDA bookdata)
        {
            _bookdata = bookdata;
        }

        public int AddBook(Books bk)
        {
            return _bookdata.AddBook(bk);
        }

        public int DeleteBook(long BookId)
        {
            return _bookdata.DeleteBook(BookId);
        }

        public Books GetBookById(long BookId)
        {
            return _bookdata.GetBookById(BookId);
        }

        public List<Books> GetBooks()
        {
            return _bookdata.GetBooks();
        }

        public int UpdateBook(Books bk)
        {
            return _bookdata.UpdateBook(bk);
        }
    }
}
