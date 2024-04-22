using LibraryManagementModelLib;
using LibraryManagmentDALLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLib
{
    public class BorrowingBl 
    {
        readonly IRepository<int , Book_Borrowing> _borrowingRepository;
        void ThrowingNullException(string text)
        {
            throw new NullReferenceException(text);
        }
        public BorrowingBl()
        {
            _borrowingRepository = new BorrowingRespository();
        }
        public bool BorrowingRequest(Book_Borrowing Request)
        {
            var response = _borrowingRepository.Add(Request);
            if (response == null)
            {
                throw new DuplicateWaitObjectException();
            }
            return true;
        }
        public List<Book_Borrowing> GetAllRequest()
        {
            List<Book_Borrowing> response = _borrowingRepository.GetAll();
            if (response == null) ThrowingNullException("There No Requests Present in the db");
            return response;
        }
        public  Book_Borrowing GetReqById(int id)
        {
            var response = _borrowingRepository.GetById(id);
            if (response == null) ThrowingNullException("The Request With Given Id doesnt Exist");
            return response;
        }
        public double EndRequest(Book_Borrowing req)
        {
            req.Book.Availability = "Available";
            var respone = _borrowingRepository.Update(req);
            if (respone == null) ThrowingNullException("The Request With Given  Id is not availble");
            return req.LateReturnFee;
        }
        public  int Count()
        {
            return _borrowingRepository.Count();
        }


    }
}
