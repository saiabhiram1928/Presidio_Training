using LibraryManagementModelLib;
using LibraryManagmentDALLib;

namespace LibraryManagementBLLib
{
    public class BookBL : BookService
    {
        readonly IRepository<int, Book> _bookRepository;
        void ThrowingNullException(string text)
        {
            throw new NullReferenceException(text);
        }
        public BookBL()
        {
            _bookRepository = new BookRepository();
        }
       
        public override Book AddBook(Book book)
        {
            var response  = _bookRepository.Add(book);
            if(response == null)
            {
                throw new DuplicateWaitObjectException();
            }
            return response;
        }

        public override Book ChangeBookTitle(string newBookTitle, int id)
        {
            var response = _bookRepository.GetById(id);
            if(response == null)
            {
                ThrowingNullException("The Book With Given Id Doesn't Exist");
            }
            response.Title = newBookTitle;
            return _bookRepository.Update(response);
        }

        public override List<Book> GetAllBook()
        {
            List<Book> response = _bookRepository.GetAll();
            if (response == null) ThrowingNullException("There No Books Present in the db");
            return response;
        }

        public override Book GetBookbyId(int id)
        {
            var response = _bookRepository.GetById(id);
            if (response == null) ThrowingNullException("The Book With Given Id doesnt Exist");
            return response;
        }
        public override int Count()
        {
            return _bookRepository.Count();
        }
        public override bool DeleteBook(int id)
        {
            var response = _bookRepository.Delete(id);
            if (response == false) ThrowingNullException("The Book With Given Doesnt Exist");
            return response;
              
        }
    }
}
