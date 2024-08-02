using Assignment2_Library_Management_System_Web_API.Interfaces;
using Assignment2_Library_Management_System_Web_API.Models;

namespace Assignment2_Library_Management_System_Web_API.Services
{
    public class BookService:IBook
    {
        private static List<Book> bookList = new List<Book>();
        public IEnumerable<Book> GetAllBook()
        {
            return bookList;
        }
        public Book GetBookById(int id)
        {
            return bookList.Find(cek => cek.Id == id);
        }
        public void AddBook(Book book)
        {
            book.Id = bookList.Count + 1;
            bookList.Add(book);
        }
        public bool UpdateBook(int id, Book editBook)
        {
            Book existingBook = bookList.Find(cek => cek.Id == id);
            if (existingBook != null)
            {
                existingBook.Title = editBook.Title;
                existingBook.Author = editBook.Author;
                existingBook.PublicationYear = editBook.PublicationYear;
                existingBook.ISBN = editBook.ISBN;
                return true;
            }
            return false;
        }
        public bool DeleteBook(int id)
        {
            Book deleteBook = bookList.Find(cek=>cek.Id == id);
            if (deleteBook != null)
            {
                bookList.Remove(deleteBook);
                return true;
            }
            return false;
        }
    }
}
