using BookDataAccess.Interface;
using BookEntities.Entities.Models.BookCrudOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookDataAccess
{
    public class BooksDA : IBooksDA
    {
        private readonly BooksDbContext _context;
        public BooksDA(BooksDbContext context)
        {
            _context = context;
        }

        public int AddBook(Books bk)
        {
            _context.Books.Add(bk);
            return _context.SaveChanges();
        }

        public int DeleteBook(long BookId)
        {
            Books bk = _context.Books.FirstOrDefault(x => x.BookId == BookId);
            _context.Books.Remove(bk);
            return _context.SaveChanges();
        }

        public Books GetBookById(long BookId)
        {
            return _context.Books.FirstOrDefault(e => e.BookId == BookId);
        }

        public List<Books> GetBooks()
        {
            return _context.Books.ToList();
        }

        public int UpdateBook(Books bk)
        {
            var updatebk = _context.Books.FirstOrDefault(x => x.BookId == bk.BookId);
            updatebk.BookName = bk.BookName;
            updatebk.BookDescription = bk.BookDescription;
            updatebk.AuthorName = bk.AuthorName;
            updatebk.Comments = bk.Comments;
            updatebk.PublicationYear = bk.PublicationYear;
            updatebk.Price = bk.Price;
            return _context.SaveChanges();

        }
    }
}
