using Assignment2_Library_Management_System_Web_API.Models;

namespace Assignment2_Library_Management_System_Web_API.Interfaces
{
    public interface IBook
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
        void AddBook(Book book);
        bool UpdateBook(int id, Book book);
        bool DeleteBook(int id);

    }
}
