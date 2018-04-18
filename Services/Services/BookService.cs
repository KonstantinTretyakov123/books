using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;
using DatabaseLevel.Repositoty;
using Services.Interfaces;

namespace Services.Services
{
    public class BookService : IBookService
    {
        private IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> carRepository)
        {
            _bookRepository = carRepository;
        }

        public Book AddBook(Book book)
        {
            var newCar = _bookRepository.Add(book);
            _bookRepository.Save();
            return newCar;
        }

        public IEnumerable<Book> ShowBooks()
        {
            return _bookRepository.GetAll()
                .Where(u => u.BuyerId == null);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
            _bookRepository.Save();
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
            _bookRepository.Save();
        }

        public Book FindById(Guid id)
        {
            return _bookRepository.Find(u => u.Id == id);
        }

        public IEnumerable<Book> GetUserBooks(Guid id)
        {
            return _bookRepository.GetAll()
                .Where(u => u.UserId == id && u.BuyerId == null);
        }

        public IEnumerable<Book> GetSortedBooks(string value)
        {
            IEnumerable<Book> books;
            if (value == "author")
            {
                books = _bookRepository.GetAll()
                    .Where(u => u.BuyerId == null)
                    .OrderBy(u => u.Author);

            }
            else
            {
                books = _bookRepository.GetAll()
                    .Where(u => u.BuyerId == null)
                    .OrderBy(u => u.Cost);
            }

            return books;
        }

        public IEnumerable<Book> GetBuyerBooks(Guid id)
        {
            return _bookRepository.GetAll()
                .Where(u => u.BuyerId == id);
        }

       
    }
}