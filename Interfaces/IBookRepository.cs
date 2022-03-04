using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
        public void Save();
    }
}
