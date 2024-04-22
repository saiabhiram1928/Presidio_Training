using LibraryManagementModelLib;
using LibraryManagmentDALLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLib
{
    public class PatronBL : PatronService
    {
        readonly IRepository<int, Patron> _patronRepository;
        void ThrowingNullException(string text)
        {
            throw new NullReferenceException(text);
        }
        public PatronBL()
        {
            _patronRepository = new PatronRepository();
        }


       
        public override Patron AddPatron(Patron user)
        {
            var response = _patronRepository.Add(user);
            if (response == null)
            {
                throw new DuplicateWaitObjectException();
            }
            return response;
        }

        public override Patron ChangePatronName(string newUserName, int id)
        {
            var response = _patronRepository.GetById(id);
            if (response == null)
            {
                ThrowingNullException("The Book With Given Id Doesn't Exist");
            }
            response.Name = newUserName;
            return _patronRepository.Update(response);
        }

        public override List<Patron> GetAllPatrons()
        {
            List<Patron> response = _patronRepository.GetAll();
            if (response == null) ThrowingNullException("There No Users Present in the db");
            return response;
        }

        public override Patron GetPatronbyId(int id)
        {
            var response = _patronRepository.GetById(id);
            if (response == null) ThrowingNullException("The Book With Given Id doesnt Exist");
            return response;
        }
        public override int Count()
        {
            return _patronRepository.Count();
        }
        public override bool DeletePatron(int id)
        {
            var response = _patronRepository.Delete(id);
            if (response == false) ThrowingNullException("The Book With Given Doesnt Exist");
            return response;

        }
    }
}
