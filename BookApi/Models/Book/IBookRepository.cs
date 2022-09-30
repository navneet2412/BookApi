using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookById(int id);
        Book AddBook(Book book);
        string DeleteBook(int id);
        Book UpdateBook(int id,Book book);


    }
}
