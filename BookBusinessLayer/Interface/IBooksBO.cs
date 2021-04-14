using BookEntities.Entities.Models.BookCrudOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBusinessLayer.Interface
{
    public interface IBooksBO
    {
        List<Books> GetBooks();
        int AddBook(Books bk);
        int DeleteBook(long BookId);
        int UpdateBook(Books bk);
        Books GetBookById(long BookId);
    }
}
