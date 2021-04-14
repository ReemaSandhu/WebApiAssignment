using BookEntities.Entities.Models.BookCrudOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookDataAccess.Interface
{
    public interface IBooksDA
    {
        //List<Books> GetEmployee();
        List<Books> GetBooks();
        int AddBook(Books bk);
        int DeleteBook(long BookId);
         int UpdateBook(Books bk);
        Books GetBookById(long BookId);

        //int AddComment(AddComments comments);
    }
}
