using LibraryManagementModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLib
{
    public abstract class BookService
    {
        public abstract Book AddBook(Book book);
        public abstract Book ChangeBookTitle(string newBookTitle , int id);
        public abstract Book GetBookbyId(int id);
        public abstract List<Book> GetAllBook();
        public abstract int Count();
        public abstract bool DeleteBook(int id);
    }
}
