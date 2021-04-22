using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IBookService
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByTitle(string title);
        void UpdateBook(Book book);
    }
}