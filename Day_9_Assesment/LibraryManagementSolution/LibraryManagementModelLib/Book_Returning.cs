using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLib
{
    public class Book_Returning
    {
        public Book Book { get; set; }
        public Patron Patron { get; set; }
        public double LateReturnFee { get; private set; }   
        public DateOnly ReturningDate { get; set; }

        public double CalculateLateReturnFee(DateOnly borrowingDate, DateOnly dueDate, DateOnly returningDate)
        {
            if (returningDate > dueDate)
            {
                DateTime borrowingDateTime = new DateTime(borrowingDate.Year, borrowingDate.Month, borrowingDate.Day);
                DateTime dueDateTime = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day);
                DateTime returningDateTime = new DateTime(returningDate.Year, returningDate.Month, returningDate.Day);
                TimeSpan lateDays = returningDateTime - dueDateTime;
                double daysLate = lateDays.TotalDays;
                return daysLate * 20;
            }
            return 0;
        }
        public Book_Returning()
        {
            ReturningDate = new DateOnly();
            LateReturnFee = 0;
            Book = new Book();
            Patron = new Patron();
        }
        public Book_Returning(Book book, Patron patron, DateOnly returningDate, Book_Borrowing borrowing)
        {
            Book = book;
            Book.Availability = "Available";
            Patron = patron;
            ReturningDate = returningDate;
            LateReturnFee =CalculateLateReturnFee(borrowing.BorrowingDate,borrowing.DueDate , returningDate) ;
           
        }
    }
}
