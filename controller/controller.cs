using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static projectPBO.model;

namespace projectPBO
{
    internal class controller
    {
        public class BookController
        {
            private BookRepository bookRepository;

            public BookController()
            {
                bookRepository = new BookRepository();
            }

            public void AddBook(Book book)
            {
                bookRepository.InsertBook(book);
            }
            public List<Book> GetAllBooks()
            {
                return bookRepository.GetAllBooks();
            }

            public void UpdateBook(Book book)
            {
                bookRepository.UpdateBook(book);
            }
        }

    }
}
