using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;

namespace Services.Interfaces
{
    public interface IBookService
    {
        Book AddBook(Book book);
        IEnumerable<Book> ShowBooks();
        void DeleteBook(Book book);
        Book FindById(Guid id);
        IEnumerable<Book> GetUserBooks(Guid id);
        IEnumerable<Book> GetSortedBooks(string value);
        IEnumerable<Book> GetBuyerBooks(Guid id);
        void UpdateBook(Book book);
    }
}
