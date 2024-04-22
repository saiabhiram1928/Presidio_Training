using LibraryManagementModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLib
{
    public abstract class PatronService
    {
        public abstract Patron AddPatron(Patron book);
        public abstract Patron ChangePatronName(string newBookTitle, int id);
        public abstract Patron GetPatronbyId(int id);
        public abstract List<Patron> GetAllPatrons();
        public abstract int Count();
        public abstract bool DeletePatron(int id);
    }
}
